using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time_Check : MonoBehaviour {


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string time;
        time = DateTime.Now.ToString("MM.dd");

        Text text = GetComponent<Text>();
        text.text = time;
    }


   
}
