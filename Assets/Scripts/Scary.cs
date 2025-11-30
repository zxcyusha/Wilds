using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ТряскаКамеры : MonoBehaviour
{
    public Transform playerCamera;
    [SerializeField] private LayerMask pickUpLayerMask;

    public float distance = 3f;
    public float strength = 0.03f;
    public Image panel;
    public float speed = 0.2f;
    public bool isTraska;
    public GameObject Babaka;
    public GameObject Player;
    public GameObject Taburetka;
    public GameObject Lightt;
    private bool babaka = false;
    
    private void Start()
    {
    }

    private void Update()
    {
        if (isTraska)
        {
            transform.position = transform.position + (Vector3)Random.insideUnitCircle * strength;
        }
        else transform.localPosition = new Vector3(0, -0.1f, 0.062f);                                                                        ;

        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit hit, 3f, pickUpLayerMask))
        {
            if (hit.collider.CompareTag("Babaka") && !babaka && Vector3.Distance(transform.position, Babaka.transform.position) < 4f)
            {
                isTraska = true;
                Babaka.GetComponent<AudioSource>().Play();
                babaka = true;
                Invoke("NetBabaki", 2f);
            }

            if (DAYS.DAY3 && (hit.collider.CompareTag("Taburetka"))) {
                Taburetka.GetComponent<AudioSource>().Play();
                Lightt.SetActive(true);
                isTraska = true;
                Invoke("aga", 2f);
            }
        }
    }

    private void NetBabaki()
    {
        isTraska = false;
        Babaka.SetActive(false);
    }

    private void aga()
    {
        isTraska = false;
        Lightt.SetActive(false);
    }
}

