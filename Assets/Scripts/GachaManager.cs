using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
using Random = System.Random;

public class GachaManager : MonoBehaviour
{
    [Header("Drop Rates")]
    [SerializeField] int threeStarRate;
    [SerializeField] int fourStarRate;


    [Header("Banner")]
    private int activeBannerID;
    private BannerObject activeBanner; 
    private List<GroceryItem> activeThreeStars;
    private List<GroceryItem> activeFourStars;
    private List<GroceryItem> activeFiveStars;

    private int[] pullsSinceLastFourStarPerBanner = {0,0,0,0,0,0,0};
    private int[] pullsSinceLastFiveStarPerBanner = {0,0,0,0,0,0,0};
    private int[] totalPullsPerBanner = {0,0,0,0,0,0,0};


    [Header("Random Number Generator")]
    Random rnd = new System.Random();
    Random rnd4 = new System.Random();
    Random rnd5 = new System.Random();


    int pullsSinceLastFourStar = 0;
    int pullsSinceLastFiveStar = 0;
    int lastFiveStarID = -1;
    int totalPullsOnBanner = 0;


    List<Sprite> splashImagesQueue = new List<Sprite>();
    List<Sprite> splashBGQueue = new List<Sprite>();


    [Header("Gameplay")]
    [SerializeField] int tokens = 150;
    

    public void SetActiveBanner(BannerObject bannerName, int index) 
    {
        activeBanner = bannerName;
        activeBannerID = index;
        
        activeThreeStars = activeBanner.GetThreeStarsList();
        activeFourStars = activeBanner.GetFourStarsList();
        activeFiveStars = activeBanner.GetFiveStarsList();

        pullsSinceLastFourStar = pullsSinceLastFourStarPerBanner[index];
        pullsSinceLastFiveStar = pullsSinceLastFiveStarPerBanner[index];
        totalPullsOnBanner = totalPullsPerBanner[index];

        Debug.Log("Active Banner: " + activeBanner.bannerName);
        Debug.Log("Active Banner ID: " + activeBannerID);
        Debug.Log("Four Star Pity: " + pullsSinceLastFourStar);
        Debug.Log("Five Star Pity: " + pullsSinceLastFiveStar);
    }

    public void OnePull() 
    {
        tokens--;
        
        int probability = rnd.Next(100);
        Debug.Log("Probability is: " + probability);

        /* PITY: If there have been 24 pulls since the last five star, the next pull will be a five star
        * OR
        * The roll lands in the top 5 percentile
        */
        if (pullsSinceLastFiveStar >= 24 || probability > (threeStarRate + fourStarRate))
        {
            pullsSinceLastFiveStar = 0;
            pullsSinceLastFourStar++;
            FiveStarPicker();
        }
        /* PITY: If there have been 4 pulls since the last four star, the next pull will be a four star
        * OR
        * The roll lands in the top 40 percentile
        */
        else if (pullsSinceLastFourStar >= 4 || probability > threeStarRate)
        {
            pullsSinceLastFourStar = 0;
            pullsSinceLastFiveStar++;
            FourStarPicker();
        }
        /* ELSE, the roll lands in the 60 percentile*/
        else
        {
            ThreeStarPicker();
            pullsSinceLastFourStar++;
            pullsSinceLastFiveStar++;
        }

        pullsSinceLastFourStarPerBanner[activeBannerID] = pullsSinceLastFourStar;
        pullsSinceLastFiveStarPerBanner[activeBannerID] = pullsSinceLastFiveStar;
        totalPullsPerBanner[activeBannerID] = totalPullsOnBanner++;
    }

    public void FivePull()
    {
        for (int i = 0; i < 5; i++)
        {
            OnePull();
        }
    }

    private void ThreeStarPicker()
    {
        Debug.Log(activeThreeStars[0].itemName);
        DisplaySplashImage(activeThreeStars, 0);

        // Add to bag
    }

    private void FourStarPicker()
    {
        pullsSinceLastFourStar = 0;
            
        int prob4 = rnd4.Next(activeFourStars.Count);
        Debug.Log(activeFourStars[prob4]);

        DisplaySplashImage(activeFourStars, prob4);

        // Add to bag
    }

    private void FiveStarPicker()
    {
        if (lastFiveStarID == -1)
        {
            int prob5 = rnd5.Next(activeFiveStars.Count);
            lastFiveStarID = prob5;
            //Debug.Log("prob5 = " + prob5);
            Debug.Log(activeFiveStars[prob5]);

            DisplaySplashImage(activeFiveStars, prob5);
        }
        else if (lastFiveStarID == 0)
        {
            lastFiveStarID = 1;
            Debug.Log(activeFiveStars[lastFiveStarID]);

            DisplaySplashImage(activeFiveStars, lastFiveStarID);
        }
        else if (lastFiveStarID == 1)
        {
            lastFiveStarID = 0;
            Debug.Log(activeFiveStars[lastFiveStarID]);

            DisplaySplashImage(activeFiveStars, lastFiveStarID);
        }

        // Add to bag
    }

    private void DisplaySplashImage(List<GroceryItem> groceryItemList, int index)
    {
        GroceryItem itemWon = groceryItemList[index];

        Sprite splashBG = itemWon.GetItemBG();
        Sprite displayImage = itemWon.GetItemImage();

        splashImagesQueue.Add(displayImage);
        splashBGQueue.Add(splashBG);
    }

    public List<Sprite> GetSplashImageList()
    {
        return splashImagesQueue;
    }

    public List<Sprite> GetSplashBGList()
    {
        return splashBGQueue;
    }

    public int GetTokenCount()
    {
        return tokens;
    }

    public void ResetSplashImageList()
    {
        splashImagesQueue.Clear();
    }

    public void ResetSplashBGList()
    {
        splashBGQueue.Clear();
    }
}
