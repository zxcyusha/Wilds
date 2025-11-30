using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomWithRart : MonoBehaviour
{
    public GameObject playerCamera;
    public LayerMask pickUpLayerMask;
    public GameObject Teleshka;
    public GameObject peretashitTel;
    public GameObject TextTel;
    public GameObject Player;
    public GameObject InstrText;
    public Transform Exit1;
    public Transform Exit2;
    public Transform Exit3;
    public Transform Exit4;
    public AudioSource vipolneno;
    public float speed;
    public static bool telesh = false;
    public bool game = false;
    private bool katitsa = true;
    public Vector3 telPer;
    private AudioSource skip;
    private bool a = true;
    private bool zvuk = true;
    public static bool OTPRAVILITELESHKI = false; //
    public bool DA = false; // игнор
    public static bool CartYes = false;

    private void Start()
    {
        skip = peretashitTel.GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Cart.OTPRAVILI || DA)
        {
            if (((Vector3.Distance(transform.position, playerCamera.transform.position) <= 12.4f) && !telesh) || DA)
            {
                Teleshka.GetComponent<Animator>().SetBool("Priezshaet", true);
                Teleshka.GetComponent<AudioSource>().Play();
                Invoke("StopZvuk", 10.5f);
                telesh = true;
            }


            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit Hit, 4f, pickUpLayerMask))
            {
                if (Hit.collider.CompareTag("Carts") && !OTPRAVILITELESHKI)
                {
                    TextTel.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        playerCamera.transform.rotation = Quaternion.Euler(20f, -180f, 0f);
                        playerCamera.GetComponent<CinemachineBrain>().enabled = false;
                        Player.GetComponent<AnimatorCotroller>().enabled = false;
                        InstrText.SetActive(true);
                        game = true;
                        Teleshka.GetComponent<Animator>().enabled = false;
                        Teleshka.transform.SetParent(peretashitTel.transform);
                    }
                }
                else TextTel.SetActive(false);
            }
            else TextTel.SetActive(false);

            if (game)
            {
                if (Input.GetKey(KeyCode.W) && peretashitTel.transform.position.z >= -34f)
                {
                    Vector3 newTr = new Vector3(peretashitTel.transform.position.x, peretashitTel.transform.position.y, peretashitTel.transform.position.z - speed);
                    peretashitTel.transform.position = Vector3.Lerp(peretashitTel.transform.position, newTr, Time.deltaTime);
                    if (a)
                    {
                        skip.Play();
                        a = false;
                    }
                }
                else if (Input.GetKey(KeyCode.S) && peretashitTel.transform.position.z <= -26f)
                {
                    Vector3 newTr = new Vector3(peretashitTel.transform.position.x, peretashitTel.transform.position.y, peretashitTel.transform.position.z + speed);
                    peretashitTel.transform.position = Vector3.Lerp(peretashitTel.transform.position, newTr, Time.deltaTime);
                    if (a)
                    {
                        skip.Play();
                        a = false;
                    }
                }
                else if (Input.GetKey(KeyCode.D) && peretashitTel.transform.position.x >= 16.5f)
                {
                    Vector3 newTr = new Vector3(peretashitTel.transform.position.x - speed, peretashitTel.transform.position.y, peretashitTel.transform.position.z);
                    peretashitTel.transform.position = Vector3.Lerp(peretashitTel.transform.position, newTr, Time.deltaTime);
                    if (a)
                    {
                        skip.Play();
                        a = false;
                    }
                }
                else if (Input.GetKey(KeyCode.A) && peretashitTel.transform.position.x <= 31.5f)
                {
                    Vector3 newTr = new Vector3(peretashitTel.transform.position.x + speed, peretashitTel.transform.position.y, peretashitTel.transform.position.z);
                    peretashitTel.transform.position = Vector3.Lerp(peretashitTel.transform.position, newTr, Time.deltaTime);
                    if (a)
                    {
                        skip.Play();
                        a = false;
                    }
                }
                else if (Input.GetKey(KeyCode.Q) && peretashitTel.transform.position.y <= 0f)
                {
                    Vector3 newTr = new Vector3(peretashitTel.transform.position.x, peretashitTel.transform.position.y + speed, peretashitTel.transform.position.z);
                    peretashitTel.transform.position = Vector3.Lerp(peretashitTel.transform.position, newTr, Time.deltaTime);
                    if (a)
                    {
                        skip.Play();
                        a = false;
                    }
                }
                else if (Input.GetKey(KeyCode.E) && peretashitTel.transform.position.y >= -9f)
                {
                    Vector3 newTr = new Vector3(peretashitTel.transform.position.x, peretashitTel.transform.position.y - speed, peretashitTel.transform.position.z);
                    peretashitTel.transform.position = Vector3.Lerp(peretashitTel.transform.position, newTr, Time.deltaTime);
                    if (a)
                    {
                        skip.Play();
                        a = false;
                    }
                }

                else
                {
                    skip.Stop();
                    a = true;
                }

                if ((Vector3.Distance(Teleshka.transform.position, Exit1.transform.position) <= 3.8f) && katitsa)
                {
                    Teleshka.transform.position = Vector3.Lerp(Teleshka.transform.position, Teleshka.transform.position + telPer, Time.deltaTime);
                    if (zvuk)
                    {
                        vipolneno.Play();
                        zvuk = false;
                        CartYes = true;
                    }
                    Invoke("end", 2.5f);
                }
                if ((Vector3.Distance(Teleshka.transform.position, Exit2.transform.position) <= 2.7f) && katitsa)
                {
                    Teleshka.transform.position = Vector3.Lerp(Teleshka.transform.position, Teleshka.transform.position + telPer, Time.deltaTime);
                    if (zvuk)
                    {
                        vipolneno.Play();
                        zvuk = false;
                        CartYes = true;
                    }
                    Invoke("end", 2.5f);
                }
                if ((Vector3.Distance(Teleshka.transform.position, Exit3.transform.position) <= 4.85f) && katitsa)
                {
                    Teleshka.transform.position = Vector3.Lerp(Teleshka.transform.position, Teleshka.transform.position + telPer, Time.deltaTime);
                    if (zvuk)
                    {
                        vipolneno.Play();
                        zvuk = false;
                        CartYes = true;
                    }
                    Invoke("end", 2.5f);
                }
                if ((Vector3.Distance(Teleshka.transform.position, Exit4.transform.position) <= 4f) && katitsa)
                {
                    Teleshka.transform.position = Vector3.Lerp(Teleshka.transform.position, Teleshka.transform.position + telPer, Time.deltaTime);
                    if (zvuk)
                    {
                        vipolneno.Play();
                        zvuk = false;
                        CartYes = true;
                    }
                    Invoke("end", 2.5f);
                }

                if (Input.GetKeyDown(KeyCode.I))
                {
                    playerCamera.GetComponent<CinemachineBrain>().enabled = true;
                    Player.GetComponent<AnimatorCotroller>().enabled = true;
                    game = false;
                    InstrText.SetActive(false);
                }
            }

        }

    }

    private void StopZvuk() { Teleshka.GetComponent<AudioSource>().Stop(); }
    private void end()
    {
        if (game)
        {
            Invoke("stopTel", 3f);
            playerCamera.GetComponent<CinemachineBrain>().enabled = true;
            Player.GetComponent<AnimatorCotroller>().enabled = true;
            InstrText.SetActive(false);
            game = false;
            zvuk = true;
            OTPRAVILITELESHKI = true;
        }
    }

    private void stopTel() { katitsa = false; }
}
