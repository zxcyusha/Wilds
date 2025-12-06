using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;


public class Pause : MonoBehaviour
{
    public string volumeParameter = "MasterVolume";
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private AudioSource MusicPause;
    [SerializeField] private AudioSource MusicFon;
    [SerializeField] private CinemachineVirtualCamera VirtualCamera;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider slider;

    private const float _multiplier = 20f;

    private void Awake()
    {
        slider.onValueChanged.AddListener(Value);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && StartCatScene.CanSettings)
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

    private void Value(float value)
    {
        var volum = Mathf.Log10(value) * _multiplier;
        mixer.SetFloat(volumeParameter, volum);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}