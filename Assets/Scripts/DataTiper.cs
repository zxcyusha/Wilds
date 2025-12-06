using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTiper : MonoBehaviour
{
    public static bool needAnimating = true;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void SetAnimating(bool need)
    {
        needAnimating = need;
    }
}
