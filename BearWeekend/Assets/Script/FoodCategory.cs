using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCategory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("storeType", "Food");
        PlayerPrefs.SetString("itemCategory", "Normal");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
