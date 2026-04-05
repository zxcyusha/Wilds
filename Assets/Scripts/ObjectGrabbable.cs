using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody objectRigidbody;
    private Transform objectGrabPointTransform;

    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();

    }

    public void Grab(GameObject objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform.transform;
        objectRigidbody.useGravity = false;
        objectRigidbody.isKinematic = true;
        Invoke("aboba", 0.00001f);

        this.transform.SetParent(objectGrabPointTransform.transform);
    }

    public void Drop()
    {
        this.objectGrabPointTransform = null;
        objectRigidbody.useGravity = true;
        objectRigidbody.isKinematic = false;
        this.transform.SetParent(null);
    }
    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            float lerpSpeed = 100f;
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            objectRigidbody.MovePosition(newPosition);
        }
    }

    private void aboba() { 
        
        if (PlayerPickUpDrop.WhatHolding == "Sheet") {
            transform.rotation = Quaternion.Euler(0, 0, -90);
            transform.localRotation = Quaternion.Euler(0, 0, -90);
        }
        else if (PlayerPickUpDrop.WhatHolding == "плотностьь")
        {
            transform.rotation = Quaternion.Euler(-180, 0, 0);
            transform.localRotation = Quaternion.Euler(-180, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 265, 0);
            transform.localRotation = Quaternion.Euler(0, 265, 0);
        }
    }


}