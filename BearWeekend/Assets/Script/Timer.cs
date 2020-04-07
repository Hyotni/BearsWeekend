using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public GameObject foodPanel;
    public GameObject canvas;

    // Use this for initialization
    void Start () {

        Time.timeScale = 0.0f;
        foodPanel.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {

        float time = Time.timeSinceLevelLoad;

        int h = Mathf.FloorToInt(time / 3600.0f);

        time %= 3600.0f;

        int m = Mathf.FloorToInt(time / 60.0f);

        time %= 60.0f;

        int s = Mathf.FloorToInt(time / 1.0f);

        time %= 1.0f;

        Text text = GetComponent<Text>();
        text.text = (h + " : " + m + " : " + s);
    }
}
