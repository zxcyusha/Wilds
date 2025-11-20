using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeListok : MonoBehaviour
{
    public Transform playerCamera;
    public LayerMask pickUpLayerMask;
    public GameObject EandR;
    public GameObject List;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && List.activeInHierarchy)
        {
            List.SetActive(false);
        }
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit hit, 4f, pickUpLayerMask))
        {
            if (hit.collider.CompareTag("Listok"))
            {
                EandR.SetActive(true);
                if (Input.GetKeyDown(KeyCode.R))
                {
                    if (!List.activeInHierarchy) List.SetActive(true);
                }
            }
            else EandR.SetActive(false);
        }
        else EandR.SetActive(false);
    }
}
