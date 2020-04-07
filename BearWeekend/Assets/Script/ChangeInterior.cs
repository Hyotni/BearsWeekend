using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeInterior : MonoBehaviour {


    /**
     * 인테리어 변경
     */

    public GameObject livingRoom;
    public GameObject bedRoom;
    public GameObject hobbyRoom;
    public GameObject dressRoom;
    // Use this for initialization
    void Start () {

        string livingRoomID = PlayerPrefs.GetString("LivingRoom", "Default");
        string bedRoomID = PlayerPrefs.GetString("BedRoom", "Default");
        string hobbyRoomID = PlayerPrefs.GetString("HobbyRoom", "Default");
        string dressRoomID = PlayerPrefs.GetString("DressRoom", "Default");

        // 거실 정보 불러오기
        Debug.Log(livingRoomID+" 적용 중입니다.");
        livingRoom.GetComponent<Image>().sprite = Resources.Load<Sprite>("Interior/LivingRoom/"+livingRoomID);

        // 침실 정보 불러오기
        Debug.Log(bedRoomID + " 적용 중입니다.");
        bedRoom.GetComponent<Image>().sprite = Resources.Load<Sprite>("Interior/BedRoom/" + bedRoomID);

        // 취미방 정보 불러오기
        Debug.Log(hobbyRoomID + " 적용 중입니다.");
        hobbyRoom.GetComponent<Image>().sprite = Resources.Load<Sprite>("Interior/HobbyRoom/" + hobbyRoomID);

        // 옷방 정보 불러오기
        Debug.Log(dressRoomID + " 적용 중입니다.");
        dressRoom.GetComponent<Image>().sprite = Resources.Load<Sprite>("Interior/DressRoom/" + dressRoomID);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
