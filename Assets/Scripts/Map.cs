using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    [SerializeField] private GameObject MapPanel;
    private Image image;
    [SerializeField] Sprite lab;
    [SerializeField] Sprite bur;
    [SerializeField] Sprite mach;
    [SerializeField] Sprite ptica;
    [SerializeField] Sprite osn;
    [SerializeField] Sprite vagonetki;
    [SerializeField] Sprite koridor;

    private void Update()
    {
        if (MapPanel.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                MapPanel.SetActive(false);
            }
        }

        if (Input.GetKey(KeyCode.M))
        {
            MapPanel.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.M))
        {
            MapPanel.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lab") MapPanel.GetComponent<Image>().sprite = lab;
        if (other.gameObject.tag == "BurRoom") MapPanel.GetComponent<Image>().sprite = bur;
        if (other.gameObject.tag == "Machina") MapPanel.GetComponent<Image>().sprite = mach;
        if (other.gameObject.tag == "PticaRoom") MapPanel.GetComponent<Image>().sprite = ptica;
        if (other.gameObject.tag == "Osn") MapPanel.GetComponent<Image>().sprite = osn;
        if (other.gameObject.tag == "Vagonetki") MapPanel.GetComponent<Image>().sprite = vagonetki;
        if (other.gameObject.tag == "Koridor") MapPanel.GetComponent<Image>().sprite = koridor;
    }
}
