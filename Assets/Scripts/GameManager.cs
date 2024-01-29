using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Managers")]
    //[SerializeField] BannerManager bannerManager;
    [SerializeField] GachaManager gachaManager;

    [Header("Active")]
    [SerializeField] BannerObject activeBanner; // set to Vegetables by default in Inspector
    [SerializeField] List<BannerObject> bannerObjectsList;
    [SerializeField] List<Sprite> bannerImagesList;

    [Header("Screen Objects")]
    [SerializeField] GameObject pullScreenObject;
    [SerializeField] GameObject splashScreenObject;
    [SerializeField] GameObject bannerButtonsObject;
    [SerializeField] GameObject pullButtonsObject;
    [SerializeField] GameObject bannerImageObject;
    [SerializeField] GameObject numOfTokensObject;
    [SerializeField] GameObject outOfTokensScreen;
    [SerializeField] GameObject instructionsPanelObject;

    List<Sprite> splashImagesQueue;
    List<Sprite> splashBGQueue;
    [SerializeField] int queueIterator = 0;

    void Start()
    {
        DisableBannerButtons();
        DisablePullButtons();
        
        pullScreenObject.SetActive(true);
        instructionsPanelObject.SetActive(true);
        splashScreenObject.SetActive(false);
        gachaManager.SetActiveBanner(activeBanner, 0); // default 0 for Vegetables

        bannerImageObject.GetComponent<Image>().sprite = bannerImagesList[0];
    }

    public void SetActiveBanner(int index)
    {
        //Debug.Log("Index is: " + index);
        
        activeBanner = bannerObjectsList[index];
        bannerImageObject.GetComponent<Image>().sprite = bannerImagesList[index];
        gachaManager.SetActiveBanner(activeBanner, index);
    }

    public void DisablePullScreen()
    {
        pullScreenObject.SetActive(false);
    }

    public void EnablePullScreen()
    {
        pullScreenObject.SetActive(true);
        int numOfTokens = gachaManager.GetTokenCount();
        numOfTokensObject.GetComponent<TMP_Text>().text = numOfTokens.ToString();

        if (numOfTokens <= 0)
        {
            DisablePullButtons();
            DisableBannerButtons();
            outOfTokensScreen.SetActive(true);
        }
        else if (numOfTokens < 5)
        {
            Disable5PullButton();
        }
    }

    public void DisableSplashScreen()
    {
        splashScreenObject.SetActive(false);
    }

    public void EnableSplashScreen()
    {
        splashScreenObject.SetActive(true);
        
        DisplaySplashImage();
    }

    private void DisplaySplashImage() 
    {
        splashBGQueue = gachaManager.GetSplashBGList();
        splashImagesQueue = gachaManager.GetSplashImageList();

        splashScreenObject.GetComponent<Image>().sprite = splashBGQueue[queueIterator];
        splashScreenObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = splashImagesQueue[queueIterator];

        if (splashImagesQueue.Count > 1)
        {
            splashScreenObject.transform.GetChild(2).gameObject.SetActive(true); // enables arrow button
            queueIterator++;
        }
    }

    public void DisplayNextSplashImage()
    {
        if (queueIterator == splashImagesQueue.Count - 1)
        {
            splashScreenObject.transform.GetChild(2).gameObject.SetActive(false); // disables arrow button
        }
        splashScreenObject.GetComponent<Image>().sprite = splashBGQueue[queueIterator];
        splashScreenObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = splashImagesQueue[queueIterator];
        queueIterator++;
    }

    public void ClearSplashQueues()
    {
        splashBGQueue.Clear();
        splashImagesQueue.Clear();

        gachaManager.ResetSplashBGList();
        gachaManager.ResetSplashImageList();

        queueIterator = 0;
    }

    private void DisableBannerButtons()
    {
        Button[] childList = bannerButtonsObject.GetComponentsInChildren<Button>();
        foreach (Button child in childList)
        {
            child.interactable = false;
        }
    }

    private void DisablePullButtons()
    {
        Button[] childList = pullButtonsObject.GetComponentsInChildren<Button>();
        foreach (Button child in childList)
        {
            child.interactable = false;
        }
    }

    private void Disable5PullButton()
    {
        Button[] childList = pullButtonsObject.GetComponentsInChildren<Button>();
        childList[1].interactable = false;
    }

    public void EnableBannerButtons()
    {
        Button[] childList = bannerButtonsObject.GetComponentsInChildren<Button>();
        foreach (Button child in childList)
        {
            child.interactable = true;
        }
    }

    public void EnablePullButtons()
    {
        Button[] childList = pullButtonsObject.GetComponentsInChildren<Button>();
        foreach (Button child in childList)
        {
            child.interactable = true;
        }
    }
}
