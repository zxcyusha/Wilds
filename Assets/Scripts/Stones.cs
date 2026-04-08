using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stones : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private float pickUpDistance = 4f;
    [SerializeField] private GameObject Boksit;
    [SerializeField] private GameObject Furrum;
    [SerializeField] private GameObject Kuprit;
    [SerializeField] private GameObject Halkopirit;
    [SerializeField] private GameObject Marganec;
    [SerializeField] private GameObject TakePosition;
    [SerializeField] private GameObject BoksitOnTable;
    [SerializeField] private GameObject FurrumOnTable;
    [SerializeField] private GameObject KupritOnTable;
    [SerializeField] private GameObject HalkopiritOnTable;
    [SerializeField] private GameObject MarganecOnTable;
    [SerializeField] private NewBehaviourScript scull;
    private GameObject boksit;
    private GameObject ferrum;
    private GameObject kuprit;
    private GameObject halkopirit;
    private GameObject marganec;
    public static bool poloshili = false;
    private int stoneCount;
    private bool scrimer = false;
    void Update()
    {
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit Hit, pickUpDistance, pickUpLayerMask))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                if (PlayerPickUpDrop.objectGrabbable == null)
                {
                    if (Hit.collider.CompareTag("Boksit"))
                    {
                        stoneCount += 1;
                        boksit = Instantiate(Boksit, TakePosition.transform.position, Quaternion.identity);
                        PlayerPickUpDrop.objectGrabbable = boksit.GetComponent<ObjectGrabbable>();
                        PlayerPickUpDrop.objectGrabbable.Grab(TakePosition);
                        PlayerPickUpDrop.WhatHolding = "Боксит";
                    }
                    if (Hit.collider.CompareTag("Ferrum"))
                    {
                        stoneCount += 1;
                        ferrum = Instantiate(Furrum, TakePosition.transform.position, Quaternion.identity);
                        PlayerPickUpDrop.objectGrabbable = ferrum.GetComponent<ObjectGrabbable>();
                        PlayerPickUpDrop.objectGrabbable.Grab(TakePosition);
                        PlayerPickUpDrop.WhatHolding = "Гематит";
                    }
                    if (Hit.collider.CompareTag("Kuprit"))
                    {
                        stoneCount += 1;
                        kuprit = Instantiate(Kuprit, TakePosition.transform.position, Quaternion.identity);
                        PlayerPickUpDrop.objectGrabbable = kuprit.GetComponent<ObjectGrabbable>();
                        PlayerPickUpDrop.objectGrabbable.Grab(TakePosition);
                        PlayerPickUpDrop.WhatHolding = "Куприт";
                    }
                    if (Hit.collider.CompareTag("Halkopirit"))
                    {
                        stoneCount += 1;
                        halkopirit = Instantiate(Halkopirit, TakePosition.transform.position, Quaternion.identity);
                        PlayerPickUpDrop.objectGrabbable = halkopirit.GetComponent<ObjectGrabbable>();
                        PlayerPickUpDrop.objectGrabbable.Grab(TakePosition);
                        PlayerPickUpDrop.WhatHolding = "Халькопирит";
                    }
                    if (Hit.collider.CompareTag("Marganec"))
                    {
                        stoneCount += 1;
                        marganec = Instantiate(Marganec, TakePosition.transform.position, Quaternion.identity);
                        PlayerPickUpDrop.objectGrabbable = marganec.GetComponent<ObjectGrabbable>();
                        PlayerPickUpDrop.objectGrabbable.Grab(TakePosition);
                        PlayerPickUpDrop.WhatHolding = "Марганец";
                    }
                }

                
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (Hit.collider.CompareTag("Podnos") && poloshili == false)
                {
                    if (PlayerPickUpDrop.WhatHolding == "Боксит" || PlayerPickUpDrop.WhatHolding == "Бокситт(Clone)")
                    {
                        BoksitOnTable.SetActive(true);
                        Destroy(boksit);
                        PlayerPickUpDrop.WhatHolding = "0";
                        PlayerPickUpDrop.objectGrabbable = null;
                        poloshili = true;

                    }
                    if (PlayerPickUpDrop.WhatHolding == "Гематит" || PlayerPickUpDrop.WhatHolding == "Гематитт(Clone)")
                    {
                        FurrumOnTable.SetActive(true);
                        Destroy(ferrum);
                        PlayerPickUpDrop.WhatHolding = "0";
                        PlayerPickUpDrop.objectGrabbable = null;
                        poloshili = true;
                       

                    }
                    if (PlayerPickUpDrop.WhatHolding == "Куприт" || PlayerPickUpDrop.WhatHolding == "Купритт(Clone)")
                    {
                        KupritOnTable.SetActive(true);
                        Destroy(kuprit);
                        PlayerPickUpDrop.WhatHolding = "0";
                        PlayerPickUpDrop.objectGrabbable = null;
                        poloshili = true;
                    }
                    if (PlayerPickUpDrop.WhatHolding == "Марганец" || PlayerPickUpDrop.WhatHolding == "Марганецц(Clone)")
                    {
                        MarganecOnTable.SetActive(true);
                        Destroy(marganec);
                        PlayerPickUpDrop.WhatHolding = "0";
                        PlayerPickUpDrop.objectGrabbable = null;
                        poloshili = true;
                    }
                    if (PlayerPickUpDrop.WhatHolding == "Халькопирит" || PlayerPickUpDrop.WhatHolding == "Халькопиритт(Clone)")
                    {
                        HalkopiritOnTable.SetActive(true);
                        Destroy(halkopirit);
                        PlayerPickUpDrop.WhatHolding = "0";
                        PlayerPickUpDrop.objectGrabbable = null;
                        poloshili = true;
                    }
                }
            }
        }

        if (stoneCount == 7 && !scrimer)
        {
            scull.isScull = true;
            scrimer = true;
        }
    }
}
