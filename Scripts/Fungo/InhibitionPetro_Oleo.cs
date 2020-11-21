using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InhibitionPetro_Oleo : MonoBehaviour
{
    public GameObject placaPetri_3;

    public void Inhibited()
    {
        placaPetri_3.SetActive(true);
    }
}
