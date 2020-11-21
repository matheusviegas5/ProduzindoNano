using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocaNano : MonoBehaviour
{
    public GameObject nano;
    public CinemachineVirtualCamera cameraFollow;
    public AudioSource musicaTema;
    public void ViraNano()
    {
        nano.SetActive(true);
        cameraFollow.Follow = nano.transform;
        if (PlayerPrefs.GetInt("fase") < 3) PlayerPrefs.SetInt("fase", 3);
        ResetaFase3.nanoAtivo = true;

    }
    public void AumentaMusica()
    {
        StartCoroutine(AumentaMusicaTema());
    }
    IEnumerator AumentaMusicaTema()
    {
        while (musicaTema.volume < 1)
        {
            musicaTema.volume += 0.02f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
