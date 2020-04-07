using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScreenSize : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Screen.SetResolution(Screen.width, Screen.width/ 9*16, false);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
