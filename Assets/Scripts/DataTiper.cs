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
    public TextMeshProUGUI Slot1Time;
    public TextMeshProUGUI Slot2Time;
    public TextMeshProUGUI Slot3Time;
    public static DataTiper Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


    }


    public void SetAnimating(bool need)
    {
        needAnimating = need;
    }
}
