using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diary : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    public GameObject F;
    public GameObject diary;
    public GameObject button;
    public GameObject textic;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit Hit, 4f, pickUpLayerMask))
        {
            if (Hit.collider.tag == "Diary")
            {
                F.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    diary.SetActive(true);
                    button.SetActive(false);
                    textic.SetActive(true);
                }
            }
            else F.SetActive(false);

        if (Input.GetKeyDown(KeyCode.I)) diary.SetActive(false);
        }
        else F.SetActive(false);
    }
}
