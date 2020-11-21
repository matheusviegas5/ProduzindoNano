using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class ResetaFase3 : MonoBehaviour
{
    public static bool nanoAtivo;

    public Transform background;

    public GameObject farmaco;
    public GameObject nano;
    public CinemachineVirtualCamera cameraFollow;

    public ParallaxLayer parallax;

    public Animator sequenciaFinal;
    private void Awake()
    {
       // nanoAtivo = true;
        if(nanoAtivo) StartCoroutine(ArrumarFundo());
    }
    IEnumerator ArrumarFundo()
    {
        parallax.enabled = false;
        farmaco.SetActive(false);
        sequenciaFinal.SetTrigger("FaseNano");
        yield return new WaitForSeconds(0.01f);
        background.position = new Vector3(38.9541f, 5.210597f, -7.59749f);
        yield return new WaitForSeconds(0.01f);
        parallax.enabled = true;
        nano.SetActive(true);
        cameraFollow.Follow = nano.transform;
        // StartCoroutine(ArrumarFundo());



    }



}
