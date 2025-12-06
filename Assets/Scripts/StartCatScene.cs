using Cinemachine;
using Lessons.Plugins.Lesson_Localization;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StartCatScene : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float speed = 1f;
    public GameObject zastavka;
    public Animator door1;
    public Animator door2;
    public AudioSource FonShym1;
    public AudioSource FonShym2;
    public GameObject kamera;
    public GameObject player;
    public AudioSource pym;
    public AudioSource tulum;
    public AudioSource liftOpen;
    public static bool CanSettings = false;
    public GameObject Instrukcia;
    public GameObject Translator;
    public AudioSource NachZvuk;
    public static bool IsAnimated = false;
    private int i = 0;
    public static string s1 = "Новый день, новое утро, но всё та же моя ненависть к тому месту.";
    public static string s2 = "С каждым днём всё труднее придумывать причины оставаться здесь.";
    public static string s3 = "С каждым днём порода всё больше давит и втирает меня в землю,";
    public static string s4 = "уничтожая остатки прежнего человека.";
    public static string s5 = "Я чувствую истощение.";
    public static string s6 = "Не знаю, сколько ещё продержусь в этом аду, но, по крайне мере сегодня";
    public static string s7 = "Лифт стремительно опускает меня в";

    public bool IsRussia = true;

    void Start()
    {
        SetText();
        if (DataTiper.needAnimating)
        {
            Cursor.visible = false;
            kamera.transform.position = new Vector3(kamera.transform.position.x, kamera.transform.position.y, kamera.transform.position.z + 0.1f);
            kamera.GetComponent<CinemachineBrain>().enabled = false;
            player.GetComponent<AnimatorCotroller>().enabled = false;
            StartCoroutine(DelayedAction(s1));
            Invoke("aboba1", 6.4f);
            Invoke("aboba2", 11.1f);
            Invoke("aboba3", 15.4f);
            Invoke("aboba4", 18.4f);
            Invoke("aboba5", 20.8f);
            Invoke("aboba6", 25.8f);
            Invoke("end", 28.6f);
            Invoke("END", 35f);
        }
        else
        {
            NachZvuk.Stop();
        }
    }

    public IEnumerator DelayedAction(string soob)
    {
        
        while (i <= (soob.Length - 1))
        {
            yield return new WaitForSeconds(speed);
            text.text += soob[i];
            i++;
        }
    }
    private void aboba1()
    {
        StopAllCoroutines();
        i = 0;
        text.text = "";
        speed = 0.05f;
        StartCoroutine(DelayedAction(s2));
    }

    private void aboba2()
    {
        StopAllCoroutines();
        i = 0;
        text.text = "";
        speed = 0.05f;
        StartCoroutine(DelayedAction(s3));
    }
    private void aboba3()
    {
        StopAllCoroutines();
        i = 0;
        text.text = "";
        speed = 0.05f;
        StartCoroutine(DelayedAction(s4));
    }
    private void aboba4()
    {
        StopAllCoroutines();
        i = 0;
        text.text = "";
        speed = 0.05f;
        StartCoroutine(DelayedAction(s5));
    }
    private void aboba5()
    {
        StopAllCoroutines();
        i = 0;
        text.text = "";
        speed = 0.05f;
        StartCoroutine(DelayedAction(s6));
    }
    private void aboba6()
    {
        StopAllCoroutines();
        i = 0;
        text.text = "";
        speed = 0.05f;
        StartCoroutine(DelayedAction(s7));
    }
    private void end()
    {
        i = 0;
        text.text = "";
        zastavka.SetActive(true);
        FonShym1.Stop();
        tulum.Play();
        Invoke("a", 3f);
    }
    private void END() {
        IsAnimated = false;
        Translator.SetActive(false);
        zastavka.SetActive(false);
        door1.SetBool("Open", true);
        door2.SetBool("open", true);
        FonShym2.Play();
        liftOpen.Play();
        Invoke("StartGame", 2f);
    }
    private void a() { pym.Play(); }

    private void StartGame()
    {
        kamera.GetComponent<CinemachineBrain>().enabled = true;
        player.GetComponent<AnimatorCotroller>().enabled = true;
        CanSettings = true;
        Instrukcia.SetActive(true);
        Invoke("dalshe", 3f);
    }
    private void dalshe()
    {
        Instrukcia.SetActive(false);
        Instrukcia.GetComponent<TextMeshProUGUI>().text = "Чтобы выйти в меню паузы, нажми на esc. Приятной игры!";
        Instrukcia.SetActive(true);
    }

    public void SetText()
    {
        if (LanguageManager.Language.ToString() == "Russian")
        {
            s1 = "Новый день, новое утро, но всё та же моя ненависть к тому месту.";
            s2 = "С каждым днём всё труднее придумывать причины оставаться здесь.";
            s3 = "С каждым днём порода всё больше давит и втирает меня в землю,";
            s4 = "уничтожая остатки прежнего человека.";
            s5 = "Я чувствую истощение.";
            s6 = "Не знаю, сколько ещё продержусь в этом аду, но, по крайне мере сегодня";
            s7 = "Лифт стремительно опускает меня в";
        }
        else
        {
            s1 = "A new day, a new morning, but still the same hatred for that place.";
            s2 = "Every day, it gets harder to find reasons to stay here.";
            s3 = "Every day, the rock pushes and rubs me into the ground,";
            s4 = "destroying the remnants of the old man.";
            s5 = "I feel exhausted.";
            s6 = "I don't know how much longer I can hold out in this hell, but at least for today";
            s7 = "The elevator drops me rapidly into the";
        }
    }
}
