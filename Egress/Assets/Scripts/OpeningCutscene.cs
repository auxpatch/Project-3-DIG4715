using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class OpeningCutscene : MonoBehaviour
{
    public GameObject Camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(TheSequence());

    }

    IEnumerator TheSequence () {
        yield return new WaitForSeconds(9);
        SceneManager.LoadScene("Start Screen");
    }
    

}
