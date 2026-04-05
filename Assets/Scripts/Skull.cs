using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject objectGrabPointTransform;
    [SerializeField] private Camera cam;
    [SerializeField] private AudioSource scarySound;
    [SerializeField] private GameObject redPanel;
    private GameObject targetObject;
    public bool isScull;

    private void Start()
    {
        targetObject = objectGrabPointTransform.transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (isScull)
        {
            objectGrabPointTransform.transform.GetChild(1).gameObject.SetActive(false);
            objectGrabPointTransform.transform.GetChild(0).gameObject.SetActive(true);
        }

        Renderer renderer = targetObject.GetComponent<Renderer>();

        if (isScull)
        {
            if (IsObjectInFrustum(renderer, cam))
            {
                Invoke("Scrimer", 0.5f);
                isScull = false;
            }
        }
    }

    bool IsObjectInFrustum(Renderer objRenderer, Camera cam)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);

        return GeometryUtility.TestPlanesAABB(planes, objRenderer.bounds);
    }

    private void Scrimer()
    {
        scarySound.Play();
        redPanel.SetActive(true);
        Invoke("NoScrimer", 1f);
    }

    private void NoScrimer()
    {
        objectGrabPointTransform.transform.GetChild(1).gameObject.SetActive(true);
        objectGrabPointTransform.transform.GetChild(0).gameObject.SetActive(false);
    }
}
