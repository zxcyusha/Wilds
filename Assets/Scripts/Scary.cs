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
    public static float strength = 0.03f;
    public float speed = 0.2f;
    public GameObject Babaka;
    public GameObject Player;
    public GameObject Taburetka;
    public GameObject Lightt;
    public AudioSource Shepolochek;
    public AudioSource ZvukPtici;
    private bool ptica = false;
    private bool babaka = false;
    private bool miliShepolochek = false;
    public bool PticaEnd = false;
    private bool day1Scary = false;
    public AudioSource dihanie;
    public AudioSource serdce;
    public AudioSource pic;
    public GameObject panelSkary;
    public GameObject player;
    public AudioSource Shagi;
    public AudioSource Beg;

    private void Update()
    {
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit hit, 3f, pickUpLayerMask))
        {
            if (hit.collider.CompareTag("Babaka") && !babaka && Vector3.Distance(transform.position, Babaka.transform.position) < 4f)
            {
                Babaka.GetComponent<AudioSource>().Play();
                babaka = true;
                Invoke("NetBabaki", 2f);
            }

            else if (DAYS.DAY2 && (hit.collider.CompareTag("Taburetka")) && !ptica) {
                Taburetka.GetComponent<AudioSource>().Play();
                Lightt.SetActive(true);
                Invoke("aga", 3f);
                ptica = true;
            }
            else if (DAYS.DAY5 && (hit.collider.CompareTag("Nanometr2")) && !miliShepolochek)
            {
                ZvukPtici.Stop();
                Shepolochek.Play();
                Lightt.SetActive(true);
                miliShepolochek = true;
            }
            else if ((hit.collider.CompareTag("Taburetka") && miliShepolochek) && !PticaEnd)
            {
                ZvukPtici.Play();
                Shepolochek.Stop();
                Lightt.SetActive(false);
                PticaEnd = true;
            }

            if (hit.collider.CompareTag("ScaryFirst") && !day1Scary) Scary1();
        }
    }

    private void NetBabaki()
    {
        Babaka.SetActive(false);
    }

    private void aga()
    {
        Lightt.SetActive(false);
    }

    private void Scary1()
    {
        day1Scary = true;
        serdce.Play();
        dihanie.Play();
        player.GetComponent<AnimatorCotroller>().enabled = false;
        panelSkary.SetActive(true);
        Invoke("zvuk", 13.3f);
        Shagi.Stop();
        Beg.Stop();
    }

    private void zvuk()
    {
        serdce.Stop();
        dihanie.Stop();
        pic.Play();
        Invoke("konec", 10f);

        player.GetComponent<AnimatorCotroller>().enabled = true;
    }

    private void konec()
    {
        panelSkary.SetActive(false );
    }
}

