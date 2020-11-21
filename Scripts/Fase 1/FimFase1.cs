using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class FimFase1 : MonoBehaviour
{
    public Animator jogador;
    public Animator sequenciaDestilador;
    public CinemachineVirtualCamera cameraFollow;
    public Transform newSprite;
    AudioSource musicaTema;
    AudioSource somSequenciaFinal;

    private void Start()
    {
        musicaTema = GameObject.FindGameObjectWithTag("MusicaTema").GetComponent<AudioSource>();
        somSequenciaFinal = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(DiminuiMusicaTema());
        cameraFollow.Follow = newSprite;
        jogador.SetTrigger("TransicaoOleo");
        sequenciaDestilador.SetTrigger("sequenciaFinal");
        somSequenciaFinal.Play();
    }

    IEnumerator DiminuiMusicaTema()
    {
        while (musicaTema.volume > 0)
        {
            musicaTema.volume -= 0.02f;
            yield return new WaitForSeconds(0.1f);
        }
    }
 
}
