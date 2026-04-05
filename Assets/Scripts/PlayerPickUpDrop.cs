using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour
{


    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private GameObject objectGrabPointTransform;
    [SerializeField] private GameObject E;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private float pickUpDistance = 7f;
    [SerializeField] private GameObject text1;
    [SerializeField] private GameObject text2;
    [SerializeField] private GameObject text3;
    [SerializeField] private GameObject text4;
    [SerializeField] private GameObject text5;

    public static ObjectGrabbable objectGrabbable;
    public static string WhatHolding = "0";

    private void Update()
    {
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit Hit, pickUpDistance, pickUpLayerMask))
        {
            Debug.DrawRay(playerCameraTransform.position, playerCameraTransform.forward, Color.red);
            if ((Hit.collider.CompareTag("Leyka") || Hit.collider.CompareTag("Boksit") || Hit.collider.CompareTag("Ferrum") || Hit.collider.CompareTag("Kuprit") || Hit.collider.CompareTag("Halkopirit") || Hit.collider.CompareTag("Marganec")))
            {
                E.SetActive(true);
            }
            else if (Hit.collider.tag == "Tverdost" && objectGrabbable == null && FirstRoom.can) text1.SetActive(true);
            else if (Hit.collider.CompareTag("Sostav") && objectGrabbable == null && FirstRoom.can1) text2.SetActive(true);
            else if (Hit.collider.CompareTag("Vlashnost") && objectGrabbable == null) text3.SetActive(true);
            else if (Hit.collider.CompareTag("Magnit") && objectGrabbable == null) text4.SetActive(true);
            else if (Hit.collider.CompareTag("Plotnost") && objectGrabbable == null) text5.SetActive(true);

            else
            {
                E.SetActive(false);
                text1.SetActive(false);
                text2.SetActive(false);
                text3.SetActive(false);
                text4.SetActive(false);
                text5.SetActive(false);
            }
        }
        else
        {
            E.SetActive(false);
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(false);
            text4.SetActive(false);
            text5.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objectGrabbable == null)
            {
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
                {
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        objectGrabbable.Grab(objectGrabPointTransform);
                        WhatHolding = raycastHit.transform.name;
                        E.SetActive(false);
                    }
                }
            }
            else
            {
                objectGrabbable.Drop();
                objectGrabbable = null;
                WhatHolding = "0";
            }
        }

        
    }
}