using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    /**
    * 씬 이동
    */

    // Use this for initialization
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep; // 화면이 꺼지지 않음
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Load_Home()
    {
        SceneManager.LoadScene("Home");
    }

    public void Load_Main()
    {
        SceneManager.LoadScene("Main_menu");
    }

    public void Load_Outside()
    {
        SceneManager.LoadScene("Outside_menu");
    }

    public void Load_IShop()
    {
        SceneManager.LoadScene("IShop");
        PlayerPrefs.SetString("storeType", "Interior");
        PlayerPrefs.SetString("itemCategory", "LivingRoom");
    }

    public void Load_FShop()
    {
        SceneManager.LoadScene("FShop");
        PlayerPrefs.SetString("storeType", "Food");
        PlayerPrefs.SetString("itemCategory", "Normal");
    }

    public void Load_Work()
    {
        SceneManager.LoadScene("Work");
    }

}
