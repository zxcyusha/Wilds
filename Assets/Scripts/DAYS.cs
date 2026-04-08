using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;
using UnityEngine.UI;

public class DAYS : MonoBehaviour
{
    public static bool DAY1 = false;
    public static bool DAY2 = false;
    public static bool DAY3 = false;
    public static bool DAY4 = false;
    public static bool DAY5 = false;

    public GameObject F;
    public GameObject TemneyushiyEkran;
    public GameObject diary;
    public GameObject Den2;
    public GameObject Den3;
    public GameObject Den4;
    public GameObject Den5;
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
    public GameObject button;
    public GameObject textic;
    public GameObject Diary1;
    public GameObject Diary2;
    public GameObject Diary3;
    public GameObject Diary4;
    public GameObject Diary5;
    public GameObject Player;
    public AudioSource FonShum;
    public AudioSource NachZvuk;
    public TextMeshProUGUI Spase;
    public AudioSource HappyAudio;
    public GameObject HappyPanel;
    public static bool NANOMETRS;
    public GameObject AreYouShure;
    public GameObject Zagruzka;
    public SaveLoadManager saveLoadManager;
    [SerializeField] private Slider SensitivitySlider;
    [SerializeField] private Slider MusicSlider;

    public GameObject diary1;
    public GameObject diary2;
    public GameObject diary3;
    public GameObject diary4;
    [SerializeField] private GameObject List1;
    [SerializeField] private GameObject List2;
    [SerializeField] private GameObject List3;
    [SerializeField] private GameObject List4;
    [SerializeField] private GameObject After1;
    [SerializeField] private GameObject After2;
    [SerializeField] private GameObject After3;
    [SerializeField] private GameObject After4;
    public static int day;
    public bool CAN1;
    public bool CAN2;
    public bool CAN3;
    public bool CAN4;
    public bool CAN5;
    private bool EndGame = false;

    private bool raspisanieYes = false;

