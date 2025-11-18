
using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    public Transform playerCamera;
    public float pickRange = 3f;
    public GameObject E;
    public string pickableTag = "Door";

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit Hit, pickRange))
            {
                if ((Hit.collider.CompareTag("Door")))
                {
                    Hit.collider.gameObject.transform.Rotate(Vector3.up, 90, Space.World);
                    Debug.Log(0);
                }

            }
        }
    }

}
