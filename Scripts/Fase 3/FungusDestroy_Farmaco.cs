using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FungusDestroy_Farmaco : MonoBehaviour
{
    private InhibitionPetro_Oleo inhibitionPetri;
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Fungus"))
        {
            other.gameObject.SetActive(false);
            //SpriteRenderer fungusSprite = other.GetComponent<SpriteRenderer>();
            //CircleCollider2D fungusCollider = other.GetComponent<CircleCollider2D>();

            //fungusSprite.enabled = false;
            //fungusCollider.enabled = false;
            inhibitionPetri = other.GetComponent<InhibitionPetro_Oleo>();
            try
            {
                inhibitionPetri.Inhibited();
            }
            catch (System.Exception)
            {
            }   

        }
        else if (other.CompareTag("PlacaPetri"))
        {
            inhibitionPetri = other.GetComponent<InhibitionPetro_Oleo>();
            inhibitionPetri.Inhibited();
        }
        else if (other.CompareTag("SuperFungus"))
        {
            other.gameObject.SetActive(false);
        }
    }

}
