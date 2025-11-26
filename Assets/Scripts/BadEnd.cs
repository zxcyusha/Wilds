using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BadEnd : MonoBehaviour
{
    public PostProcessProfile postProcess;
    public Transform Player;
    public Transform Stena1;
    public Transform Stena2;
    public Transform Stena3;
    public Transform Stena4;
    public GameObject EndPanel;
    private AmbientOcclusion ambientOcclusion;
    private AudioSource audioEnd;
    public static bool end = false;


    public void Start()
    {
        Player.position = new Vector3(-55.8499985f, 0.166999996f, -4.6500001f);
        if (postProcess.TryGetSettings(out ambientOcclusion))
        {
            ambientOcclusion.intensity.value = 1f;
            ambientOcclusion.thicknessModifier.value = 4f;
            audioEnd = GetComponent<AudioSource>();
        }
    }

    private void Update()
    {
        Debug.Log(end);
        if ((Vector3.Distance(Player.position, Stena1.position) <= 15f || Vector3.Distance(Player.position, Stena2.position) <= 15f || Vector3.Distance(Player.position, Stena3.position) <= 15f || Vector3.Distance(Player.position, Stena4.position) <= 15f) && !end)
        {
            EndPanel.SetActive(true);
            audioEnd.Play();
            end = true;
        }
        
    }

}
