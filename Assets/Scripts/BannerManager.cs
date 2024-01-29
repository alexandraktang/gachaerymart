using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class BannerManager : MonoBehaviour
{
    [SerializeField] BannerObject activeBanner; // set to Vegetables by default in Inspector

    public BannerObject GetActiveBanner()
    {
        return activeBanner;
    }
}