    void Start()
    {
        if (StartCatScene.IsAnimated)
        {
            SensitivitySlider.value = 1f;
            MusicSlider.value = 1f;
            Time.timeScale = 1f;
            bur.transform.localPosition = new Vector3(-24.07f, -6.67f, -12.93f);
            bur.transform.localRotation = Quaternion.Euler(0, 90, 0);
            DAYFIRST();
        }
        else
        {
            if (day == 1)
            {
                DAY1 = true;
                DAY2 = false;
                DAY3 = false;
                DAY4 = false;
                DAY5 = false;
            }
            else if (day == 2)
            {
                Debug.Log("шлёпа");
                DAY1 = false;
                DAY2 = true;
                DAY3 = false;
                DAY4 = false;
                DAY5 = false;
            }
            else if (day == 3)
            {
                DAY1 = false;
                DAY2 = false;
                DAY3 = true;
                DAY4 = false;
                DAY5 = false;
            }
            else if (day == 4)
            {
                DAY1 = false;
                DAY2 = false;
                DAY3 = false;
                DAY4 = true;
                DAY5 = false;
            }
            else if (day == 5)
            {
                DAY1 = false;
                DAY2 = false;
                DAY3 = false;
                DAY4 = false;
                DAY5 = true;
            }
        }

        if (DAY1)
        {
            diary1.SetActive(false);
            diary2.SetActive(false);
            diary3.SetActive(false);
            diary4.SetActive(false);
        }
        else if (DAY2)
        {
            diary1.SetActive(true);
            diary2.SetActive(false);
            diary3.SetActive(false);
            diary4.SetActive(false);
        }
        else if (DAY3)
        {
            diary1.SetActive(false);
            diary2.SetActive(true);
            diary3.SetActive(false);
            diary4.SetActive(false);
        }
        else if (DAY4)
        {
            diary1.SetActive(false);
            diary2.SetActive(false);
            diary3.SetActive(true);
            diary4.SetActive(false);
        }
        else if (DAY5)
        {
            diary1.SetActive(false);
            diary2.SetActive(false);
            diary3.SetActive(false);
            diary4.SetActive(true);
        }
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
                if ((DAY1 && (TakeListok.vibrali1 && TakeListok.vibrali2 && TakeListok.vibrali3 && TakeListok.vibrali4 && TakeListok.vibrali5) && BurMachina.BoorSdelali && RoomWithRart.CartYes) || CAN1)
                {
                    F.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        List1.SetActive(false);
                        List2.SetActive(false);
                        List3.SetActive(false);
                        List4.SetActive(false);
                        After1.SetActive(false);
                        After2.SetActive(false);
                        After3.SetActive(false);
                        After4.SetActive(false);

                        Diary1.SetActive(true);
                        RoomWithRart.canDvig = false;
                        RoomWithRart.katitsa = true;
                        Peretashit.transform.localPosition = new Vector3(26.7f, -1.71f, -25.46f);
                        RoomWithRart.telesh = false;
                        Stones.poloshili = false;
                        openDoors.CloseAllDoors();
                        bur.transform.localPosition = new Vector3(1.09f, -6.67f, -3.1f);
                        bur.transform.localRotation = Quaternion.Euler(0, 270, 0);

                        TemneyushiyEkran.SetActive(true);
                        Invoke("DnevnikOpen", 1);
                        ResetFirstRoom();
                        ResetShahta();
                        firstRoom.RandomZnach();
                    }
                }
                else if (DAY1 && !((TakeListok.vibrali1 && TakeListok.vibrali2 && TakeListok.vibrali3 && TakeListok.vibrali4 && TakeListok.vibrali5) && BurMachina.BoorSdelali && RoomWithRart.CartYes))
                {
                    AreYouShure.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        List1.SetActive(false);
                        List2.SetActive(false);
                        List3.SetActive(false);
                        List4.SetActive(false);
                        After1.SetActive(false);
                        After2.SetActive(false);
                        After3.SetActive(false);
                        After4.SetActive(false);
                        Diary1.SetActive(true);
                        RoomWithRart.canDvig = false;
                        RoomWithRart.katitsa = true;
                        Peretashit.transform.localPosition = new Vector3(26.7f, -1.71f, -25.46f);
                        RoomWithRart.telesh = false;
                        Stones.poloshili = false;
                        openDoors.CloseAllDoors();
                        bur.transform.localPosition = new Vector3(1.09f, -6.67f, -3.1f);
                        bur.transform.localRotation = Quaternion.Euler(0, 270, 0);

                        TemneyushiyEkran.SetActive(true);
                        Invoke("DnevnikOpen", 1);
                        ResetFirstRoom();
                        ResetShahta();
                        firstRoom.RandomZnach();
                    }
                }
                if ((DAY2 && (TakeListok.vibrali1 && TakeListok.vibrali2 && TakeListok.vibrali3 && TakeListok.vibrali4 && TakeListok.vibrali5) && BurMachina.BoorSdelali && (Nanometr.PODKYTILI1 && Nanometr1.PODKYTILI2 && Nanometr2.PODKYTILI3)) || CAN2)
                {
                    F.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        List1.SetActive(false);
                        List2.SetActive(false);
                        List3.SetActive(false);
                        List4.SetActive(false);
                        After1.SetActive(false);
                        After2.SetActive(false);
                        After3.SetActive(false);
                        After4.SetActive(false);
                        Diary1.SetActive(false);
                        Diary2.SetActive(true);
                        RoomWithRart.katitsa = true;
                        Peretashit.transform.localPosition = new Vector3(26.7f, -1.71f, -25.46f);
                        RoomWithRart.canDvig = false;
                        Stones.poloshili = false;
                        RoomWithRart.telesh = false;
                        TemneyushiyEkran.SetActive(true);
                        Invoke("DnevnikOpen", 1);
                        ResetFirstRoom();
                        ResetShahta();
                        ResetPtica();
                        ResetTeleshki();
                        firstRoom.RandomZnach();
                        halk.SetActive(true);
                        openDoors.CloseAllDoors();
                    }
                }

                else if (DAY2 && !((TakeListok.vibrali1 && TakeListok.vibrali2 && TakeListok.vibrali3 && TakeListok.vibrali4 && TakeListok.vibrali5) && BurMachina.BoorSdelali && (Nanometr.PODKYTILI1 && Nanometr1.PODKYTILI2 && Nanometr2.PODKYTILI3)))
                {
                    AreYouShure.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        List1.SetActive(false);
                        List2.SetActive(false);
                        List3.SetActive(false);
                        List4.SetActive(false);
                        After1.SetActive(false);
                        After2.SetActive(false);
                        After3.SetActive(false);
                        After4.SetActive(false);

                        Diary1.SetActive(false);
                        Diary2.SetActive(true);
                        RoomWithRart.katitsa = true;
                        Peretashit.transform.localPosition = new Vector3(26.7f, -1.71f, -25.46f);
                        RoomWithRart.canDvig = false;
                        Stones.poloshili = false;
                        RoomWithRart.telesh = false;
                        TemneyushiyEkran.SetActive(true);
                        Invoke("DnevnikOpen", 1);
                        ResetFirstRoom();
                        ResetShahta();
                        ResetPtica();
                        ResetTeleshki();
                        firstRoom.RandomZnach();
                        halk.SetActive(true);
                        openDoors.CloseAllDoors();
                    }
                }

                if ((DAY3 && (TakeListok.vibrali1 && TakeListok.vibrali2 && TakeListok.vibrali3 && TakeListok.vibrali4 && TakeListok.vibrali5) && (Nanometr.PODKYTILI1 && Nanometr1.PODKYTILI2 && Nanometr2.PODKYTILI3) && RoomWithRart.CartYes) || CAN3)
                {
                    Babaka.SetActive(true);
                    F.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        List1.SetActive(false);
                        List2.SetActive(false);
                        List3.SetActive(false);
                        List4.SetActive(false);
                        After1.SetActive(false);
                        After2.SetActive(false);
                        After3.SetActive(false);
                        After4.SetActive(false);

                        Diary2.SetActive(false);
                        Diary3.SetActive(true);
                        RoomWithRart.katitsa = true;
                        Peretashit.transform.localPosition = new Vector3(26.7f, -1.71f, -25.46f);
                        RoomWithRart.canDvig = false;
                        Stones.poloshili = false;
                        bur.transform.localPosition = new Vector3(1.09f, -6.67f, -16.04f);
                        RoomWithRart.telesh = false;
                        TemneyushiyEkran.SetActive(true);
                        Invoke("DnevnikOpen", 1);
                        ResetFirstRoom();
                        ResetShahta();
                        ResetPtica();
                        ResetTeleshki();
                        firstRoom.RandomZnach();
                        openDoors.CloseAllDoors();
                    }
                }

                else if ((DAY3 && !((TakeListok.vibrali1 && TakeListok.vibrali2 && TakeListok.vibrali3 && TakeListok.vibrali4 && TakeListok.vibrali5) && (Nanometr.PODKYTILI1 && Nanometr1.PODKYTILI2 && Nanometr2.PODKYTILI3) && RoomWithRart.CartYes)))
                {
                    AreYouShure.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        List1.SetActive(false);
                        List2.SetActive(false);
                        List3.SetActive(false);
                        List4.SetActive(false);
                        After1.SetActive(false);
                        After2.SetActive(false);
                        After3.SetActive(false);
                        After4.SetActive(false);

                        Diary2.SetActive(false);
                        Diary3.SetActive(true);
                        RoomWithRart.katitsa = true;
                        Peretashit.transform.localPosition = new Vector3(26.7f, -1.71f, -25.46f);
                        RoomWithRart.canDvig = false;
                        Stones.poloshili = false;
                        bur.transform.localPosition = new Vector3(1.09f, -6.67f, -16.04f);
                        RoomWithRart.telesh = false;
                        TemneyushiyEkran.SetActive(true);
                        Invoke("DnevnikOpen", 1);
                        ResetFirstRoom();
                        ResetShahta();
                        ResetPtica();
                        ResetTeleshki();
                        firstRoom.RandomZnach();
                        openDoors.CloseAllDoors();
                    }
                }

                if ((DAY4 && (TakeListok.vibrali1 && TakeListok.vibrali2 && TakeListok.vibrali3 && TakeListok.vibrali4 && TakeListok.vibrali5) && BurMachina.BoorSdelali && RoomWithRart.CartYes) || CAN4)
                {
                    F.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        List1.SetActive(false);
                        List2.SetActive(false);
                        List3.SetActive(false);
                        List4.SetActive(false);
                        After1.SetActive(false);
                        After2.SetActive(false);
                        After3.SetActive(false);
                        After4.SetActive(false);

                        Diary3.SetActive(false);
                        Diary4.SetActive(true);
                        RoomWithRart.katitsa = true;
                        Peretashit.transform.localPosition = new Vector3(26.7f, -1.71f, -25.46f);
                        RoomWithRart.canDvig = false;
                        Stones.poloshili = false;
                        bur.transform.localPosition = new Vector3(-24.55f, -6.67f, -5.01f);
                        bur.transform.localRotation = Quaternion.Euler(0, 180, 0);
                        RoomWithRart.telesh = false;
                        TemneyushiyEkran.SetActive(true);
                        Invoke("DnevnikOpen", 1);
                        ResetShahta();
                        ResetPtica();
                        ResetTeleshki();
                        firstRoom.RandomZnach();
                        openDoors.CloseAllDoors();
                        Cart.prikrepiliList = true;
                    }
                }

                else if (DAY4 && !((TakeListok.vibrali1 && TakeListok.vibrali2 && TakeListok.vibrali3 && TakeListok.vibrali4 && TakeListok.vibrali5) && BurMachina.BoorSdelali && RoomWithRart.CartYes))
                {
                    AreYouShure.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        List1.SetActive(false);
                        List2.SetActive(false);
                        List3.SetActive(false);
                        List4.SetActive(false);
                        After1.SetActive(false);
                        After2.SetActive(false);
                        After3.SetActive(false);
                        After4.SetActive(false);

                        Diary3.SetActive(false);
                        Diary4.SetActive(true);
                        RoomWithRart.katitsa = true;
                        Peretashit.transform.localPosition = new Vector3(26.7f, -1.71f, -25.46f);
                        RoomWithRart.canDvig = false;
                        Stones.poloshili = false;
                        bur.transform.localPosition = new Vector3(-24.55f, -6.67f, -5.01f);
                        bur.transform.localRotation = Quaternion.Euler(0, 180, 0);
                        RoomWithRart.telesh = false;
                        TemneyushiyEkran.SetActive(true);
                        Invoke("DnevnikOpen", 1);
                        ResetShahta();
                        ResetPtica();
                        ResetTeleshki();
                        firstRoom.RandomZnach();
                        openDoors.CloseAllDoors();
                        Cart.prikrepiliList = true;
                    }
                }

                if ((DAY5 && (Nanometr.PODKYTILI1 && Nanometr1.PODKYTILI2 && Nanometr2.PODKYTILI3) && BurMachina.BoorSdelali && RoomWithRart.CartYes))
                {
                    F.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        List1.SetActive(false);
                        List2.SetActive(false);
                        List3.SetActive(false);
                        List4.SetActive(false);
                        After1.SetActive(false);
                        After2.SetActive(false);
                        After3.SetActive(false);
                        After4.SetActive(false);

                        Diary4.SetActive(false);
                        Diary5.SetActive(true);
                        EndGame = true;
                        TemneyushiyEkran.SetActive(true);
                        Invoke("DnevnikOpen", 1);
                    }
                }
                else if (DAY5 && !((Nanometr.PODKYTILI1 && Nanometr1.PODKYTILI2 && Nanometr2.PODKYTILI3) && BurMachina.BoorSdelali && RoomWithRart.CartYes))
                {
                    AreYouShure.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        List1.SetActive(false);
                        List2.SetActive(false);
                        List3.SetActive(false);
                        List4.SetActive(false);
                        After1.SetActive(false);
                        After2.SetActive(false);
                        After3.SetActive(false);
                        After4.SetActive(false);

                        Diary4.SetActive(false);
                        Diary5.SetActive(true);
                        EndGame = true;
                        TemneyushiyEkran.SetActive(true);
                        Invoke("DnevnikOpen", 1);
                    }
                }

            }
            else {
                F.SetActive(false);
                AreYouShure.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Return)) RaspInstr.SetActive(false);

        }
        else {
            F.SetActive(false);
            AreYouShure.SetActive(false);
        }

        if (diary.activeInHierarchy && Input.GetKeyDown(KeyCode.Space))
        {
            if ((Diary.d1 == 2 && DAYS.DAY1) || (Diary.d2 == 2 && DAYS.DAY2) || (Diary.d3 == 2 && DAYS.DAY3) || (Diary.d4 == 2 && DAYS.DAY4) || (Diary.d5 == 1 && DAYS.DAY5)) NewDay();
        }
    }

    public void DAYFIRST()
    {
        day = 1;
        Raspisanie.SetTexture("_MainTex", D1);
        DAY1 = true;
        DAY2 = false;
        DAY3 = false;
        DAY4 = false;
        DAY5 = false;
    }

    public void DAYSECOND()
    {
        day = 2;
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
        day = 3;
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
        day = 4;
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
        day = 5;
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
        textic.SetActive(false);
        button.SetActive(true);
        diary.SetActive(true);
        Cursor.visible = true;
        FonShum.Stop();
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
        diary.GetComponent<Animator>().SetBool("Zakr", false);
        Invoke("DnevnikClose", 1f);
        Spase.color = new Color(0, 0, 0, 120);
    }

    private void DnevnikClose() {
        if (!EndGame) {
            diary.SetActive(false);
            Door1.GetComponent<Animator>().SetBool("Open", false);
            Door2.GetComponent<Animator>().SetBool("open", false);
            Invoke("ZaKrPanel", 3f);
            Cursor.visible = false;
            DenNStart();
            Zagruzka.SetActive(true);
            StartCoroutine(saveLoadManager.CaptureScreenshotAndSave());
        }
        else
        {
            Door1.GetComponent<Animator>().SetBool("Open", false);
            Door2.GetComponent<Animator>().SetBool("open", false);
            if (Diary.Bad >= 5) {
                diary.SetActive(false);
                TemneyushiyEkran.SetActive(false);
                Cursor.visible = false;
                Zabludilsa.GetComponent<BadEnd>().enabled = true;
            }
            else
            {
                diary.SetActive(false);
                TemneyushiyEkran.SetActive(false);
                Cursor.visible = false;
                playerCamera.rotation = Quaternion.Euler(0, 0, 0);
                Player.transform.position = new Vector3(9.152f, 0.167f, -18f);
                GoodEnd();
            }
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
        Den2.SetActive(false);
        Den3.SetActive(false);
        Den4.SetActive(false);
        Den5.SetActive(false);
        FonShum.Play();
        Zagruzka.SetActive(false);
    }

    private void DenNStart()
    {
        if (DAY2) Den2.SetActive(true);
        else if (DAY3) Den3.SetActive(true);
        else if (DAY4) Den4.SetActive(true);
        else if (DAY5) Den5.SetActive(true);
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

    private void GoodEnd()
    {
        playerCamera.GetComponent<CinemachineBrain>().enabled = false;
        Player.GetComponent<AnimatorCotroller>().enabled = false;
        playerCamera.position = new Vector3(9.135f, 1.91f, -16.694f);
        FonShum.Stop();
        NachZvuk.Play();
        Invoke("GoodKonec", 5f);
    }

    private void GoodKonec()
    {
        Door1.GetComponent<Animator>().SetBool("Open", true);
        Door2.GetComponent<Animator>().SetBool("open", true);
        NachZvuk.Stop();
        HappyAudio.Play();
        HappyPanel.SetActive(true);
        Invoke("cursor", 20f);
    }

    private void cursor()
    {
        Cursor.visible = true;
    }

    
}
