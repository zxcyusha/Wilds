using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DAYS : MonoBehaviour
{
    public static bool DAY1 = false;
    public static bool DAY2 = false;
    public static bool DAY3 = false;
    public static bool DAY4 = false;
    public static bool DAY5 = false;

    public GameObject F;
    public GameObject TemneyushiyEkran;
    public GameObject Diary;
    public GameObject DenN;
    public GameObject Door1;
    public GameObject Door2;
    public GameObject RaspInstr;
    public Transform playerCamera;
    public AudioSource InstrZvuk;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private Transform PlayerTransform;
    public AudioSource LiftOtkr;
    public Texture D1;
    public Texture D2;
    public Texture D3;
    public Texture D4;
    public Texture D5;
    public Material Raspisanie;
    public ItemPicker openDoors;
    public GameObject Boks;
    public GameObject Gem;
    public GameObject Kup;
    public GameObject Mar;
    public GameObject Halk;
    public GameObject List;
    public TakeListok takeListok;
    public Nanometr nanometr1;
    public Nanometr1 nanometr2;
    public Nanometr2 nanometr3;
    public GameObject StrelkaCher2;
    public GameObject StrelkaCher3;
    public GameObject boks;
    public GameObject gem;
    public GameObject kup;
    public GameObject halk;
    public GameObject teleshka;
    public GameObject Osnkomn;
    public GameObject napoln;
    public FirstRoom firstRoom;
    public GameObject bur;
    public GameObject Zabludilsa;
    public GameObject Babaka;
    public GameObject Peretashit;
    public bool CAN;

    private bool raspisanieYes = false;

    void Start()
    {
        bur.transform.localPosition = new Vector3(-24.07f, -6.67f, -12.93f);
        bur.transform.localRotation = Quaternion.Euler(0, 90, 0);
        DAYFIRST();
    }

    void Update()
    {
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit hit, 3f, pickUpLayerMask))
        {
            
            if (hit.collider.CompareTag("Raspisanie") && !raspisanieYes)
            {
                RaspInstr.SetActive(true);
                InstrZvuk.Play();
                raspisanieYes = true;
            }
            if (hit.collider.CompareTag("Lift"))
            {
                if ((DAY1 && (TakeListok.vibrali1 && TakeListok.vibrali2 && TakeListok.vibrali3 && TakeListok.vibrali4 && TakeListok.vibrali5) && BurMachina.BoorSdelali && RoomWithRart.CartYes) || CAN)
                {
                    F.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        Peretashit.transform.localPosition = new Vector3(26.7f, -1.71f, -25.46f);
                        RoomWithRart.telesh = false;
                        Stones.poloshili = false;
                        openDoors.CloseAllDoors();
                        bur.transform.localPosition = new Vector3(1.09f, -6.67f, -3.1f);
                        bur.transform.localRotation = Quaternion.Euler(0, 270, 0);

                        DenN.GetComponent<TextMeshProUGUI>().text = "Äåíü 2";
                        TemneyushiyEkran.SetActive(true);
                        Invoke("DnevnikOpen", 1);
                        ResetFirstRoom();
                        ResetShahta();
                        firstRoom.RandomZnach();
                    }
                }
                if ((DAY2 && (TakeListok.vibrali1 && TakeListok.vibrali2 && TakeListok.vibrali3 && TakeListok.vibrali4 && TakeListok.vibrali5) && BurMachina.BoorSdelali && (Nanometr.PODKYTILI1 && Nanometr1.PODKYTILI2 && Nanometr2.PODKYTILI3)))
                {
                    F.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        DenN.GetComponent<TextMeshProUGUI>().text = "Äåíü 3";
                        TemneyushiyEkran.SetActive(true);
                        Invoke("DnevnikOpen", 1);
                        ResetFirstRoom();
                        ResetShahta();
                        ResetPtica();
                        ResetTeleshki();
                        firstRoom.RandomZnach();
                        halk.SetActive(true);
                    }
                }
                if ((DAY3 && (TakeListok.vibrali1 && TakeListok.vibrali2 && TakeListok.vibrali3 && TakeListok.vibrali4 && TakeListok.vibrali5) && (Nanometr.PODKYTILI1 && Nanometr1.PODKYTILI2 && Nanometr2.PODKYTILI3) && RoomWithRart.CartYes))
                {
                    Babaka.SetActive(true);
                    F.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        bur.transform.localPosition = new Vector3(1.09f, -6.67f, -16.04f);

                        DenN.GetComponent<TextMeshProUGUI>().text = "Äåíü 4";
                        TemneyushiyEkran.SetActive(true);
                        Invoke("DnevnikOpen", 1);
                        ResetFirstRoom();
                        ResetShahta();
                        ResetPtica();
                        ResetTeleshki();
                        firstRoom.RandomZnach();
                    }
                }
                if ((DAY4 && (TakeListok.vibrali1 && TakeListok.vibrali2 && TakeListok.vibrali3 && TakeListok.vibrali4 && TakeListok.vibrali5) && BurMachina.BoorSdelali && RoomWithRart.CartYes))
                {
                    F.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        bur.transform.localPosition = new Vector3(-24.55f, -6.67f, -5.01f);
                        bur.transform.localRotation = Quaternion.Euler(0, 180, 0);

                        DenN.GetComponent<TextMeshProUGUI>().text = "Äåíü 5";
                        TemneyushiyEkran.SetActive(true);
                        Invoke("DnevnikOpen", 1);
                        ResetFirstRoom();
                        ResetShahta();
                        ResetPtica();
                        ResetTeleshki();
                        firstRoom.RandomZnach();
                    }
                }

                if ((DAY5 && (Nanometr.PODKYTILI1 && Nanometr1.PODKYTILI2 && Nanometr2.PODKYTILI3) && BurMachina.BoorSdelali && RoomWithRart.CartYes))
                {
                    F.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        TemneyushiyEkran.SetActive(true);
                        Invoke("DnevnikOpen", 1);
                    }
                }

            }
            else F.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Return)) RaspInstr.SetActive(false);
            
        }
        else F.SetActive(false);
    }

    public void DAYFIRST()
    {
        Raspisanie.SetTexture("_MainTex", D1);
        DAY1 = true;
        DAY2 = false;
        DAY3 = false;
        DAY4 = false;
        DAY5 = false;
    }

    public void DAYSECOND()
    {
        DAY1 = false;
        DAY2 = true;
        DAY3 = false;
        DAY4 = false;
        DAY5 = false;

        Raspisanie.SetTexture("_MainTex", D2);
        PlayerTransform.position = new Vector3(9.152f, 0.167f, -17.14f);
        PlayerTransform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void DAYTHIRD()
    {
        DAY1 = false;
        DAY2 = false;
        DAY3 = true;
        DAY4 = false;
        DAY5 = false;

        Raspisanie.SetTexture("_MainTex", D3);
        PlayerTransform.position = new Vector3(9.152f, 0.167f, -17.14f);
        PlayerTransform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void DAYFOURTH()
    {
        DAY1 = false;
        DAY2 = false;
        DAY3 = false;
        DAY4 = true;
        DAY5 = false;

        Raspisanie.SetTexture("_MainTex", D4);
        PlayerTransform.position = new Vector3(9.152f, 0.167f, -17.14f);
        PlayerTransform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void DAYFIFTH()
    {
        DAY1 = false;
        DAY2 = false;
        DAY3 = false;
        DAY4 = false;
        DAY5 = true;

        Raspisanie.SetTexture("_MainTex", D5);
        PlayerTransform.position = new Vector3(9.152f, 0.167f, -17.14f);
        PlayerTransform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void DnevnikOpen()
    {
        Diary.SetActive(true);
        Cursor.visible = true;
    }

    public void NewDay()
    {
        if (DAY1)
        {
            DAYSECOND();
        }
        else if (DAY2)
        {
            DAYTHIRD();
        }
        else if (DAY3)
        {
            DAYFOURTH();
        }
        else if (DAY4)
        {
            DAYFIFTH();
        }
        Diary.GetComponent<Animator>().SetBool("Zakr", false);

        
        Invoke("DnevnikClose", 1f);
    }

    private void DnevnikClose() {
        if (!DAY5) {
            Diary.SetActive(false);
            Door1.GetComponent<Animator>().SetBool("Open", false);
            Door2.GetComponent<Animator>().SetBool("open", false);
            Invoke("ZaKrPanel", 3f);
            Cursor.visible = false;
            DenNStart();
        }
        else
        {
            Cursor.visible = false;
            Zabludilsa.GetComponent<BadEnd>().enabled = true;
        }
    }

    private void ZaKrPanel()
    {
        TemneyushiyEkran.GetComponent<Animator>().SetBool("Zakr", true);
        Invoke("DveriOtkr", 2f);
    }

    private void DveriOtkr()
    {
        Door1.GetComponent<Animator>().SetBool("Open", true);
        Door2.GetComponent<Animator>().SetBool("open", true);
        LiftOtkr.Play();
        TemneyushiyEkran.SetActive(false);
        DenN.SetActive(false);
    }

    private void DenNStart()
    {
        DenN.SetActive(true);
        Door1.GetComponent<AudioSource>().Play();
    }

    private void ResetFirstRoom()
    {
        Boks.SetActive(false);
        Kup.SetActive(false);
        Gem.SetActive(false);
        Mar.SetActive(false);
        Halk.SetActive(false);
        List.transform.SetParent(null);
        List.transform.position = new Vector3(1.49f, 1.12f, -3.31f);
        List.transform.rotation = Quaternion.Euler(0, -180, -90);
        List.transform.localScale = new Vector3(0.0942f, 14.29f, 24.98f);

        TakeListok.rightMAG = 0;
        TakeListok.rightPLOT = 0;
        TakeListok.rightTVERD = 0;
        TakeListok.rightSOSTAV = 0;
        TakeListok.rightVLASH = 0;

        TakeListok.vibrali1 = false;
        TakeListok.vibrali2 = false;
        TakeListok.vibrali3 = false;
        TakeListok.vibrali4 = false;
        TakeListok.vibrali5 = false;

        takeListok.NetGalocek();
        TakeListok.canTake = true;
    }
    private void ResetTeleshki()
    {
        teleshka.transform.SetParent(Osnkomn.transform);
        teleshka.GetComponent<Animator>().enabled = true;
        teleshka.GetComponent<Animator>().SetBool("Array", false);
        teleshka.GetComponent<Animator>().SetBool("Priezshaet", false);
        Cart.count = 0;
        Cart.napolnili = false;
        Cart.prikrepiliList = false;
        Cart.OTPRAVILI = false;
        RoomWithRart.OTPRAVILITELESHKI = false;
        RoomWithRart.CartYes = false;
        napoln.transform.localPosition = new Vector3(0.045f, 0.424f, -0.0038f);
        napoln.SetActive(false);
    }
    private void ResetPtica()
    {
        nanometr1.z1 = true;
        nanometr2.z1 = true;
        nanometr3.z1 = true;

        nanometr1.StrelkaRotation();
        StrelkaCher2.transform.rotation = Quaternion.Euler(134, 180, 0);
        StrelkaCher3.transform.rotation = Quaternion.Euler(-180, -90, 0);
        
    }

    private void ResetShahta()
    {
        Shkala.isStopped = false;
        MouseCoordinates.isStop = false;
        boks.SetActive(false);
        kup.SetActive(false);
        gem.SetActive(false);
        halk.SetActive(false);

    }
}
