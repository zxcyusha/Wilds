using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurMachina : MonoBehaviour
{
    public Transform playerCamera;
    public LayerMask pickUpLayerMask;
    public GameObject NashmiNaF;
    public GameObject ShkalaPanel;
    public GameObject Strelochka;

    public float speed = 2f;
    public float minY = -2f;
    public float maxY = 2f;

    private bool movingUp = true;
    private bool isStopped = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit hit, 3f, pickUpLayerMask))
        {
            if (hit.collider.CompareTag("Shkala"))
            {
                NashmiNaF.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    ShkalaPanel.SetActive(true);
                    if (isStopped) return;
                    Vector3 pos = transform.localPosition;

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
                    transform.localPosition = pos;

                }
            }
            else
            {
                NashmiNaF.SetActive(false);
            }
        }
        else
        {
            NashmiNaF.SetActive(false);
        }

    }
}
