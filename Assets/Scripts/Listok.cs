using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listok : MonoBehaviour
{
    public GameObject Galochka1;
    public GameObject Galochka2;
    public GameObject Galochka3;
    public GameObject Galochka4;
    public GameObject Galochka5;
    public void H1(RectTransform x)
    {
        Galochka1.SetActive(true);
        Galochka1.transform.localPosition = x.position;
        Debug.Log(Galochka1.transform.position);
    }
    public void H2(float x)
    {
        Galochka2.SetActive(true);
        Galochka2.transform.localPosition = new Vector3(x, Galochka2.transform.localPosition.y, Galochka2.transform.localPosition.z);
    }
}
