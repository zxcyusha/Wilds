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

    public static ObjectGrabbable objectGrabbable;
    public static string WhatHolding = "0";

    private void Update()
    {
        //Debug.Log(WhatHolding);
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit Hit, pickUpDistance, pickUpLayerMask))
        {
            Debug.DrawRay(playerCameraTransform.position, playerCameraTransform.forward, Color.red);
            if ((Hit.collider.CompareTag("Leyka") && objectGrabbable == null) || Hit.collider.CompareTag("Boksit") || Hit.collider.CompareTag("Ferrum") || Hit.collider.CompareTag("Kuprit") || Hit.collider.CompareTag("Halkopirit") || Hit.collider.CompareTag("Marganec"))
            {
                E.SetActive(true);
            }

            else E.SetActive(false);
        }
        else E.SetActive(false);
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