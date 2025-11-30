using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shkala : MonoBehaviour
{
    public GameObject ShkalaPanel;
    public GameObject Strelochka;
    public AudioSource Ok;

    public float speed = 2f;
    public float minY = -2f;
    public float maxY = 2f;

    private bool movingUp = true;
    public static bool isStopped = false;
    public static int Moshnost;
    void Update()
    {
        if (isStopped) return;
        Vector3 pos = Strelochka.transform.localPosition;

        if (movingUp)
        {
            pos.y += speed * Time.deltaTime;
            if (pos.y >= maxY)
            {
                pos.y = maxY;
                movingUp = false;
            }
        }
        else
        {
            pos.y -= speed * Time.deltaTime;
            if (pos.y <= minY)
            {
                pos.y = minY;
                movingUp = true;
            }
        }
        Strelochka.transform.localPosition = pos;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Ok.Play();
            isStopped = true;
            Invoke("zakr", 1f);
        }
    }

    private void zakr()
    {
        ShkalaPanel.SetActive(false);
    }
}
