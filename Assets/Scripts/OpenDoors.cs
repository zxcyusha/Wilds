
using System.Collections;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    public Transform playerCamera;
    public float pickRange = 3f;
    public float speed = 0.1f;
    public AudioSource OpenDoor;
    private bool isAnimating;
    [SerializeField] private float duration = 0.5f;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private GameObject F;
    private Quaternion closedRot;
    private Quaternion openRot;
    public bool isOpen;

    private void Awake()
    {
        closedRot = Quaternion.Euler(0, 0, 0);
        openRot = Quaternion.Euler(0, 80, 0);
    }

    void Update()
    {
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit hit, 4f, pickUpLayerMask))
        {
            if ((hit.collider.CompareTag("Podnos") && (PlayerPickUpDrop.WhatHolding == "Боксит" || PlayerPickUpDrop.WhatHolding == "Бокситт(Clone)" || PlayerPickUpDrop.WhatHolding == "Гематит" || PlayerPickUpDrop.WhatHolding == "Гематитт(Clone)" || PlayerPickUpDrop.WhatHolding == "Куприт" || PlayerPickUpDrop.WhatHolding == "Купритт(Clone)" || PlayerPickUpDrop.WhatHolding == "Марганец" || PlayerPickUpDrop.WhatHolding == "Марганецц(Clone)" || PlayerPickUpDrop.WhatHolding == "Халькопирит" || PlayerPickUpDrop.WhatHolding == "Халькопиритт(Clone)")) || hit.collider.CompareTag("Door")) F.SetActive(true);
            else F.SetActive(false);
        }
        else F.SetActive(false);
            if (Input.GetKeyDown(KeyCode.F))
        {
            if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit Hit, pickRange))
            {
                if ((Hit.collider.CompareTag("Door")))
                {
                    if (isOpen)
                    {
                        OpenDoor.Play();
                        StartCoroutine(RotateDoor(openRot, closedRot, Hit.collider.gameObject));
                        isOpen = !isOpen;
                    }
                    else
                    {
                        OpenDoor.Play();
                        StartCoroutine(RotateDoor(closedRot, openRot, Hit.collider.gameObject));
                        isOpen = !isOpen;
                    }
                }

            }
        }
    }

    private IEnumerator RotateDoor(Quaternion from, Quaternion to, GameObject door)
    {
        isAnimating = true;

        float t = 0f;
        
        if (door.transform.localRotation == to) StopAllCoroutines();
        while (t < 1f)
        {
            t += Time.deltaTime / duration;
            door.transform.localRotation = Quaternion.Slerp(from, to, t);
            yield return null;
        }

        door.transform.localRotation = to;
        isAnimating = false;
    }

}
