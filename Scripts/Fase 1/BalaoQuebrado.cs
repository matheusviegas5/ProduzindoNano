using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalaoQuebrado : MonoBehaviour
{
    public Image balaoPreenchido;
    public ParticleSystem gotejando;
    bool trigger;
    IEnumerator unfillVolumetric;
    AudioSource somGota;
    IEnumerator LoopSomGota;
    bool loopSomisrunning;
    private void Start()
    {
        LoopSomGota = SomGota();
        somGota = GetComponent<AudioSource>();
        unfillVolumetric = UnfillVolumetric();
    }
    public void FillVolumetric()
    {
        if (trigger)
        {
            StopCoroutine(unfillVolumetric);
            unfillVolumetric = UnfillVolumetric();
        }
        trigger = true;
        if (!gotejando.isPlaying) gotejando.Play();
        if (!loopSomisrunning) StartCoroutine(LoopSomGota);
        StartCoroutine(unfillVolumetric);
    }
    IEnumerator UnfillVolumetric()
    {
        do
        {
            yield return new WaitForSeconds(0.005f);
            balaoPreenchido.fillAmount += 0.03f;
        } while (balaoPreenchido.fillAmount < 1);
        do
        {
            yield return new WaitForSeconds(0.01f);
            balaoPreenchido.fillAmount -= 0.0001f;
        } while (balaoPreenchido.fillAmount > 0);
        gotejando.Stop();
        StopCoroutine(LoopSomGota);
        loopSomisrunning = false;
        trigger = false;
    }

    IEnumerator SomGota()
    {
        loopSomisrunning = true;
        while (true)
        {
            yield return new WaitForSeconds(2f);
            somGota.Play();
        }

    }
}
