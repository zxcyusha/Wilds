using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Tunnel : MonoBehaviour
{
    public GameObject Begi;
    public GameObject Komnata;
    public Transform Tonnel;
    public AudioSource StrashniZvuk;
    public GameObject Panel;
    public AudioSource Gluki;
    public GameObject CanvasNadpisi;
    public PostProcessProfile postProcess;
    public GameObject TemnEkr;
    public AudioSource Vspishka;
    public GameObject Morg;
    private DepthOfField depthOfField;
    private LensDistortion lensDistortion;
    private bool ost = false;
    private bool portalBil = false;
    public static bool isNarkomania = false;
    private bool IntensYvelich = true;
    void Start()
    {
        if (postProcess.TryGetSettings(out depthOfField) && postProcess.TryGetSettings(out lensDistortion))
        {
            depthOfField.aperture.value = 32f;
            lensDistortion.intensity.value = 0;
        }
    }

    void Update()
    {
        if (DAYS.DAY3 && (Vector3.Distance(transform.position, Tonnel.position) < 1f) && !portalBil)
        {
            Morg.SetActive(true);
            transform.position = new Vector3(42.12f, 0.16f, 4.867f);
            Begi.SetActive(true);
            StrashniZvuk.Play();
            portalBil = true;
            Panel.SetActive(true);
        }

        if ((Vector3.Distance(transform.position, Komnata.transform.position) < 6f) && !ost)
        {
            Morg.SetActive(false);
            Invoke("end", 5f);
            Begi.SetActive(false);
            Panel.SetActive(false);
            Gluki.Play();
            Invoke("canvas", 2f);
            StrashniZvuk.Stop();
            ost = true;
        }

        if (isNarkomania)
        {
            if (IntensYvelich)
            {
                lensDistortion.intensity.value += 1.3f;
                if (lensDistortion.intensity.value >= 100) IntensYvelich = false;
            }
            else
            {
                lensDistortion.intensity.value -= 1.3f;
                if (lensDistortion.intensity.value <= -100) IntensYvelich = true;
            }
        }
    }

    private void canvas()
    {
        CanvasNadpisi.SetActive(true);
    }

    private IEnumerator Ecran(DepthOfField DepthOfField)
    {
        while (DepthOfField.aperture.value > 0.1f)
        {
            DepthOfField.aperture.value -= 0.5f;
            yield return new WaitForSeconds(0.02f);
        }

    }

    private void end()
    {
        StartCoroutine(Ecran(depthOfField));
        isNarkomania = true;
        Invoke("konec", 10f);
    }
    private void konec()
    {
        TemnEkr.SetActive(true);
        Gluki.Stop();
        TemnEkr.GetComponent<Animator>().SetBool("Zakr", false);
        Vspishka.Play();
        StopCoroutine(Ecran(depthOfField));
        isNarkomania = false;
        Invoke("END", 5f);
    }

    private void END()
    {
        transform.position = new Vector3(25.05f, 0.16f, -11.47f);
        TemnEkr.GetComponent<Animator>().SetBool("Zakr", true);
        Invoke("zakr", 2f);
        depthOfField.aperture.value = 32f;
        lensDistortion.intensity.value = 0;
    }

    private void zakr() { TemnEkr.SetActive(false); }
}
