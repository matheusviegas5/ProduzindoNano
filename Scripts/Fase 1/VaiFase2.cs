using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VaiFase2 : MonoBehaviour
{
    public void TrocaFase2()
    {

        if (PlayerPrefs.GetInt("fase") < 1) PlayerPrefs.SetInt("fase", 1);
        SceneManager.LoadScene("Fase_2");
    }

    public void TrocaFase3()
    {
        if (PlayerPrefs.GetInt("fase") < 2) PlayerPrefs.SetInt("fase", 2);
        SceneManager.LoadScene("Fase_3");
    }
}
