using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nanometr : MonoBehaviour
{
    public GameObject StrelkaZel;
    public GameObject StrelkaCher;
    public Transform playerCameraTransform;
    public LayerMask pickUpLayerMask;
    public GameObject StrelkaL;
    public GameObject StrelkaR;
    public float Left;
    public float Right;
    public float speed = 8f;

    void Start()
    {
        StrelkaL.SetActive(false);
        StrelkaR.SetActive(false);
        StrelkaRotation();
    }

    void Update()
    {
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit Hit, 3f, pickUpLayerMask))
        {
            if (Hit.collider.CompareTag("Nanometr"))
            {
                StrelkaL.SetActive(true);
                StrelkaR.SetActive(true);
                if (Input.GetKey(KeyCode.E))
                {
                    StrelkaCher.transform.Rotate(Vector3.right * -speed * Time.deltaTime);
                }
                else if (Input.GetKey(KeyCode.Q))
                {
                   StrelkaCher.transform.Rotate(Vector3.right * speed * Time.deltaTime);
                }
            }
            else
            {
                StrelkaL.SetActive(false);
                StrelkaR.SetActive(false);
            }
        }
        else
        {
            StrelkaL.SetActive(false);
            StrelkaR.SetActive(false);
        }
    }
    private void StrelkaRotation()
    {
        StrelkaZel.transform.localRotation = Quaternion.Euler(Random.Range(Left, Right), 0, 0);
    }
}
