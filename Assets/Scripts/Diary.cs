using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Diary : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    public GameObject F;
    public GameObject diary;
    public GameObject button;
    public GameObject textic;
    public TextMeshProUGUI space;
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
                if (Input.GetKeyDown(KeyCode.F))
                {
                    diary.SetActive(true);
                    button.SetActive(false);
                    textic.SetActive(true);
                    Cursor.visible = true;
                }
            }
            else F.SetActive(false);
        }
        else F.SetActive(false);

        if (Input.GetKeyDown(KeyCode.I) && diary.activeInHierarchy)
        {
            diary.SetActive(false);
            Cursor.visible = false;
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

}
