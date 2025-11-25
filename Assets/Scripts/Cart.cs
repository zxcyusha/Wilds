 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cart : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private float pickUpDistance = 4f;
    [SerializeField] private GameObject telText;
    [SerializeField] private GameObject F;
    [SerializeField] private GameObject E;
    [SerializeField] private Material color;
    [SerializeField] private Texture Boksit;
    [SerializeField] private Texture Gematit;
    [SerializeField] private Texture Kuprit;
    [SerializeField] private Texture Marganec;
    [SerializeField] private Texture Halkopirit;
    [SerializeField] private GameObject napolnenie;
    [SerializeField] private GameObject Ruka;
    [SerializeField] private GameObject List;
    [SerializeField] private GameObject Teleshka;
    [SerializeField] private GameObject prikrepiList;
    [SerializeField] private GameObject tolkniTel;
    private Animator animator;
    private ObjectGrabbable objectGrabbable;
    private bool napolnili = false;
    private bool prikrepiliList = false;
    private int count = 0;
    public bool TELESKI = true;
    public static bool OTPRAVILI = false;
    public static bool PRAVILNOOTVETIL;

    private void Start()
    {
        objectGrabbable = List.GetComponent<ObjectGrabbable>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        ProverkaPravilnosti();
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit Hit, pickUpDistance, pickUpLayerMask))
        {
            if (Hit.collider.CompareTag("Teleshka"))
            {
                if (PlayerPickUpDrop.WhatHolding == "Боксит" || PlayerPickUpDrop.WhatHolding == "Гематит" || PlayerPickUpDrop.WhatHolding == "Куприт" || PlayerPickUpDrop.WhatHolding == "Халькопирит" || PlayerPickUpDrop.WhatHolding == "Марганец" || PlayerPickUpDrop.WhatHolding == "Бокситт(Clone)" || PlayerPickUpDrop.WhatHolding == "Гематитт(Clone)" || PlayerPickUpDrop.WhatHolding == "Купритт(Clone)" || PlayerPickUpDrop.WhatHolding == "Халькопиритт(Clone)" || PlayerPickUpDrop.WhatHolding == "Марганецц(Clone)")
                {
                    F.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.F) && count <= 6)
                    {
                        napolnenie.SetActive(true);
                        if (PlayerPickUpDrop.WhatHolding == "Боксит" || PlayerPickUpDrop.WhatHolding == "Бокситт(Clone)") color.SetTexture("_MainTex", Boksit);
                        if (PlayerPickUpDrop.WhatHolding == "Гематит" || PlayerPickUpDrop.WhatHolding == "Гематитт(Clone)") color.SetTexture("_MainTex", Gematit);
                        if (PlayerPickUpDrop.WhatHolding == "Куприт" || PlayerPickUpDrop.WhatHolding == "Купритт(Clone)") color.SetTexture("_MainTex", Kuprit);
                        if (PlayerPickUpDrop.WhatHolding == "Халькопирит" || PlayerPickUpDrop.WhatHolding == "Халькопиритт(Clone)") color.SetTexture("_MainTex", Halkopirit);
                        if (PlayerPickUpDrop.WhatHolding == "Марганец" || PlayerPickUpDrop.WhatHolding == "Марганецц(Clone)") color.SetTexture("_MainTex", Marganec);
                        napolnenie.transform.localPosition = new Vector3(napolnenie.transform.localPosition.x, napolnenie.transform.localPosition.y + 0.07f, napolnenie.transform.localPosition.x);
                        GameObject obj = Ruka.transform.GetChild(0).gameObject;
                        Destroy(obj);
                        PlayerPickUpDrop.objectGrabbable = null;
                        PlayerPickUpDrop.WhatHolding = "0";
                        count++;
                        if (count == 6) napolnili = true;
                    }
                    
                }

                else if (PlayerPickUpDrop.WhatHolding == "лист")
                {
                    E.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        objectGrabbable.Drop();
                        List.transform.SetParent(Teleshka.transform);
                        List.GetComponent<Rigidbody>().isKinematic = true;
                        PlayerPickUpDrop.objectGrabbable = null;
                        PlayerPickUpDrop.WhatHolding = "0";
                        List.transform.localPosition = new Vector3(-0.621f, 0.585f, -0.011f);
                        List.transform.localRotation = Quaternion.Euler(-90.287f, 90f, -90f);
                        List.transform.localScale = new Vector3(0.099f, 15.116f, 26.42f);
                        E.SetActive(false);
                        prikrepiliList = true;
                    }
                }

                else
                {
                    if (!napolnili && TELESKI)
                    {
                        telText.SetActive(true);
                        F.SetActive(false);
                    }
                }

                if (count > 5)
                {
                    if (!prikrepiliList && !E.activeInHierarchy)
                    {
                        prikrepiList.SetActive(true);
                    }
                    else if (prikrepiliList && !OTPRAVILI)
                    {
                        tolkniTel.SetActive(true);
                        if (Vector3.Distance(playerCameraTransform.position, Teleshka.transform.position) <= 2f)
                        {
                            animator.SetBool("Array", true);
                            OTPRAVILI = true;
                        }
                    }
                    F.SetActive(false);
                }

            }
            else
            {
                telText.SetActive(false);
                F.SetActive(false);
                E.SetActive(false);
                prikrepiList.SetActive(false);
                tolkniTel.SetActive(false);
            }
        }
        else
        {
            telText.SetActive(false);
            F.SetActive(false);
            E.SetActive(false);
            prikrepiList.SetActive(false);
            tolkniTel.SetActive(false);
        }
    }

    private bool ProverkaPravilnosti()
    {
        if ((FirstRoom.R1 == TakeListok.rightMAG) && (FirstRoom.R2 == TakeListok.rightPLOT) && (FirstRoom.R3 == TakeListok.rightTVERD) && (FirstRoom.R4 == TakeListok.rightSOSTAV) && (FirstRoom.R5 == TakeListok.rightVLASH))
        {
            return true;
        }
        else return false;
    }

}