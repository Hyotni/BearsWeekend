using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class Buy : MonoBehaviour {

    const int IS_TRUE = 1;
    const int IS_FALSE = 0;

    const int IS_EMPTY_INVENTORY = 0;
    const int IS_FULL_INVENTORY = 1;

    /**
     * 상점 아이템 구입
     */

    public GameObject buyPanel;
    public GameObject noMoneyPanel;
    public GameObject checkPanel;
    public GameObject noBuyPanel;

    public int coin = 0;
    public int price = 0;

    private string roomName;
    private string roomStyle;

    private string foodNumber;
    private string inventoryNumber;
    private string foodTag;

    private string selectedFoodNumber;
    private string selectedFoodStyle;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        coin = PlayerPrefs.GetInt("ACoin", 0);
        price = PlayerPrefs.GetInt("Price", 0);
    }

    public void Cancel() 
    {
        if (buyPanel.activeSelf) 
        {
            buyPanel.SetActive(false);
        }

        else if (noMoneyPanel.activeSelf)
        {
            noMoneyPanel.SetActive(false); 
        }

        else if (checkPanel.activeSelf) 
        {
            checkPanel.SetActive(false);
        }

        else if (noBuyPanel.activeSelf)
        {
            noBuyPanel.SetActive(false); 
        }

    }

    public void BuyItem()
    {

        if (PlayerPrefs.GetInt("TrueFood") == IS_TRUE) 
            // 음식인 경우
        {

            if (PlayerPrefs.GetInt("Inventory3")==IS_FULL_INVENTORY) 
                // 구매 불가일 때 (인벤토리가 가득 참)
            {
                    buyPanel.SetActive(false);
                    noBuyPanel.SetActive(true);

            }
            else
                Pay(); // 구매

        }
        else if (PlayerPrefs.GetInt("TrueFood") == IS_FALSE) 
            // 가구인 경우
        {
            roomName = PlayerPrefs.GetString("RoomName", "Default");
            roomStyle = PlayerPrefs.GetString("RoomStyle", "Default");

            if (roomStyle == PlayerPrefs.GetString(roomName)) 
                //구매 불가일 때 (이미 적용 중)
            {
                buyPanel.SetActive(false);
                noBuyPanel.SetActive(true);
            }
            else
                Pay(); // 구매
        }

    }

    public void Pay()
    {
        if (coin >= price) // 잔액 충분
        {

            coin -= price;

            PlayerPrefs.SetInt("ACoin", coin);
            PlayerPrefs.SetInt("Price", 0);

            if (PlayerPrefs.GetInt("TrueFood") == IS_FALSE) // 가구인 경우
            {

                PlayerPrefs.SetString(roomName, roomStyle);
            }

            if (PlayerPrefs.GetInt("TrueFood") == IS_TRUE) // 음식인 경우
            {
                selectedFoodNumber = PlayerPrefs.GetString("SelectedFoodName");
                selectedFoodStyle = PlayerPrefs.GetString("SelectedFoodStyle");

                FoodStack();
            }

            buyPanel.SetActive(false);
            checkPanel.SetActive(true);

            PlayerPrefs.SetInt("TrueFood", 0); // 음식 구분 정보 초기화

        }

        else // 잔액 부족
        {
            buyPanel.SetActive(false);
            noMoneyPanel.SetActive(true);
        }
    }

        /**
        * 음식 저장
        */

        public void FoodStack()
        {

        for (int i = 1; i <= 3; i++)
        {
            foodNumber = ("Food" + i);
            inventoryNumber = ("Inventory" + i);
            foodTag = ("FoodTag" + i);

            if (PlayerPrefs.GetInt(inventoryNumber) == IS_EMPTY_INVENTORY)
                // 인벤토리가 비었을 때
            {

                PlayerPrefs.SetString(foodNumber, selectedFoodNumber); // 음식 이미지 저장
                PlayerPrefs.SetString(foodTag, selectedFoodStyle); // 음식 스타일 저장
                PlayerPrefs.SetInt(inventoryNumber, IS_FULL_INVENTORY); // 해당 칸에 아이템이 있음
               

                PlayerPrefs.SetString("FoodName", "Empty"); // 아이템 이미지 정보 초기화

                break;

            }
        }


        }

}
