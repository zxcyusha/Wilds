using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Nanometr : MonoBehaviour
{
    [SerializeField] private GameObject StrelkaZel;
    [SerializeField] private GameObject StrelkaCher;
    public Transform playerCameraTransform;
    public LayerMask pickUpLayerMask;
    public GameObject StrelkaL;
    public GameObject StrelkaR;
    public AudioSource Molodec;
    public AudioSource KranKrutitsa;
    public GameObject krutilka;
    public float Left;
    public float Right;
    public float speed = 0.01f;
    public bool z1 = true;
    private float rotZel;
    public static bool PODKYTILI1 = false;

    void Start()
    {
        StrelkaRotation();
    }

    void Update()
    {
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit Hit, 3f, pickUpLayerMask))
        {
            if (Hit.collider.CompareTag("Nanometr") && z1)
            {
                StrelkaL.SetActive(true);
                StrelkaR.SetActive(true);
            }
            else
            {
                StrelkaL.SetActive(false);
                StrelkaR.SetActive(false);
            }

            if ((Hit.collider.CompareTag("Nanometr") && z1 == true))
                {
                if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Q))) KranKrutitsa.Play();
                if ((Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.Q))) KranKrutitsa.Stop();
                if (Input.GetKey(KeyCode.E))
                {
                    StrelkaCher.transform.Rotate(Vector3.right * -speed);
                    krutilka.transform.Rotate(Vector3.forward * speed);
                }
                if (Input.GetKey(KeyCode.Q))
                {
                    StrelkaCher.transform.Rotate(Vector3.right * speed);
                    krutilka.transform.Rotate(Vector3.forward * -speed);
                }

                if ((Quaternion.Angle(StrelkaCher.transform.rotation, StrelkaZel.transform.rotation) < 2f))
                {
                    {
                        Molodec.Play();
                        StrelkaL.SetActive(false);
                        StrelkaR.SetActive(false);
                        KranKrutitsa.Stop();
                        z1 = false;
                        PODKYTILI1 = true;
                    }
                }
            }
        }
        else
        {
            StrelkaL.SetActive(false);
            StrelkaR.SetActive(false);
        }
    }
    public void StrelkaRotation()
    {
        rotZel = Random.Range(Left, Right);
        StrelkaZel.transform.rotation = Quaternion.Euler(rotZel, 90, 0);
    }

}
