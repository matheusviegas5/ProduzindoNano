using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FungusDestroy : MonoBehaviour
{
    public float timeReturnFungus;
    private InhibitionPetri inhibitionPetri;
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Fungus"))
        {
            SpriteRenderer fungusSprite = other.GetComponent<SpriteRenderer>();
            CircleCollider2D fungusCollider = other.GetComponent<CircleCollider2D>();

            fungusSprite.enabled = false;
            fungusCollider.enabled = false;
            StartCoroutine(FungusReturn(fungusSprite, fungusCollider));
        }

        else if (other.CompareTag("PlacaPetri"))
        {
            inhibitionPetri = other.GetComponent<InhibitionPetri>();
            inhibitionPetri.Inhibited();
        }

        else if (other.CompareTag("BalaoQuebrado"))
        {
            other.GetComponent<BalaoQuebrado>().FillVolumetric();
        }
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



}
