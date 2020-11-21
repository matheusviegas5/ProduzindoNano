using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsOnLight : MonoBehaviour
{
    public static bool isOnLight;
    public SpriteRenderer headMaterial;
    public float intensity = 0;

    bool trigger;

    private void Start()
    {
        isOnLight = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Light"))
        {
            trigger = false;
            isOnLight = true;
            StartCoroutine(LightHead());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Light"))
        {
            headMaterial.material.SetColor("Color_FC41CA80", new Color(0,0,0, 0));
            isOnLight = false;
            trigger = true;
        }
    }
    IEnumerator LightHead()
    {
        do
        {
            float factor = Mathf.Pow(2, intensity);
            headMaterial.material.SetColor("Color_FC41CA80", new Color(0.9f * factor, 0.1f * factor, 0, 0));
            intensity += 0.2f;
            yield return new WaitForSeconds(0.1f);
        } while (intensity < 3.6f && !trigger);
        trigger = true;
        intensity = 0;

    }
    //IEnumerator UnLightHead()
    //{
    //    do
    //    {
    //        float factor = Mathf.Pow(2, intensity);
    //        headMaterial.material.SetColor("Color_FC41CA80", new Color(0.9f * factor, 0.1f * factor, 0, 0));
    //        intensity -= 0.01f;
    //        yield return new WaitForSeconds(0.1f);
    //    } while (intensity > 0f && trigger);
    //    headMaterial.material.SetColor("Color_FC41CA80", new Color(0, 0, 0, 0));
    //    trigger = false;
    //}
}
