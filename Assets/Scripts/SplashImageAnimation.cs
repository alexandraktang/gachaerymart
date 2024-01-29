using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class SplashImageAnimation : MonoBehaviour
{
    [SerializeField] Animator splashAnimator; 

    public void ShowSplashImage()
    {
        splashAnimator.SetBool("buttonPressed", true);
        StartCoroutine(TurnFadeFalse());
    }

    IEnumerator TurnFadeFalse() 
    {
        yield return new WaitForSeconds(1f);
        splashAnimator.SetBool("buttonPressed", false);
    }
}
