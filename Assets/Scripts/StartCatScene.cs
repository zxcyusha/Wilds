using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    private int i = 0;
    private string s1 = "Новый день, новое утро, но всё та же моя ненависть к тому месту.";
    private string s2 = "С каждым днём всё труднее придумывать причины оставаться здесь.";
    private string s3 = "С каждым днём порода всё больше давит и втирает меня в землю,";
    private string s4 = "уничтожая остатки прежнего человека.";
    private string s5 = "Я чувствую истощение.";
    private string s6 = "Не знаю, сколько ещё продержусь в этом аду, но, по крайне мере сегодня";
    private string s7 = "Лифт стремительно опускает меня в";

    void Start()
    {
        Cursor.visible = false;
        kamera.transform.position = new Vector3(kamera.transform.position.x, kamera.transform.position.y, kamera.transform.position.z+0.1f);
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

    public IEnumerator DelayedAction(string soob)
    {
        
        while (i <= (soob.Length - 1))
        {
            yield return new WaitForSeconds(speed);
            Debug.Log(i);
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
        
        zastavka.SetActive(false);
        door1.SetBool("Open", true);
        door2.SetBool("open", true);
        FonShym2.Play();
        kamera.GetComponent<CinemachineBrain>().enabled = true;
        player.GetComponent<AnimatorCotroller>().enabled = true;
        CanSettings = true;
        liftOpen.Play();
    }
    private void a() { pym.Play(); }
}
