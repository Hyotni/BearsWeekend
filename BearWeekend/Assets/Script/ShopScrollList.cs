using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System;

[System.Serializable]
public class Item
{
    public string itemName;
    public string tag;
    public string style;
    public string iconName;
    public Sprite icon;
    public int price = 0;
}

public class ShopScrollList : MonoBehaviour
{

    /**
     * 상점 리스트 표기
     */

    const string interiorStore = "Interior";
    const string foodStore = "Food";
    const int IS_TRUE = 1;
    const int IS_FALSE = 0;

    public List<Item> itemList;
    public Transform contentPanel;
    public SimpleObjectPool buttonObjectPool;
    public Text descText;
    
    public GameObject buyPanel;
    public GameObject noMoneyPanel;

    public Image selectedItemImage;

    public int Coin = 0;

    // Use this for initialization
    void Start()
    {
        if(PlayerPrefs.GetString("storeType")== "Interior")
        {
            AddButtons("Interior", "LivingRoom");
            AddButtons("Interior", "HobbyRoom");
            AddButtons("Interior", "DressRoom");
            AddButtons("Interior", "BedRoom");
        }
        if (PlayerPrefs.GetString("storeType") == "Food")
        {
            AddButtons("Food", "Normal");
        }
        buyPanel.SetActive(false);
        noMoneyPanel.SetActive(false);
        Coin = PlayerPrefs.GetInt("ACoin", 0);
    }

    void RefreshDisplay()
    {
        RemoveButtons();
        AddButtons();
    }

    /**
    * 리스트 추가
    */

    private void AddButtons()
    {
        string storeType = PlayerPrefs.GetString("storeType");
        string itemCategory = PlayerPrefs.GetString("itemCategory");
        AddButtons(storeType, itemCategory);
        Debug.Log(storeType + itemCategory);
    }

    /**
     * @storeType     버튼 추가할 곳의 상점 대분류 (ex: 음식 상점, 가구 상점)
     * @itemCategory  상점 내 아이템 분류 (ex: 거실, 취미방 등등)
     */
    private void AddButtons(string storeType, string itemCategory)
    {
        XmlDocument xmlDocument = new XmlDocument();
        string filepath = Application.dataPath + @"/Resources/Data/shopItem.xml";
        if (File.Exists(filepath))
        {
            // XML 로드
            xmlDocument.Load(filepath);

                XmlNodeList xmlNodeList = xmlDocument.GetElementsByTagName(storeType);
                foreach (XmlNode node in xmlNodeList)
                {
                    // 아이템 분류
                    XmlNodeList itemCategoryList = node.ChildNodes;
                    foreach (XmlNode itemCategoryNode in itemCategoryList)
                    {
                        if (itemCategory.Equals(itemCategoryNode.Name))
                        {
                            CreateButton(CreateItem(itemCategoryNode.ChildNodes, storeType, itemCategory));

                            Debug.Log(itemCategoryNode.ChildNodes + storeType + itemCategory);
                            Debug.Log(itemCategoryNode.ChildNodes.Count);
                        }
                    }
                }

        }
        else
            Debug.Log("상품 정보를 읽어오지 못했습니다.");

        for (int i = 0; i < itemList.Count; i++)
        {
            Item item = itemList[i];

        }
    }

    void RemoveButtons()
    {
        while (contentPanel.childCount > 0)
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            buttonObjectPool.ReturnObject(toRemove);
        }
    }

    void AddItem(Item itemToAdd, ShopScrollList shopList)
    {
        shopList.itemList.Add(itemToAdd);
    }

    List<Item> CreateItem(XmlNodeList nodeList, string storeType, string itemCategoryName)
    {
        List<Item> itemList = new List<Item>();
        // (ex: Name 필드)
        foreach (XmlNode node in nodeList)
        {
            XmlNodeList childNode = node.ChildNodes;
            Item item = new Item();

            // (ex: Name 안에 가격, 스타일, 이름 등의 필드 획득)
            foreach (XmlNode dataNode in childNode)
            {
                if ("Title".Equals(dataNode.Name))
                {
                    // 아이템 이름 획득
                    item.itemName = dataNode.InnerText;
                }
                else if ("Price".Equals(dataNode.Name))
                {
                    // 가격 획득
                    item.price = Int32.Parse(dataNode.InnerText);
                }

                else if ("Style".Equals(dataNode.Name))
                {
                    // 스타일 획득
                    item.style = dataNode.InnerText;
                }

                else if ("IconName".Equals(dataNode.Name))
                {
                    // 아이콘 이름 획득
                    item.iconName = dataNode.InnerText;

                    // Icon 리소스 획득
                    string resourcePath = storeType + "/" + itemCategoryName + "/" + item.iconName;
                    item.icon = Resources.Load<Sprite>(resourcePath);
                }
            }
            itemList.Add(item);
        }
        return itemList;
    }

    void CreateButton(List<Item> items)
    {
        foreach(Item item in items) {
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(contentPanel, false);

            SampleButton sampleButton = newButton.GetComponent<SampleButton>();
            sampleButton.Setup(item, this);
        }
    }

    /**
       * 고른 아이템 정보 확인
     */

    public void SelectedItemCheck(Item item)
    {

        buyPanel.SetActive(true);

        // 가격
        PlayerPrefs.SetInt("Price", item.price);

        //음식 정보 저장

        if (PlayerPrefs.GetString("storeType")=="Food")
        {
            PlayerPrefs.SetInt("TrueFood", IS_TRUE);
            PlayerPrefs.SetString("SelectedFoodName", item.itemName);
            PlayerPrefs.SetString("SelectedFoodIcon", item.iconName);
            PlayerPrefs.SetString("SelectedFoodNum", item.itemName);
            PlayerPrefs.SetString("SelectedFoodStyle", item.style);

            float foodEffect = 0;

            if (item.style == "Snack")
            {
                foodEffect = 0.1f;
            }
            else if (item.style == "Fruit")
            {
                foodEffect = 0.15f;
            }
            else if (item.style == "Rice")
            {
                foodEffect = 0.2f;
            }
            else if (item.style == "Meat")
            {
                foodEffect = 0.3f;
            }
            else if (item.style == "Special")
            {
                foodEffect = 0.5f;
            }

            descText.text = (item.itemName + "! " + item.price + " 코인이야. 어때? \n" +
                "이걸 먹고 출근하면 돈을 " + foodEffect + "배 더 벌 수 있어. ");// 식료품점 토끼의 대사
            selectedItemImage.GetComponent<Image>().sprite = item.icon;

        }
        else
        {
            PlayerPrefs.SetInt("TrueFood", IS_FALSE);
            PlayerPrefs.SetString("RoomName", item.tag);
            PlayerPrefs.SetString("RoomStyle", item.style);

            descText.text = (item.itemName + "은 정말 최고지.\n설치 비용으로 " + 
                item.price + " 코인을 받고 있어.");//가구점 너구리의 대사
            selectedItemImage.GetComponent<Image>().sprite = item.icon;
        }
    }
}