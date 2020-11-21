using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class JanelaNuvem : MonoBehaviour
{
    public Light2D luzJanela;
    public PolygonCollider2D colliderLuz;

    Light2D luzGround;
    // Start is called before the first frame update
    void Start()
    {
        luzGround = colliderLuz.gameObject.GetComponent<Light2D>();
        StartCoroutine(CicloLuz());
    }
    IEnumerator CicloLuz()
    {
        while (luzJanela.intensity > 0)
        {
            luzJanela.intensity -= 0.02f;
           if(luzGround.intensity > 0) luzGround.intensity -= 0.015f;
            yield return new WaitForSeconds(0.1f);

        }
        colliderLuz.enabled = false;
        yield return new WaitForSeconds(2);
        while (luzJanela.intensity < 0.5)
        {
            luzJanela.intensity += 0.02f;
            if (luzGround.intensity < 0.35f) luzGround.intensity += 0.015f;

            yield return new WaitForSeconds(0.1f);
            if (luzJanela.intensity > 0.2 && !colliderLuz.enabled) colliderLuz.enabled = true;
        }
        yield return new WaitForSeconds(2);
        StartCoroutine(CicloLuz());
    }

}
