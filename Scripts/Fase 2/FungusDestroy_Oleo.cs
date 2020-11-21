using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FungusDestroy_Oleo : MonoBehaviour
{
    private InhibitionPetro_Oleo inhibitionPetri;
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Fungus"))
        {
            SpriteRenderer fungusSprite = other.GetComponent<SpriteRenderer>();
            CircleCollider2D fungusCollider = other.GetComponent<CircleCollider2D>();

            fungusSprite.enabled = false;
            fungusCollider.enabled = false;         
        }
        else if (other.CompareTag("PlacaPetri"))
        {
            inhibitionPetri = other.GetComponent<InhibitionPetro_Oleo>();
            inhibitionPetri.Inhibited();
        }
    }
}
