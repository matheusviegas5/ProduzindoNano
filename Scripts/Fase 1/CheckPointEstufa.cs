using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointEstufa : MonoBehaviour
{
    public SpriteRenderer ledVermelho;
    public SpriteRenderer ledVerde;

    AudioSource somCheckpoint;

    float factor = 6.24f;
    private void Start()
    {
        somCheckpoint = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lightUpGreen();
            somCheckpoint.Play();
        }
        GetComponent<BoxCollider2D>().enabled = false;
    }
    void lightUpGreen()
    {
        ledVerde.material.SetColor("Color_FC41CA80", new Color(0, 0.9f * factor, 0, 0));
        ledVermelho.material.SetColor("Color_FC41CA80", new Color(0.9f, 0, 0, 0));
    }

}
