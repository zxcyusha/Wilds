using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private GameObject MapPanel;

    private void Update()
    {
        if (MapPanel.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                MapPanel.SetActive(false);
            }
        }
    }
}
