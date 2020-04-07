using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour {

    public Text muteText;

	// Use this for initialization
	void Start () {
        if (AudioListener.pause == true)
        {
            // 음소거 적용중
            muteText.text = "음소거 해제";
        }
        else if (AudioListener.pause == false)
        {
            // 음소거 해제중
            muteText.text = "음소거";
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Mute()
    {
        //전체 음소거

        if (AudioListener.pause == false)
        {
            // 음소거 적용
            muteText.text = "음소거 해제";
            AudioListener.pause = true;
        }
        else if(AudioListener.pause == true)
        {
            // 음소거 해제
            muteText.text = "음소거";
            AudioListener.pause = false;
        }
    }

    public void Delete()
    {
        //전체 초기화
        PlayerPrefs.DeleteAll();
    }

    public void Exit()
    {
        //게임 종료
        #if UNITY_WEBPLAYER
        public static string webplayerQuitURL = "http://google.com";
        #endif

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
         Application.OpenURL(webplayerQuitURL);
        #else
         Application.Quit();
        #endif

    }
}
