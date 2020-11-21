using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife_Farmaco : MonoBehaviour
{
    public float lightDamage;
    public float acidDamage;
    public float life = 2;

    public ParticleSystem lightBody;
    public ParticleSystem onAcid_Particle;
    bool onLight;
    bool onAcid;
    private void Update()
    {
        if (onLight) life -= lightDamage * Time.deltaTime;
        if (onAcid) life -= acidDamage * Time.deltaTime;
                
        if (life < 0)
        {
            GetComponent<PlayerDefeat_FarmacoNano>().DestroyedByAcid();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Light"))
        {
            onLight = true;
            lightBody.Play();
            
        }
        else if (collision.gameObject.CompareTag("Acido"))
        {
            onAcid = true;
            onAcid_Particle.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Light"))
        {
            onLight = false;
            lightBody.Stop();
            life = 2;
        }
        else if (collision.gameObject.CompareTag("Acido"))
        {
            onAcid = false;
            onAcid_Particle.Stop();
            life = 2;
        }
    }
}
