using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InhibitionPetri : MonoBehaviour
{
    public Transform placaPetri_3;
    public float factor;

    public bool isInhibiting;

    IEnumerator activeSizeReducing;

    private void Start()
    {
        activeSizeReducing = SizeReducing();
    }
    public void Inhibited()
    {
        if (isInhibiting)
        {
            StopCoroutine(activeSizeReducing);
            activeSizeReducing = SizeReducing();
        }
        placaPetri_3.gameObject.SetActive(true);
        placaPetri_3.localScale = new Vector3(1f, 1f, 1f);
        isInhibiting = true;
        StartCoroutine(activeSizeReducing);
    }

    IEnumerator SizeReducing()
    {
        do
        {
            yield return new WaitForSeconds(0.01f);
            placaPetri_3.localScale = new Vector3(placaPetri_3.localScale.x - factor, placaPetri_3.localScale.y - factor, placaPetri_3.localScale.z - factor);
        } while (placaPetri_3.localScale.x > 0);

        isInhibiting = false;
        placaPetri_3.gameObject.SetActive(false);
    }
}
