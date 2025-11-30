using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class MouseCoordinates : MonoBehaviour
{
    public TextMeshProUGUI coordinatesText;
    public AudioSource ZvukBur;
    public static bool isStop = false;

    void Update()
    {
        if (isStop) return;

        Vector3 mousePos = Input.mousePosition;
        float x = (mousePos.x / Screen.width) * 2000 - 1000;
        float y = (mousePos.y / Screen.height) * 2000 - 1000;
        coordinatesText.text = $"({x:F0}, {y:F0})";
    }


    public static IEnumerator FadeOutCoroutine(AudioSource audioSource, float fadeDuration)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }

        audioSource.volume = 0;
        audioSource.Stop();
    }
}
