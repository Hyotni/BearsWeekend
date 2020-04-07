using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSetting : MonoBehaviour {

    public GameObject Panel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPanel()
    {
        Panel.SetActive(true);
    }

    public void OffPanel()
    {
        Panel.SetActive(false);
    }
}
