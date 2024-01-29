using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public void GetButton()
    {
        GameObject gameManagerObject = GameObject.Find("Game Manager");

        if (gameManagerObject != null) 
        {
            GameManager gm = gameManagerObject.GetComponent<GameManager>();
            gm.SetActiveBanner(this.transform.GetSiblingIndex());
        }
        else
        {
            Debug.Log("ERROR: NO GAME MANAGER FOUND");
        }
    }
}
