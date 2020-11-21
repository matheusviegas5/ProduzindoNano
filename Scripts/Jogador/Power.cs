using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public ParticleSystem[] habilidade;
    public AudioSource somHabilidade;

    public void UsaHabilidade()
    {
        for (int i = 0; i < habilidade.Length; i++)
        {
            habilidade[i].Play();
        }
        somHabilidade.Play();

    }
}
