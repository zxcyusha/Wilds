using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FirstRoom : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private float pickUpDistance = 4f;
    [SerializeField] private Stones stones;
    [SerializeField] private GameObject F;
    [SerializeField] private GameObject F1;
    [SerializeField] private GameObject F2;
    [SerializeField] private GameObject E;
    [SerializeField] private GameObject Inform;
    [SerializeField] private TextMeshProUGUI TextOnMag;
    [SerializeField] private TextMeshProUGUI TextOnPalka;
    [SerializeField] private TextMeshProUGUI TextOnPlot;
    [SerializeField] private GameObject Ruka;
    [SerializeField] private GameObject boksit;
    [SerializeField] private GameObject gematit;
    [SerializeField] private GameObject kuprit;
    [SerializeField] private GameObject marganec;
    [SerializeField] private GameObject halkopirit;
    [SerializeField] private AudioSource Chik;
    private float vlashnost;
    private int magVospriim;
    private int tverdost;
    private List<string> PlotnostZnach;
    private string plotnost;
    private float sostav;
    public static bool can = true;
    public static bool can1 = true;
    public static int R1;
    public static int R2;
    public static int R3;
    public static int R4;
    public static int R5;

    private void Start()
    {
        RandomZnach();
    }
    void Update()
    {
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit Hit, pickUpDistance, pickUpLayerMask))
        {

            if (Stones.poloshili)
            {
                if (PlayerPickUpDrop.WhatHolding == "рыжая лейка для душа" || PlayerPickUpDrop.WhatHolding == "тру палка ковырялка" || PlayerPickUpDrop.WhatHolding == "плотностьь")
                {
                    if (Hit.collider.CompareTag("kamen"))
                    {
                        F.SetActive(true);
                        if (Input.GetKeyDown(KeyCode.F))
                        {
                            if (PlayerPickUpDrop.WhatHolding == "рыжая лейка для душа")
                            {
                                TextOnMag.text = magVospriim.ToString();
                                Chik.Play();
                            }
                            if (PlayerPickUpDrop.WhatHolding == "тру палка ковырялка")
                            {
                                TextOnPalka.text = vlashnost.ToString("F1");
                                Chik.Play();
                            }
                            if (PlayerPickUpDrop.WhatHolding == "плотностьь")
                            {
                                TextOnPlot.text = plotnost;
                                Chik.Play();
                            }
                        }
                    }
                    else F.SetActive(false);
                }
                else
                {
                    if (Hit.collider.CompareTag("kamen"))
                    {
                        E.SetActive(true);
                        if (Input.GetKeyDown(KeyCode.E))
                        {

                            if (Hit.collider.gameObject.name == "Боксит")
                            {
                                GameObject kamen = Instantiate(boksit, Ruka.transform.position, Quaternion.identity);
                                PlayerPickUpDrop.objectGrabbable = kamen.GetComponent<ObjectGrabbable>();
                                PlayerPickUpDrop.objectGrabbable.Grab(Ruka);
                                PlayerPickUpDrop.WhatHolding = "Боксит";
                            }
                            else if (Hit.collider.gameObject.name == "Гематит")
                            {
                                GameObject kamen = Instantiate(gematit, Ruka.transform.position, Quaternion.identity);
                                PlayerPickUpDrop.objectGrabbable = kamen.GetComponent<ObjectGrabbable>();
                                PlayerPickUpDrop.objectGrabbable.Grab(Ruka);
                                PlayerPickUpDrop.WhatHolding = "Гематит";
                            }
                            else if (Hit.collider.gameObject.name == "Куприт")
                            {
                                GameObject kamen = Instantiate(kuprit, Ruka.transform.position, Quaternion.identity);
                                PlayerPickUpDrop.objectGrabbable = kamen.GetComponent<ObjectGrabbable>();
                                PlayerPickUpDrop.objectGrabbable.Grab(Ruka);
                                PlayerPickUpDrop.WhatHolding = "Куприт";
                            }
                            else if (Hit.collider.gameObject.name == "Марганец")
                            {
                                GameObject kamen = Instantiate(marganec, Ruka.transform.position, Quaternion.identity);
                                PlayerPickUpDrop.objectGrabbable = kamen.GetComponent<ObjectGrabbable>();
                                PlayerPickUpDrop.objectGrabbable.Grab(Ruka);
                                PlayerPickUpDrop.WhatHolding = "Марганец";
                            }
                            else if (Hit.collider.gameObject.name == "Халькопирит")
                            {
                                GameObject kamen = Instantiate(halkopirit, Ruka.transform.position, Quaternion.identity);
                                PlayerPickUpDrop.objectGrabbable = kamen.GetComponent<ObjectGrabbable>();
                                PlayerPickUpDrop.objectGrabbable.Grab(Ruka);
                                PlayerPickUpDrop.WhatHolding = "Халькопирит";
                            }
                        }
                    }
                    else E.SetActive(false);
                }
            }

            if (Hit.collider.CompareTag("Tverdost") && (PlayerPickUpDrop.WhatHolding == "Халькопирит" || PlayerPickUpDrop.WhatHolding == "Халькопиритт(Clone)" || PlayerPickUpDrop.WhatHolding == "Боксит" || PlayerPickUpDrop.WhatHolding == "Бокситт(Clone)" || PlayerPickUpDrop.WhatHolding == "Гематит" || PlayerPickUpDrop.WhatHolding == "Гематитт(Clone)" || PlayerPickUpDrop.WhatHolding == "Куприт" || PlayerPickUpDrop.WhatHolding == "Купритт(Clone)" || PlayerPickUpDrop.WhatHolding == "Марганец" || PlayerPickUpDrop.WhatHolding == "Марганецц(Clone)"))
            {
                if (PlayerPickUpDrop.WhatHolding == "Боксит" || PlayerPickUpDrop.WhatHolding == "Бокситт(Clone)") tverdost = 5;
                if (PlayerPickUpDrop.WhatHolding == "Гематит" || PlayerPickUpDrop.WhatHolding == "Гематитт(Clone)") tverdost = 4;
                if (PlayerPickUpDrop.WhatHolding == "Куприт" || PlayerPickUpDrop.WhatHolding == "Купритт(Clone)") tverdost = 6;
                if (PlayerPickUpDrop.WhatHolding == "Марганец" || PlayerPickUpDrop.WhatHolding == "Марганецц(Clone)") tverdost = 1;
                if (PlayerPickUpDrop.WhatHolding == "Халькопирит" || PlayerPickUpDrop.WhatHolding == "Халькопиритт(Clone)") tverdost = 7;
                R3 = tverdost;
                F1.SetActive(true);
                if (Input.GetKeyUp(KeyCode.F))
                {
                    Chik.Play();
                    Inform.GetComponent<TextMeshProUGUI>().text = "Твёрдость породы:" + tverdost.ToString();
                    Inform.SetActive(true);
                    GameObject obj = Ruka.transform.GetChild(0).gameObject;
                    Destroy(obj);
                    PlayerPickUpDrop.objectGrabbable = null;
                    PlayerPickUpDrop.WhatHolding = "0";
                    Invoke("end", 3f);
                    can = false;
                }
            }
           else F1.SetActive(false);

            if (Hit.collider.CompareTag("Sostav") && (PlayerPickUpDrop.WhatHolding == "Халькопирит" || PlayerPickUpDrop.WhatHolding == "Халькопиритт(Clone)" || PlayerPickUpDrop.WhatHolding == "Боксит" || PlayerPickUpDrop.WhatHolding == "Бокситт(Clone)" || PlayerPickUpDrop.WhatHolding == "Гематит" || PlayerPickUpDrop.WhatHolding == "Гематитт(Clone)" || PlayerPickUpDrop.WhatHolding == "Куприт" || PlayerPickUpDrop.WhatHolding == "Купритт(Clone)" || PlayerPickUpDrop.WhatHolding == "Марганец" || PlayerPickUpDrop.WhatHolding == "Марганецц(Clone)"))
            {
                F2.SetActive(true);
                if (Input.GetKeyUp(KeyCode.F))
                {
                    Chik.Play();
                    Inform.GetComponent<TextMeshProUGUI>().text = "Гранулометрический состав породы: " + sostav.ToString("F1");
                    Inform.SetActive(true);
                    GameObject obj = Ruka.transform.GetChild(0).gameObject;
                    Destroy(obj);
                    PlayerPickUpDrop.objectGrabbable = null;
                    PlayerPickUpDrop.WhatHolding = "0";
                    Invoke("end", 3f);
                    can1 = false;
                }

            }
            else F2.SetActive(false);
        }
        else
        {
            F.SetActive(false);
            F1.SetActive(false);
            F2.SetActive(false);
            E.SetActive(false);
        }
    }
    private void end()
    {
        Inform.SetActive(false);
        can = true;
        can1 = true;
    }

    public void RandomZnach()
    {
        vlashnost = Random.Range(0f, 1f);
        if (vlashnost < 0.1f) vlashnost = 0.1f;
        if (vlashnost > 0.9f) vlashnost = 0.9f;
        magVospriim = Random.Range(0, 160);
        PlotnostZnach = new List<string> { "1", "2", "3", "3a", "4", "4a", "5", "6", "6a", "7" };
        plotnost = PlotnostZnach[Random.Range(0, 10)];
        List<float> SostavZnach = new List<float> { Random.Range(0.05f, 0.1f), Random.Range(1f, 2f), Random.Range(5f, 10f), Random.Range(100f, 200f), Random.Range(501f, 600f) };
        sostav = SostavZnach[Random.Range(0, 4)];

        if (magVospriim <= 29) R1 = 1;
        else if (magVospriim >= 30 && magVospriim <= 59) R1 = 2;
        else if (magVospriim >= 60 && magVospriim <= 119) R1 = 3;
        else if (magVospriim >= 120 && magVospriim <= 160) R1 = 4;

        if (plotnost == "1" || plotnost == "2") R2 = 1;
        else if (plotnost == "3") R2 = 12;
        else if (plotnost == "3a" || plotnost == "4") R2 = 2;
        else if (plotnost == "4a") R2 = 23;
        else if (plotnost == "5") R2 = 3;
        else if (plotnost == "6a") R2 = 34;
        else if (plotnost == "7") R2 = 4;

        if (sostav >= 0.05f && sostav <= 0.1) R4 = 5;
        if (sostav >= 1f && sostav <= 2) R4 = 4;
        if (sostav >= 5f && sostav <= 10) R4 = 3;
        if (sostav >= 100f && sostav <= 200) R4 = 2;
        if (sostav >= 501f && sostav <= 600) R4 = 1;

        if (vlashnost >= 0 && vlashnost < 0.5) R5 = 1;
        else if (vlashnost >= 0.5 && vlashnost < 0.8) R5 = 2;
        else if (vlashnost >= 0.8 && vlashnost <= 1) R5 = 3;
    }
}
