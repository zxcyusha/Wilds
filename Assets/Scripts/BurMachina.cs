using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurMachina : MonoBehaviour
{
    public Transform playerCamera;
    public LayerMask pickUpLayerMask;
    public GameObject NashmiNaF;
    public GameObject ShkalaPanel;
    public GameObject TextBur;
    public GameObject PanelBur;
    public AudioSource ZvukBoor;
    public GameObject PatMilLet;
    public AudioSource yra;
    public GameObject instruksia;
    public AudioSource InstrZvuk;
    public GameObject Kuprit;
    public GameObject Gematit;
    public GameObject Boksit;
    public GameObject Halkopirit;
    private bool layk = false;
    private bool instrBur = false;

    public static bool BoorSdelali = false;

    void Update()
    {
        if (!DAYS.DAY3)
        {
            if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit hit, 3f, pickUpLayerMask))
            {
                if (hit.collider.CompareTag("Shkala") && !Shkala.isStopped)
                {
                    NashmiNaF.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        ShkalaPanel.SetActive(true);
                        InstrZvuk.Play();
                    }
                }

                else if (hit.collider.CompareTag("Bur") && Shkala.isStopped && !MouseCoordinates.isStop)
                {
                    TextBur.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        ZvukBoor.Play();
                        PanelBur.SetActive(true);
                        Cursor.visible = true;
                        layk = true;
                    }
                }
                else if ((hit.collider.CompareTag("Bur") || hit.collider.CompareTag("Shkala")) && !instrBur)
                {
                    InstrZvuk.Play();
                    instruksia.SetActive(true);
                    instrBur = true;
                }
                else
                {
                    NashmiNaF.SetActive(false);
                    TextBur.SetActive(false);
                }
            }
            else
            {
                NashmiNaF.SetActive(false);
                TextBur.SetActive(false);
            }

            if (Input.GetMouseButtonDown(0) && layk && PanelBur.activeInHierarchy)
            {
                Cursor.visible = false;
                yra.Play();
                MouseCoordinates.isStop = true;
                PatMilLet.SetActive(true);
                Invoke("a", 3f);
                Invoke("b", 5f);
                StartCoroutine(MouseCoordinates.FadeOutCoroutine(ZvukBoor, 3f));
                BoorSdelali = true;
            }
            if (Input.GetKey(KeyCode.Return))
            {
                instruksia.SetActive(false);
            }
        }
    }

    private void b()
    {
        PatMilLet.SetActive(false);
    }
    private void a()
    {
        PanelBur.SetActive(false);
        if (DAYS.DAY1) Halkopirit.SetActive(true);
        else if (DAYS.DAY2) Boksit.SetActive(true);
        else if (DAYS.DAY4) Gematit.SetActive(true);
        else if (DAYS.DAY5) Kuprit.SetActive(true);
    }
}
