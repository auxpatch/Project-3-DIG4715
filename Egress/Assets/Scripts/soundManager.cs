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
    //public Toggle toggle;

    public AudioSrc[] music, sfx, musicLoop;
    //public AudioClip[] musicClip;
    public AudioSource musicSource, sfxSource, musicLoopSource;

    //private string lastScene;

    private void Awake()
    {

        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        else
        {
            Destroy(gameObject);
        }

        //retrieves the name of the scene
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Start is called before the first frame update
    void Start()
    {
        //PlayMusic("Level1");
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

    /*void changeSong()
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
    }*/

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

    public void PlayMusicLoop(string name)
    {
        AudioSrc s = Array.Find(musicLoop, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Music not found.");
        }

        else
        {
            musicLoopSource.clip = s.clip;
            musicLoopSource.Play();
        }

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

    /*void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        // Replacement variable (doesn't change the original audio source)
        AudioSource source = new AudioSource();

        // Plays different music in different scenes
        switch (scene.name)
        {
            case "Start Screen":
                source.Stop();
                musicSource.clip = PlayMusic("Menu");
                source.loop = toggle.isOn;
                break;
            case "Hub World":
                source.Stop();
                source.clip = musicClip[1];
                source.loop = toggle.isOn;
                break;
            default:
                source.Stop();
                source.clip = musicClip[2];
                break;
        }

        // Only switch the music if it changed
        if (source.clip != musicSource.clip)
        {
            musicSource.enabled = false;
            musicSource.clip = source.clip;
            musicSource.enabled = true;
        }
    }*/
    public void toggleMusic()
    {
        musicSource.mute = !musicSource.mute;
        musicLoopSource.mute = !musicLoopSource.mute;
    }

    public void toggleSfx()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void ChangeMusic(float volume)
    {
        musicSource.volume = volume;
        musicLoopSource.volume = volume;
   
    }

    public void ChangeSfx(float volume)
    {
        sfxSource.volume = volume;
   
    }
 
}
