using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeListok : MonoBehaviour
{
    public Transform playerCamera;
    public LayerMask pickUpLayerMask;
    public GameObject EandR;
    public GameObject List;
    public Image im1;
    public Image im2;
    public Image im3;
    public Image im4;
    public Image im5;
    public Image im6;
    public Image im7;
    public Image im8;
    public Image im9;
    public Image im10;
    public Image im11;
    public Image im12;
    public Image im13;
    public Image im14;
    public Image im15;
    public Image im16;
    public Image im17;
    public Image im18;
    public Image im19;
    public Image im20;
    public Image im21;
    public Image im22;
    public Image im23;
    public Image im24;
    public Image im25;
    public Image im26;
    public Image im27;
    public Image im28;
    public Image im29;
    public Image im30;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && List.activeInHierarchy)
        {
            List.SetActive(false);
            Cursor.visible = false;
        }
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit hit, 4f, pickUpLayerMask))
        {
            if (hit.collider.CompareTag("Listok"))
            {
                EandR.SetActive(true);
                if (Input.GetKeyDown(KeyCode.R))
                {
                    if (!List.activeInHierarchy)
                    {
                        List.SetActive(true);
                        Cursor.visible = true;
                    }
                }
            }
            else EandR.SetActive(false);
        }
        else EandR.SetActive(false);
    }

    public void H1()
    {
        im1.color = new Color(255, 255, 255, 1);
        im2.color = new Color(255, 255, 255, 0);
        im3.color = new Color(255, 255, 255, 0);
        im4.color = new Color(255, 255, 255, 0);
    }
    public void H2()
    {
        im2.color = new Color(255, 255, 255, 1);
        im1.color = new Color(255, 255, 255, 0);
        im3.color = new Color(255, 255, 255, 0);
        im4.color = new Color(255, 255, 255, 0);
    }
    public void H3()
    {
        im3.color = new Color(255, 255, 255, 1);
        im2.color = new Color(255, 255, 255, 0);
        im1.color = new Color(255, 255, 255, 0);
        im4.color = new Color(255, 255, 255, 0);
    }
    public void H4()
    {
        im4.color = new Color(255, 255, 255, 1);
        im2.color = new Color(255, 255, 255, 0);
        im3.color = new Color(255, 255, 255, 0);
        im1.color = new Color(255, 255, 255, 0);
    }
    
    public void G1()
    {
        im5.color = new Color(255, 255, 255, 1);
        im6.color = new Color(255, 255, 255, 0);
        im7.color = new Color(255, 255, 255, 0);
        im8.color = new Color(255, 255, 255, 0);
        im9.color = new Color(255, 255, 255, 0);
        im10.color = new Color(255, 255, 255, 0);
        im11.color = new Color(255, 255, 255, 0);
        im12.color = new Color(255, 255, 255, 0);
        im13.color = new Color(255, 255, 255, 0);
        im14.color = new Color(255, 255, 255, 0);
        im15.color = new Color(255, 255, 255, 0);
    }
    public void G2()
    {
        im6.color = new Color(255, 255, 255, 1);
        im5.color = new Color(255, 255, 255, 0);
        im7.color = new Color(255, 255, 255, 0);
        im8.color = new Color(255, 255, 255, 0);
        im9.color = new Color(255, 255, 255, 0);
        im10.color = new Color(255, 255, 255, 0);
        im11.color = new Color(255, 255, 255, 0);
        im12.color = new Color(255, 255, 255, 0);
        im13.color = new Color(255, 255, 255, 0);
        im14.color = new Color(255, 255, 255, 0);
        im15.color = new Color(255, 255, 255, 0);
    }
    public void G3()
    {
        im7.color = new Color(255, 255, 255, 1);
        im6.color = new Color(255, 255, 255, 0);
        im5.color = new Color(255, 255, 255, 0);
        im8.color = new Color(255, 255, 255, 0);
        im9.color = new Color(255, 255, 255, 0);
        im10.color = new Color(255, 255, 255, 0);
        im11.color = new Color(255, 255, 255, 0);
        im12.color = new Color(255, 255, 255, 0);
        im13.color = new Color(255, 255, 255, 0);
        im14.color = new Color(255, 255, 255, 0);
        im15.color = new Color(255, 255, 255, 0);
    }
    public void G4()
    {
        im8.color = new Color(255, 255, 255, 1);
        im6.color = new Color(255, 255, 255, 0);
        im7.color = new Color(255, 255, 255, 0);
        im5.color = new Color(255, 255, 255, 0);
        im9.color = new Color(255, 255, 255, 0);
        im10.color = new Color(255, 255, 255, 0);
        im11.color = new Color(255, 255, 255, 0);
        im12.color = new Color(255, 255, 255, 0);
        im13.color = new Color(255, 255, 255, 0);
        im14.color = new Color(255, 255, 255, 0);
        im15.color = new Color(255, 255, 255, 0);
    }
    public void G5()
    {
        im9.color = new Color(255, 255, 255, 1);
        im6.color = new Color(255, 255, 255, 0);
        im7.color = new Color(255, 255, 255, 0);
        im8.color = new Color(255, 255, 255, 0);
        im5.color = new Color(255, 255, 255, 0);
        im10.color = new Color(255, 255, 255, 0);
        im11.color = new Color(255, 255, 255, 0);
        im12.color = new Color(255, 255, 255, 0);
        im13.color = new Color(255, 255, 255, 0);
        im14.color = new Color(255, 255, 255, 0);
        im15.color = new Color(255, 255, 255, 0);
    }
    public void G6()
    {
        im10.color = new Color(255, 255, 255, 1);
        im6.color = new Color(255, 255, 255, 0);
        im7.color = new Color(255, 255, 255, 0);
        im8.color = new Color(255, 255, 255, 0);
        im9.color = new Color(255, 255, 255, 0);
        im5.color = new Color(255, 255, 255, 0);
        im11.color = new Color(255, 255, 255, 0);
        im12.color = new Color(255, 255, 255, 0);
        im13.color = new Color(255, 255, 255, 0);
        im14.color = new Color(255, 255, 255, 0);
        im15.color = new Color(255, 255, 255, 0);
    }
        public void G7()
    {
        im11.color = new Color(255, 255, 255, 1);
        im6.color = new Color(255, 255, 255, 0);
        im7.color = new Color(255, 255, 255, 0);
        im8.color = new Color(255, 255, 255, 0);
        im9.color = new Color(255, 255, 255, 0);
        im10.color = new Color(255, 255, 255, 0);
        im5.color = new Color(255, 255, 255, 0);
        im12.color = new Color(255, 255, 255, 0);
        im13.color = new Color(255, 255, 255, 0);
        im14.color = new Color(255, 255, 255, 0);
        im15.color = new Color(255, 255, 255, 0);

    }
    public void G8()
    {
        im12.color = new Color(255, 255, 255, 1);
        im6.color = new Color(255, 255, 255, 0);
        im7.color = new Color(255, 255, 255, 0);
        im8.color = new Color(255, 255, 255, 0);
        im9.color = new Color(255, 255, 255, 0);
        im10.color = new Color(255, 255, 255, 0);
        im11.color = new Color(255, 255, 255, 0);
        im5.color = new Color(255, 255, 255, 0);
        im13.color = new Color(255, 255, 255, 0);
        im14.color = new Color(255, 255, 255, 0);
        im15.color = new Color(255, 255, 255, 0);
    }
    public void G9()
    {
        im13.color = new Color(255, 255, 255, 1);
        im6.color = new Color(255, 255, 255, 0);
        im7.color = new Color(255, 255, 255, 0);
        im8.color = new Color(255, 255, 255, 0);
        im9.color = new Color(255, 255, 255, 0);
        im10.color = new Color(255, 255, 255, 0);
        im11.color = new Color(255, 255, 255, 0);
        im12.color = new Color(255, 255, 255, 0);
        im5.color = new Color(255, 255, 255, 0);
        im14.color = new Color(255, 255, 255, 0);
        im15.color = new Color(255, 255, 255, 0);
    }
    public void G10()
    {
        im14.color = new Color(255, 255, 255, 1);
        im6.color = new Color(255, 255, 255, 0);
        im7.color = new Color(255, 255, 255, 0);
        im8.color = new Color(255, 255, 255, 0);
        im9.color = new Color(255, 255, 255, 0);
        im10.color = new Color(255, 255, 255, 0);
        im11.color = new Color(255, 255, 255, 0);
        im12.color = new Color(255, 255, 255, 0);
        im13.color = new Color(255, 255, 255, 0);
        im5.color = new Color(255, 255, 255, 0);
        im15.color = new Color(255, 255, 255, 0);
    }
    public void G11()
    {
        im15.color = new Color(255, 255, 255, 1);
        im6.color = new Color(255, 255, 255, 0);
        im7.color = new Color(255, 255, 255, 0);
        im8.color = new Color(255, 255, 255, 0);
        im9.color = new Color(255, 255, 255, 0);
        im10.color = new Color(255, 255, 255, 0);
        im11.color = new Color(255, 255, 255, 0);
        im12.color = new Color(255, 255, 255, 0);
        im13.color = new Color(255, 255, 255, 0);
        im14.color = new Color(255, 255, 255, 0);
        im5.color = new Color(255, 255, 255, 0);
    }

    public void Q1()
    {
        im16.color = new Color(255, 255, 255, 1);
        im17.color = new Color(255, 255, 255, 0);
        im18.color = new Color(255, 255, 255, 0);
        im19.color = new Color(255, 255, 255, 0);
        im20.color = new Color(255, 255, 255, 0);
        im21.color = new Color(255, 255, 255, 0);
        im22.color = new Color(255, 255, 255, 0);
    }
    public void Q2()
    {
        im17.color = new Color(255, 255, 255, 1);
        im16.color = new Color(255, 255, 255, 0);
        im18.color = new Color(255, 255, 255, 0);
        im19.color = new Color(255, 255, 255, 0);
        im20.color = new Color(255, 255, 255, 0);
        im21.color = new Color(255, 255, 255, 0);
        im22.color = new Color(255, 255, 255, 0);
    }
    public void Q3()
    {
        im18.color = new Color(255, 255, 255, 1);
        im17.color = new Color(255, 255, 255, 0);
        im16.color = new Color(255, 255, 255, 0);
        im19.color = new Color(255, 255, 255, 0);
        im20.color = new Color(255, 255, 255, 0);
        im21.color = new Color(255, 255, 255, 0);
        im22.color = new Color(255, 255, 255, 0);
    }
    public void Q4()
    {
        im19.color = new Color(255, 255, 255, 1);
        im17.color = new Color(255, 255, 255, 0);
        im18.color = new Color(255, 255, 255, 0);
        im16.color = new Color(255, 255, 255, 0);
        im20.color = new Color(255, 255, 255, 0);
        im21.color = new Color(255, 255, 255, 0);
        im22.color = new Color(255, 255, 255, 0);
    }
    public void Q5()
    {
        im20.color = new Color(255, 255, 255, 1);
        im17.color = new Color(255, 255, 255, 0);
        im18.color = new Color(255, 255, 255, 0);
        im19.color = new Color(255, 255, 255, 0);
        im16.color = new Color(255, 255, 255, 0);
        im21.color = new Color(255, 255, 255, 0);
        im22.color = new Color(255, 255, 255, 0);
    }
    public void Q6()
    {
        im21.color = new Color(255, 255, 255, 1);
        im17.color = new Color(255, 255, 255, 0);
        im18.color = new Color(255, 255, 255, 0);
        im19.color = new Color(255, 255, 255, 0);
        im20.color = new Color(255, 255, 255, 0);
        im16.color = new Color(255, 255, 255, 0);
        im22.color = new Color(255, 255, 255, 0);
    }
    public void Q7()
    {
        im22.color = new Color(255, 255, 255, 1);
        im17.color = new Color(255, 255, 255, 0);
        im18.color = new Color(255, 255, 255, 0);
        im19.color = new Color(255, 255, 255, 0);
        im20.color = new Color(255, 255, 255, 0);
        im21.color = new Color(255, 255, 255, 0);
        im16.color = new Color(255, 255, 255, 0);
    }

    public void R1()
    {
        im23.color = new Color(255, 255, 255, 1);
        im24.color = new Color(255, 255, 255, 0);
        im25.color = new Color(255, 255, 255, 0);
        im26.color = new Color(255, 255, 255, 0);
        im27.color = new Color(255, 255, 255, 0);
    }
    public void R2()
    {
        im24.color = new Color(255, 255, 255, 1);
        im23.color = new Color(255, 255, 255, 0);
        im25.color = new Color(255, 255, 255, 0);
        im26.color = new Color(255, 255, 255, 0);
        im27.color = new Color(255, 255, 255, 0);
    }
    public void R3()
    {
        im25.color = new Color(255, 255, 255, 1);
        im24.color = new Color(255, 255, 255, 0);
        im23.color = new Color(255, 255, 255, 0);
        im26.color = new Color(255, 255, 255, 0);
        im27.color = new Color(255, 255, 255, 0);
    }
    public void R4()
    {
        im26.color = new Color(255, 255, 255, 1);
        im24.color = new Color(255, 255, 255, 0);
        im25.color = new Color(255, 255, 255, 0);
        im23.color = new Color(255, 255, 255, 0);
        im27.color = new Color(255, 255, 255, 0);
    }
    public void R5()
    {
        im27.color = new Color(255, 255, 255, 1);
        im24.color = new Color(255, 255, 255, 0);
        im25.color = new Color(255, 255, 255, 0);
        im26.color = new Color(255, 255, 255, 0);
        im23.color = new Color(255, 255, 255, 0);
    }

    public void M1()
    {
        im28.color = new Color(255, 255, 255, 1);
        im29.color = new Color(255, 255, 255, 0);
        im30.color = new Color(255, 255, 255, 0);
    }
    public void M2()
    {
        im29.color = new Color(255, 255, 255, 1);
        im28.color = new Color(255, 255, 255, 0);
        im30.color = new Color(255, 255, 255, 0);
    }
    public void M3()
    {
        im30.color = new Color(255, 255, 255, 1);
        im29.color = new Color(255, 255, 255, 0);
        im28.color = new Color(255, 255, 255, 0);
    }
}
