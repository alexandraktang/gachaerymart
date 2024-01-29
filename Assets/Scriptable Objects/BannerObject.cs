using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Scriptable Objects/Banner Object")]
public class BannerObject : ScriptableObject
{
    public String bannerName = "";
    public int pullsSinceLastFourStar = 0;
    public int pullsSinceLastFiveStar = 0;
    public int lastFiveStarID = -1;
    public int totalNumPullsOnBanner = 0;

    
    [SerializeField] List<GroceryItem> threeStars = new List<GroceryItem>();
    [SerializeField] List<GroceryItem> fourStars = new List<GroceryItem>();
    [SerializeField] List<GroceryItem> fiveStars = new List<GroceryItem>();

    public List<GroceryItem> GetThreeStarsList() 
    {
        return threeStars;
    }

    public List<GroceryItem> GetFourStarsList() 
    {
        return fourStars;
    }

    public List<GroceryItem> GetFiveStarsList() 
    {
        return fiveStars;
    }
}
