using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class soundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    public static soundManager Instance;

    public AudioSrc[] music, sfx;
    public AudioSource musicSource, sfxSource;

    private string lastScene;

    private void Awake()
    {
        //retrieves the name of the scene
        lastScene = SceneManager.GetActiveScene().name;

        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayMusic("Level1");
    }

    void Update()
    {
        var currentScene = SceneManager.GetActiveScene().name;
        /*if(currentScene != lastScene) 
        {
            lastScene = currentScene;
            changeSong();
        }*/

    }

    void changeSong()
    {
        if(lastScene == "Hub World")
        {
            //AudioSource.PlayOneShot (hubLoop, 0.4f);
        }
        else if(lastScene == "Light Room")
        {
            musicSource.Stop();
            PlayMusic("Level1");
        }
    }

    public void PlayMusic(string name)
    {
        AudioSrc s = Array.Find(music, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Music not found.");
        }

        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }

    }
   

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
   
    }

    //finds and plays sound effects
    public void PlaySFX(string name)
    {
        AudioSrc s = Array.Find(sfx, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not found.");
        }

        else
        {
            sfxSource.PlayOneShot(s.clip);
        }

    }
 
}
