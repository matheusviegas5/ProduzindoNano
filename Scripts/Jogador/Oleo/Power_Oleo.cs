using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Oleo : MonoBehaviour
{
    public ParticleSystem habilidade;
    public AudioSource habilidadeOleoSom;
    public AudioSource semOleoSom;

    Hability_Oleo habilidadeOleo;

    private void Start()
    {
        habilidadeOleo = GetComponent<Hability_Oleo>();
    }

    public void UsaHabilidade()
    {
        if (habilidadeOleo.habilidadeOleo > 0)
        {
            habilidade.Play();
            habilidadeOleo.habilidadeOleo--;
            habilidadeOleo.UpdateOleo();
            habilidadeOleoSom.Play();
        }
        else semOleoSom.Play();
    }
}
