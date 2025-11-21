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
    private float vlashnost;
    private int magVospriim;
    private int tverdost;
    private List<string> PlotnostZnach;
    private string plotnost;
    public static bool can = true;

    private void Start()
    {
        vlashnost = Random.Range(0f, 1f);
        magVospriim = Random.Range(0, 160);
        PlotnostZnach = new List<string>{"1", "2", "3", "3a", "4", "4a", "5", "5a", "6", "6a", "7"};
        plotnost = PlotnostZnach[Random.Range(0, 11)];
    }
    void Update()
    {
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit Hit, pickUpDistance, pickUpLayerMask))
        {

            if (stones.poloshili)
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
                            }
                            if (PlayerPickUpDrop.WhatHolding == "тру палка ковырялка")
                            {
                                TextOnPalka.text = vlashnost.ToString("F1");
                            }
                            if (PlayerPickUpDrop.WhatHolding == "плотностьь")
                            {
                                TextOnPlot.text = plotnost;
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
                if (PlayerPickUpDrop.WhatHolding == "Марганец" || PlayerPickUpDrop.WhatHolding == "Марганецц(Clone)") tverdost = 6;
                if (PlayerPickUpDrop.WhatHolding == "Халькопирит" || PlayerPickUpDrop.WhatHolding == "Халькопиритт(Clone)") tverdost = 1;
                F.SetActive(true);
                if (Input.GetKeyUp(KeyCode.F))
                {
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
            else F.SetActive(false);
        }
        else
        {
            F.SetActive(false);
            E.SetActive(false);
        }
    }
    private void end()
    {
        Inform.SetActive(false);
        can = true;
    }
}
