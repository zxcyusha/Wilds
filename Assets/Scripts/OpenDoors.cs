
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
    public GameObject Instrukcia;
    public AudioSource InstrZvuk;
    private Quaternion closedRot;
    private Quaternion openRot;
    private Quaternion openRot1;
    private Quaternion open;
    public bool isOpen;
    private bool instr = false;
    public GameObject door1;
    public GameObject door2;
    private bool instrPtica = false;
    public GameObject InstruksiaPtica;
    public GameObject zakrito;
    public AudioSource zakritoZvuk;
    public GameObject Door1;
    public GameObject Door2;
    public GameObject Door21;
    public GameObject Door3;
    private bool canF = true;

    private void Awake()
    {
        closedRot = Quaternion.Euler(0, 0, 0);
        openRot = Quaternion.Euler(0, 80, 0);
        openRot1 = Quaternion.Euler(0, -80, 0);

        CloseAllDoors();
    }

    void Update()
    {
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit hit, 4f, pickUpLayerMask))
        {
            if ((hit.collider.CompareTag("Podnos") && (PlayerPickUpDrop.WhatHolding == "Боксит" || PlayerPickUpDrop.WhatHolding == "Бокситт(Clone)" || PlayerPickUpDrop.WhatHolding == "Гематит" || PlayerPickUpDrop.WhatHolding == "Гематитт(Clone)" || PlayerPickUpDrop.WhatHolding == "Куприт" || PlayerPickUpDrop.WhatHolding == "Купритт(Clone)" || PlayerPickUpDrop.WhatHolding == "Марганец" || PlayerPickUpDrop.WhatHolding == "Марганецц(Clone)" || PlayerPickUpDrop.WhatHolding == "Халькопирит" || PlayerPickUpDrop.WhatHolding == "Халькопиритт(Clone)")) || hit.collider.CompareTag("Door") || hit.collider.CompareTag("FirstDoor")) F.SetActive(true);
            else if (hit.collider.CompareTag("LDoor") && canF)
            {
                F.SetActive(true);
            }
            else if (hit.collider.CompareTag("DoorToCarps") && canF)
            {
                F.SetActive(true);
            }
            else F.SetActive(false);
        }
        else F.SetActive(false);
            if (Input.GetKeyDown(KeyCode.F))
            {
            if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit Hit, pickRange))
            {
                if (Hit.collider.CompareTag("Door") || Hit.collider.CompareTag("FirstDoor"))
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
                        if (Hit.collider.CompareTag("FirstDoor") && !instr)
                        {

                            Instrukcia.SetActive(true);
                            instr = true;
                            InstrZvuk.Play();
                        }
                    }
                }
                else if (Hit.collider.CompareTag("LDoor"))
                {
                    if (DAYS.DAY2 || DAYS.DAY3 || DAYS.DAY5)
                    {
                        if (!instrPtica)
                        {
                            InstruksiaPtica.SetActive(true);
                            InstrZvuk.Play();
                            instrPtica = true;
                        }
                        if (isOpen)
                        {
                            OpenDoor.Play();
                            StartCoroutine(RotateDoor(openRot, closedRot, door1));
                            StartCoroutine(RotateDoor(openRot1, closedRot, door2));
                            isOpen = !isOpen;
                        }
                        else
                        {
                            OpenDoor.Play();
                            StartCoroutine(RotateDoor(closedRot, openRot, door1));
                            StartCoroutine(RotateDoor(closedRot, openRot1, door2));
                            isOpen = !isOpen;
                        }
                    }
                    else
                    {
                        zakrito.SetActive(true);
                        Invoke("zakr", 2f);
                        zakritoZvuk.Play();
                        canF = false;
                    }
                }

                else if (Hit.collider.CompareTag("DoorToCarps"))
                {
                    if (DAYS.DAY1 || DAYS.DAY3 || DAYS.DAY5)
                    {
                        if (isOpen)
                        {
                            OpenDoor.Play();
                            StartCoroutine(RotateDoor(openRot, closedRot, hit.collider.gameObject));
                            isOpen = !isOpen;
                        }
                        else
                        {
                            OpenDoor.Play();
                            StartCoroutine(RotateDoor(closedRot, openRot, hit.collider.gameObject));
                            isOpen = !isOpen;
                        }
                    }
                    else
                    {
                        zakrito.SetActive(true);
                        Invoke("zakr", 2f);
                        zakritoZvuk.Play();
                        canF = false;
                    }
                }

            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Instrukcia.SetActive(false);
            InstruksiaPtica.SetActive(false);
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

    private void zakr()
    {
        zakrito.SetActive(false);
        canF = true;
    }

    public void CloseAllDoors()
    {
        Door1.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        Door2.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        Door21.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        Door3.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }
}
