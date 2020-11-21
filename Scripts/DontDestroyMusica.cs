using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DontDestroyMusica : MonoBehaviour
{
    public string fase;

    public static string instance;
    //Scene scene;

    void Awake()
    {
        //scene = SceneManager.GetActiveScene();
        //fase = scene.name;
        if (instance == null)
        {
            instance = this.gameObject.name;
        }
        else
        {
            if (instance != this.gameObject.name)
            {
                instance = this.gameObject.name;
            }
            else if (instance == this.gameObject.name)
            {
                Destroy(gameObject);
            }     
        }
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != fase)
        {
            Destroy(gameObject);
        }
    }
}
