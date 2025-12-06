using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadGamee : MonoBehaviour {

    public event Action Loadgame;
    public GameObject Player;
    public Slider Music;
    public Slider Sensivity;
    public GameObject kamera;

    public static Vector3 PlayerPos;
    public static float Valuesensivity;
    public static float Valuemusic;


    public void Start()
    {
        LoadMainGame();
    }
    public void LoadMainGame() // это должно быть событием
    {
        StartCatScene.CanSettings = true;
        if (PlayerPos != Vector3.zero) Player.transform.position = PlayerPos;
        Music.value = Valuemusic;
        Sensivity.value = Valuesensivity;
    }
}
