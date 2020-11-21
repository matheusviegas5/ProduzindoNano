using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtingeHabilidade : MonoBehaviour
{
    AudioSource impactoHabilidadeSom;

    void Start()
    {
        impactoHabilidadeSom = GetComponent<AudioSource>();
    }
    void OnParticleCollision(GameObject other)
    {
       if(!impactoHabilidadeSom.isPlaying) impactoHabilidadeSom.Play();
    }
}
