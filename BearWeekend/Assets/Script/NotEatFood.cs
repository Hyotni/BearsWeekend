using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotEatFood : MonoBehaviour {

    public GameObject Panel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /**
     * 먹지 않음
     */

    public void NoEat()
    {
        Panel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
