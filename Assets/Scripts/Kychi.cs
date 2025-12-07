using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ky : MonoBehaviour
{
    public GameObject Halk;
    public GameObject Boks;
    public GameObject Gematit;
    public GameObject Kuprit;
    void Start()
    {
        if (BurMachina.BoorSdelali && DAYS.DAY1) Halk.SetActive(true);
        else if (BurMachina.BoorSdelali && DAYS.DAY2) Boks.SetActive(true);
        else if (BurMachina.BoorSdelali && DAYS.DAY3) Halk.SetActive(true);
        else if (BurMachina.BoorSdelali && DAYS.DAY4) Gematit.SetActive(true);
        else if (BurMachina.BoorSdelali && DAYS.DAY5) Kuprit.SetActive(true);
    }

}
