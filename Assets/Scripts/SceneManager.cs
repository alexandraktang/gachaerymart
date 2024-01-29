using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadButtonManager : MonoBehaviour
{
    bool hasTriggered;


    // Update is called once per frame
    public void LoadPlayScene()
    {
        if (!hasTriggered)
        {
            SceneManager.LoadScene("Pull Screen");
            hasTriggered = true;
        }
    }

    public void LoadMenuScene()
    {
        if (! hasTriggered)
        {
            SceneManager.LoadScene("Main Menu");
            hasTriggered = true;
        }
    }
}
