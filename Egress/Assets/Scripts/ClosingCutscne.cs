using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ClosingCutscene : MonoBehaviour
{
    public GameObject Camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(TheSequence2());

    }

    IEnumerator TheSequence2 () {
        yield return new WaitForSeconds(12.34f);
        SceneManager.LoadScene("Winscreen");
    }
    

}
