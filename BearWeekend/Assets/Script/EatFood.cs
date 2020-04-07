using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EatFood : MonoBehaviour {

    /**
     * 먹고 남은 음식 정렬하기
     */

    const int IS_EMPTY_INVENTORY = 0;
    const int IS_FULL_INVENTORY = 1;

    public GameObject foodPanel;
    public GameObject noFoodPanel;

    public Button button;
    public GameObject image;
    public GameObject nowFood;
    public GameObject EatenFood;

    private string selectedFoodNum;
    private string selectedInventoryNum;
    private string selectedFoodStyleNum;

    private string FoodID;

    // Use this for initialization
    void Start() {
        selectedFoodNum = button.name;

        for (int i = 1; i <= 3; i++)
        {
            if (selectedFoodNum == "Food" + i) 
                // 선택한 버튼이 특정 칸인 경우
            {
                selectedFoodStyleNum = ("FoodTag" + i);
                selectedInventoryNum = ("Inventory" + i); // 특정 칸에 저장돼 있는 정보를 불러옴
            }

        }

        FoodID = PlayerPrefs.GetString(selectedFoodNum, "Empty"); // 음식의 아이콘 이름 불러옴, 없을 경우 "Empty"로 초기화
        image.GetComponent<Image>().sprite = Resources.Load<Sprite>("Item/Food/" + FoodID); // 불러온 아이콘을 띄움

        if (PlayerPrefs.GetInt(selectedInventoryNum) == IS_EMPTY_INVENTORY || PlayerPrefs.GetString(selectedFoodNum) == "Empty")
            // 선택된 칸이 비어있는 경우 
            // 게임을 처음 시작한 경우에는 인벤토리 데이터가 없으므로, 이름의 초기화 값인 "Empty"도 검사함
        {

            if (selectedFoodNum == "Food1")
                //음식이 하나도 없을 경우
            {
                foodPanel.SetActive(false);
                noFoodPanel.SetActive(true); // 음식 없음 패널 띄움
            }

            else
                //음식이 하나라도 있는 경우
            {
                button.interactable = false; // 버튼을 비활성화
                image.SetActive(false); // 음식 아이콘을 띄우지 않음
            }
        }

        button.onClick.AddListener(Click);
    }

    // Update is called once per frame
    void Update () {
		
	}

    /**
     * 음식 먹기
     */

    public void Click()
    {
        PlayerPrefs.SetString("Eat", "YES"); // 퇴근 시에 반영하기 위해 상태 업데이트
        foodPanel.SetActive(false);

        nowFood.gameObject.SetActive(true); 
        EatenFood.GetComponent<Image>().sprite = Resources.Load<Sprite>("Item/Food/" + FoodID); // 현재 먹은 음식을 표시

        string selectedFoodStyle = PlayerPrefs.GetString(selectedFoodStyleNum);

        float foodEffect = 0; // 음식 효과 값 초기화

        if (selectedFoodStyle == "Snack")
        {
            foodEffect = 0.1f;
        }
        else if (selectedFoodStyle == "Fruit")
        {
            foodEffect = 0.15f;
        }
        else if (selectedFoodStyle == "Rice")
        {
            foodEffect = 0.2f;
        }
        else if (selectedFoodStyle == "Meat")
        {
            foodEffect = 0.3f;
        }
        else if (selectedFoodStyle == "Special")
        {
            foodEffect = 0.5f;
        }

        
        PlayerPrefs.SetFloat("FoodEffect", foodEffect); // 음식 효과 값 저장

        // 음식 정보 초기화

        PlayerPrefs.SetString(selectedFoodNum, "Empty");
        PlayerPrefs.SetString(selectedFoodStyle, "Empty");
        PlayerPrefs.SetInt(selectedInventoryNum, IS_EMPTY_INVENTORY);

        Time.timeScale = 1.0f;

        // 남은 음식 정렬

        sortItem();
    }


    /**
     * 음식 정렬
     */

    private void sortItem()
    {
        for (int i = 1; i <= 3; i++)
        {

            //현재 칸 정보
            string foodNumber = ("Food" + i);
            string foodStyleNum = ("FoodTag" + i);
            string inventoryNum = ("Inventory" + i);

            //다음 칸 정보
            string nextFoodNumber = ("Food" + (i + 1));
            string nextFoodStyleNum = ("FoodTag" + (i + 1));
            string nextInventoryNum = ("Inventory" + (i + 1));


            if (foodNumber != ("Food3") && PlayerPrefs.GetInt(inventoryNum) == IS_EMPTY_INVENTORY &&
               PlayerPrefs.GetInt(nextInventoryNum) == IS_FULL_INVENTORY)
            // 마지막 칸이 아니고, 현재 칸에 아이템이 없지만 다음 칸에 아이템이 있는 경우
            {
                //현재 칸 음식 정보 갱신
                PlayerPrefs.SetString(foodNumber, PlayerPrefs.GetString(nextFoodNumber)); // 현재 칸 음식 이미지 갱신
                PlayerPrefs.SetString((foodStyleNum), PlayerPrefs.GetString(nextFoodStyleNum));// 현재 칸 음식 스타일 갱신
                PlayerPrefs.SetInt(inventoryNum, IS_FULL_INVENTORY); // 해당 칸에 아이템이 있음

                //다음 칸 음식 정보 제거
                PlayerPrefs.SetInt(nextInventoryNum, IS_EMPTY_INVENTORY);// 해당 칸에 아이템이 없음
                PlayerPrefs.SetString(nextFoodStyleNum, "Empty");// 다음 칸 음식 스타일 제거
                PlayerPrefs.SetString(nextFoodNumber, "Empty");// 다음 칸 음식 이미지 제거
            }
        }
    }
}
