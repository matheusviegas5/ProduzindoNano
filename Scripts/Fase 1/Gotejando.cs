using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gotejando : MonoBehaviour
{
   // public float timeReturnFungus;

    public GameObject[] fungus;
    SpriteRenderer[] fungusSprite;
    CircleCollider2D[] fungusCollider;

    private InhibitionPetri inhibitionPetri;
    private void Start()
    {
        fungusSprite = new SpriteRenderer[fungus.Length];
        fungusCollider = new CircleCollider2D[fungus.Length];

        for (int i = 0; i < fungus.Length; i++)
        {
            fungusSprite[i] = fungus[i].GetComponent<SpriteRenderer>();
            fungusCollider[i] = fungus[i].GetComponent<CircleCollider2D>();
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("PlacaPetri"))
        {
            //SpriteRenderer fungusSprite = other.GetComponent<SpriteRenderer>();
            //CircleCollider2D fungusCollider = other.GetComponent<CircleCollider2D>();

            //fungusSprite.enabled = false;
            //fungusCollider.enabled = false;
           // StartCoroutine(FungusReturn(fungusSprite, fungusCollider));
            inhibitionPetri = other.GetComponent<InhibitionPetri>();
            inhibitionPetri.Inhibited();
            DestroyAllFungus();
        }

        //if (other.CompareTag("PlacaPetri"))
        //{
        //    inhibitionPetri = other.GetComponent<InhibitionPetri>();
        //    inhibitionPetri.Inhibited();
        //}
    }

    IEnumerator FungusReturn(SpriteRenderer fungusSprite, CircleCollider2D fungusCollider)
    {
        do
        {
            yield return new WaitForSeconds(0.5f);
        } while (inhibitionPetri.isInhibiting);
        fungusSprite.enabled = true;
        fungusCollider.enabled = true;
    }

    void DestroyAllFungus()
    {
        for (int i = 0; i < fungusSprite.Length; i++)
        {
            fungusSprite[i].enabled = false;
            fungusCollider[i].enabled = false;
            StartCoroutine(FungusReturn(fungusSprite[i], fungusCollider[i]));
        }
    }
}
