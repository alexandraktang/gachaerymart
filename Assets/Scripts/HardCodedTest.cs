using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = System.Random;

public class HardCodedTest : MonoBehaviour
{
    int threeStarRate = 60;
    int fourStarRate = 35;
    int fiveStarRate = 5;

    List<string> threeStars = new List<string>() {"Cabbage"};
    List<string> fourStars = new List<string>() {"Eggplant", "Bell Peppers", "Broccoli"};
    List<string> fiveStars = new List<string>() {"Pink Lettuce", "24 Pack Toilet Paper"};

    Random rnd = new System.Random();
    Random rnd4 = new System.Random();
    Random rnd5 = new System.Random();

    int fourStarTracker = 0;
    int fiveStarTracker = 0;
    int lastFiveStar = -1;

    void Start()
    {
        Debug.Log("Five pull in process...");
        for (int i = 0; i < 5; i++)
        {
            OnePull();
        }
        Debug.Log("Thank you for shopping at the Gachery Mart.");
    }

    void OnePull()
    {
        int probability = rnd.Next(100);
        Debug.Log("Probability is: " + probability);

        if (fiveStarTracker >= 24 || probability > 95)
        {
            fiveStarTracker = 0;
            fourStarTracker++;
            FiveStarPicker();
        }
        else if (fourStarTracker >= 4 || probability > 60)
        {
            fourStarTracker = 0;
            fiveStarTracker++;
            FourStarPicker();
        }
        else
        {
            ThreeStarPicker();
            fourStarTracker++;
            fiveStarTracker++;
        }
    }

    void ThreeStarPicker()
    {
        Debug.Log("Cabbage!");
    }

    void FourStarPicker()
    {
        fourStarTracker = 0;
            
        int prob4 = rnd4.Next(fourStars.Count);
        Debug.Log("prob4 = " + prob4);
        Debug.Log(fourStars[prob4]);
    }

    void FiveStarPicker()
    {
        if (lastFiveStar == -1)
        {
            int prob5 = rnd5.Next(fiveStars.Count);
            lastFiveStar = prob5;
            Debug.Log("prob5 = " + prob5);
            Debug.Log(fiveStars[prob5]);
        }
        else if (lastFiveStar == 0)
        {
            lastFiveStar = 1;
            Debug.Log(fiveStars[lastFiveStar]);
        }
        else if (lastFiveStar == 1)
        {
            lastFiveStar = 0;
            Debug.Log(fiveStars[lastFiveStar]);
        }
    }

    
}
