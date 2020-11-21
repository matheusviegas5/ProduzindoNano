using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Configuration : MonoBehaviour
{
    public GameObject canvasPause;
    public AudioSource unPauseSom;
    public AudioSource pauseSom;

    public static bool isPaused;
    void Start()
    {
        canvasPause.SetActive(false);
        Time.timeScale = 1;
        pauseSom.ignoreListenerPause = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("Fase_1");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("Fase_2");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("Fase_3");
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale != 0)
            {
                Pausar();
            }
            else
            {
                VoltarDoPause();
            }
        }
    }
    void Pausar()
    {
        isPaused = true;
        pauseSom.Play();
        canvasPause.SetActive(true);
        AudioListener.pause = true;
        Time.timeScale = 0;
    }
    public void VoltarDoPause()
    {
        isPaused = false;
        unPauseSom.Play();
        canvasPause.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
    }
}


