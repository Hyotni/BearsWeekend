using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundController:MonoBehaviour {

    public GameObject EMusic;

    public void PlayClickMusic()
    {
        EMusic.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("EMusic/Click");
        EMusic.GetComponent<AudioSource>().Play();
    }

    public void PlayEatMusic()
    {
        EMusic.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("EMusic/Bite");
        EMusic.GetComponent<AudioSource>().Play();
    }
    
    void DestroyEMusicObject()
    {
        Destroy(EMusic);
    }

    string sceneName;

    void Start()
    {
        if(sceneName == null)
        {
            sceneName = SceneManager.GetActiveScene().name;
        }

        if (sceneName != SceneManager.GetActiveScene().name)
        {
            Debug.Log(sceneName + SceneManager.GetActiveScene().name);
            Invoke("DestroyEMusicObject", 0.3f);
        }

        DontDestroyOnLoad(EMusic);
    }

    private void Update()
    {
        
    }
}
