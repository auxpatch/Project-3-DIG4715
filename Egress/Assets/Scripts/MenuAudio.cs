using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        soundManager.Instance.musicLoopSource.Stop();
        soundManager.Instance.musicSource.Stop();
        soundManager.Instance.PlayMusicLoop("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
