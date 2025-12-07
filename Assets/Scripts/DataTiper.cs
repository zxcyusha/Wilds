using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataTiper : MonoBehaviour
{
    public static bool needAnimating = true;
    public static string TimeSave1;
    public static string TimeSave2;
    public static string TimeSave3;
    public static DataTiper Instance { get; private set; }

    //private void Awake()
    //{
    //    if (Instance == null)
    //    {
    //        Instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }


    //}

    //public void Update()
    //{
    //    Debug.Log(needAnimating);
    //}

    //public void SetAnimating(bool need)
    //{
    //    needAnimating = need;
    //}
}
