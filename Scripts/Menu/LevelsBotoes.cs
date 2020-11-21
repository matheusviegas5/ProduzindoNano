using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsBotoes : MonoBehaviour
{
    public int fase;
    void Awake()
    {
        if (PlayerPrefs.GetInt("fase") >= fase) GetComponent<Button>().interactable = true;
        else GetComponent<Button>().interactable = false;
    }
}
