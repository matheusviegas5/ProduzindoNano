using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColunaPequeno : MonoBehaviour
{
    void Start()
    {
      if(CheckPoint_Oleo.spawnPoint == gameObject.transform.position)
        {
            GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.4f, 0.1f, 1f);
        }
    }
}
