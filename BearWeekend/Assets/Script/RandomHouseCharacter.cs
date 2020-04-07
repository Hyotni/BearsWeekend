using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomHouseCharacter : MonoBehaviour {

    public GameObject Bear1;
    public GameObject Bear2;
    public GameObject Bear3;
    public GameObject Bear4;

    // Use this for initialization
    void Start () {

        Bear1.SetActive(false);
        Bear2.SetActive(false);
        Bear3.SetActive(false);
        Bear4.SetActive(false);

        int randomNum = 0;

        randomNum = Random.Range(1, 5);

        if (randomNum==1)
        {
            Bear1.SetActive(true);
            
        }
        else if (randomNum == 2)
        {
            Bear2.SetActive(true);
        }
        else if (randomNum == 3)
        {
            Bear3.SetActive(true);
        }
        else if (randomNum == 4)
        {
            Bear4.SetActive(true);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
