using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    bool hasTriggered;


    // Update is called once per frame
    void LoadPlayScene()
    {
        if (!hasTriggered)
        {
            SceneManager.LoadScene("Pull Screen");
            hasTriggered = true;
        }
    }

    void LoadMenuScene()
    {
        if (! hasTriggered)
        {
            SceneManager.LoadScene("Main Menu");
            hasTriggered = true;
        }
    }
}
