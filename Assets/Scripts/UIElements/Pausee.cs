using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private AudioSource MusicPause;
    [SerializeField] private AudioSource MusicFon;
    [SerializeField] private CinemachineVirtualCamera VirtualCamera;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PausePanel.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0f;
            MusicPause.Play();
            MusicFon.Stop();
        }
    }

    public void SetAxisSpeed(float speed)
    {
        var pov = VirtualCamera.GetCinemachineComponent<CinemachinePOV>();

        pov.m_HorizontalAxis.m_MaxSpeed = speed;
        pov.m_VerticalAxis.m_MaxSpeed = speed;
    }
}