using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CheckPointNAno : MonoBehaviour
{
    public static bool checkPointNanoOn;
    public Transform nanoCheckPoint;
    // Start is called before the first frame update
    void Start()
    {
        if (checkPointNanoOn)
        {
            transform.position = nanoCheckPoint.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CheckPointNano"))
        {
            checkPointNanoOn = true;
        }
    }
}
