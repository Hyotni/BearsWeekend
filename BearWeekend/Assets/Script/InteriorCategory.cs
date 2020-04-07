using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteriorCategory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("storeType", "Interior");
        PlayerPrefs.SetString("itemCategory", "LivingRoom");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowLivingRoom()
    {
        PlayerPrefs.SetString("itemCategory", "LivingRoom");
    }

    public void ShowHobbyRoom()
    {
        PlayerPrefs.SetString("itemCategory", "HobbyRoom");
    }

    public void ShowDressRoom()
    {
        PlayerPrefs.SetString("itemCategory", "DressRoom");
    }

    public void ShowBedRoom()
    {
        PlayerPrefs.SetString("itemCategory", "BedRoom");
    }
}
