using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Diary : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private GameObject left;
    [SerializeField] private GameObject right;
    [SerializeField] private GameObject F;
    [SerializeField] private GameObject diary;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject textic;
    [SerializeField] private TextMeshProUGUI space;
    [SerializeField] private GameObject list1;
    [SerializeField] private GameObject list2;
    [SerializeField] private GameObject list3;
    [SerializeField] private GameObject list4;
    [SerializeField] private GameObject day1;
    [SerializeField] private GameObject day2;
    [SerializeField] private GameObject day3;
    [SerializeField] private GameObject day4;
    [SerializeField] private GameObject day5;
    [SerializeField] private GameObject after1;
    [SerializeField] private GameObject after2;
    [SerializeField] private GameObject after3;
    [SerializeField] private GameObject after4;
    [SerializeField] private GameObject left1;
    [SerializeField] private GameObject left2;
    [SerializeField] private GameObject left3;
    [SerializeField] private GameObject left4;
    [SerializeField] private GameObject left5;
    [SerializeField] private GameObject left6;
    [SerializeField] private GameObject left7;
    [SerializeField] private GameObject left8;
    [SerializeField] private GameObject left9;
    [SerializeField] private GameObject left10;
    [SerializeField] private GameObject left11;
    [SerializeField] private GameObject left12;
    [SerializeField] private GameObject left13;
    [SerializeField] private GameObject right1;
    [SerializeField] private GameObject right2;
    [SerializeField] private GameObject right3;
    [SerializeField] private GameObject right4;
    [SerializeField] private GameObject right5;
    [SerializeField] private GameObject right6;
    [SerializeField] private GameObject right7;
    [SerializeField] private GameObject right8;
    [SerializeField] private GameObject right9;
    [SerializeField] private GameObject right10;
    [SerializeField] private GameObject right11;
    [SerializeField] private GameObject right12;
    [SerializeField] private GameObject dayOne;
    [SerializeField] private GameObject without;
    public static int Good = 0;
    public static int Bad = 0;
    public static int d1 = 0;
    public static int d2 = 0;
    public static int d3 = 0;
    public static int d4 = 0;
    public static int d5 = 0;
    GameObject den;
    void Start()
    {

    }

    void Update()
    {
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit Hit, 4f, pickUpLayerMask))
        {
            if (Hit.collider.tag == "Diary")
            {
                F.SetActive(true);
                if (Input.GetKeyDown(KeyCode.J))
                {
                    Debug.Log(000);
                    diary.SetActive(true);
                    button.SetActive(false);
                    textic.SetActive(true);
                    Cursor.visible = true;
                    left1.SetActive(true);
                    left2.SetActive(true);
                    left3.SetActive(true);
                    left4.SetActive(true);
                    left5.SetActive(true);
                    left6.SetActive(true);
                    left7.SetActive(true);
                    left8.SetActive(true);
                    left9.SetActive(true);
                    left10.SetActive(true);
                    left11.SetActive(true);
                    left12.SetActive(true);
                    left13.SetActive(true);
                    right1.SetActive(true);
                    right2.SetActive(true);
                    right3.SetActive(true);
                    right4.SetActive(true);
                    right5.SetActive(true);
                    right6.SetActive(true);
                    right7.SetActive(true);
                    right8.SetActive(true);
                    right9.SetActive(true);
                    right10.SetActive(true);
                    right11.SetActive(true);
                    right12.SetActive(true);
                    Proverka();
                }
            }
            else F.SetActive(false);
        }
        else F.SetActive(false);

        if (Input.GetKeyDown(KeyCode.Return) && diary.activeInHierarchy)
        {
            diary.SetActive(false);
            Cursor.visible = false;
            left1.SetActive(false);
            left2.SetActive(false);
            left3.SetActive(false);
            left4.SetActive(false);
            left5.SetActive(false);
            left6.SetActive(false);
            left7.SetActive(false);
            left8.SetActive(false);
            left9.SetActive(false);
            left10.SetActive(false);
            left11.SetActive(false);
            left12.SetActive(false);
            left13.SetActive(false);
            right1.SetActive(false);
            right2.SetActive(false);
            right3.SetActive(false);
            right4.SetActive(false);
            right5.SetActive(false);
            right6.SetActive(false);
            right7.SetActive(false);
            right8.SetActive(false);
            right9.SetActive(false);
            right10.SetActive(false);
            right11.SetActive(false);
            right12.SetActive(false);
        }
    }

    public void Dnevnik(GameObject Dnevnichok)
    {
       if (Dnevnichok.GetComponent<Button>().enabled) {
            if (DAYS.DAY1) { den = GameObject.Find("Δενό1"); }
            if (DAYS.DAY2) { den = GameObject.Find("Δενό2"); }
            if (DAYS.DAY3) { den = GameObject.Find("Δενό3"); }
            if (DAYS.DAY4) { den = GameObject.Find("Δενό4"); }
            if (DAYS.DAY5) { den = GameObject.Find("Δενό5"); }
            if (Dnevnichok.tag == "Good")
            {
                Good += 1;
                GameObject delet = den.transform.GetChild(1).gameObject;
                delet.SetActive(false);
                if (DAYS.DAY1) d1 += 1;
                if (DAYS.DAY2) d2 += 1;
                if (DAYS.DAY3) d3 += 1;
                if (DAYS.DAY4) d4 += 1;
                if (DAYS.DAY5) d5 += 1;
                Debug.Log("Dood:" + Good.ToString());
            }
            else if (Dnevnichok.tag == "Bad")
            {
                Bad += 1;
                GameObject delet = den.transform.GetChild(0).gameObject;
                delet.SetActive(false);
                if (DAYS.DAY1) d1 += 1;
                if (DAYS.DAY2) d2 += 1;
                if (DAYS.DAY3) d3 += 1;
                if (DAYS.DAY4) d4 += 1;
                if (DAYS.DAY5) d5 += 1;
                Debug.Log("Bad:" + Bad.ToString());
            }
            else if (Dnevnichok.tag == "Good1")
            {
                Good += 1;
                GameObject delet = den.transform.GetChild(3).gameObject;
                delet.SetActive(false);
                if (DAYS.DAY1) d1 += 1;
                if (DAYS.DAY2) d2 += 1;
                if (DAYS.DAY3) d3 += 1;
                if (DAYS.DAY4) d4 += 1;
                if (DAYS.DAY5) d5 += 1;
                Debug.Log("Dood:" + Good.ToString());
            }
            else if (Dnevnichok.tag == "Bad1")
            {
                Bad += 1;
                GameObject delet = den.transform.GetChild(2).gameObject;
                delet.SetActive(false);
                if (DAYS.DAY1) d1 += 1;
                if (DAYS.DAY2) d2 += 1;
                if (DAYS.DAY3) d3 += 1;
                if (DAYS.DAY4) d4 += 1;
                if (DAYS.DAY5) d5 += 1;
                Debug.Log("Bad:" + Bad.ToString());
            }
            Button buttonDevnic = Dnevnichok.GetComponent<Button>();
            Dnevnichok.GetComponent<Button>().enabled = false;
            GameObject text = Dnevnichok.transform.GetChild(0).gameObject;
            text.GetComponent<TextMeshProUGUI>().fontSize += 10f;
            TMP_FontAsset font = Resources.Load<TMP_FontAsset>("Πσκξοθρό");
            text.GetComponent<TextMeshProUGUI>().font = font;
            Dnevnichok.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            if ((d1 == 2 && DAYS.DAY1) || (d2 == 2 && DAYS.DAY2) || (d3 == 2 && DAYS.DAY3) || (d4 == 2 && DAYS.DAY4) || (d5 == 2 && DAYS.DAY5))
            {
                space.color = new Color(0, 0, 0, 255);
            }
        }
    }


    private void Proverka()
    {
        if (DAYS.DAY1) right5.SetActive(false);
        if (DAYS.DAY2) right7.SetActive(false);
        if (DAYS.DAY3) right9.SetActive(false);
        if (DAYS.DAY4) right11.SetActive(false);
    }
    public void DayOne()
    {
        if (DAYS.DAY1) without.SetActive(true);
        else dayOne.SetActive(true);
    }
}
