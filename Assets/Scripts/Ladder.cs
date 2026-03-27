using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private GameObject Player;
    [SerializeField] private float speed = 0.005f;

    void Start()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.W))
            {
                Player.GetComponent<Rigidbody>().useGravity = false;
                Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + speed, Player.transform.position.z);
            }

            if (Input.GetKey(KeyCode.S))
            {
                Player.GetComponent<Rigidbody>().useGravity = false;
                Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y - speed, Player.transform.position.z);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Player.GetComponent<Rigidbody>().useGravity = true;
    }
}
