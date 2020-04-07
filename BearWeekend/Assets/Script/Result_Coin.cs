using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result_Coin : MonoBehaviour {

    /**
     * 잔액 갱신
     */

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        Text text = GetComponent<Text>();

        int old_coin = PlayerPrefs.GetInt("ACoin", 0); // 있던 돈
        int new_coin = PlayerPrefs.GetInt("Coin", 0); // 얻은 돈
        old_coin += new_coin;

        PlayerPrefs.SetInt("ACoin", old_coin); // 전체 돈 재정의

        text.text = old_coin.ToString();

        PlayerPrefs.SetInt("Coin", 0); // 얻은 돈 초기화
    }
}
