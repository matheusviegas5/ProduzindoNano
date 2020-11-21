using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public static Vector3 initialPoint = new Vector3(0, 0, 0);
    static bool checkPointMaiorAtivado;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = initialPoint;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CheckPoint"))
        {
            if (!collision.gameObject.GetComponent<UsedCheckpoint>().used)
            {
                checkPointMaiorAtivado = false;
                initialPoint = collision.gameObject.transform.position;
                collision.gameObject.GetComponent<UsedCheckpoint>().used = true;
            }
        }

        else if (collision.gameObject.CompareTag("CheckPointMaior"))
        {
            if (!collision.gameObject.GetComponent<UsedCheckpoint>().used)
            {
                collision.gameObject.GetComponent<UsedCheckpoint>().used = true;
                if (!checkPointMaiorAtivado)
                {
                initialPoint = collision.gameObject.transform.position;
                PlayerLife_Planta.playerLife = 3;
                PlayerLife_Planta.UpdateLives();
                checkPointMaiorAtivado = true;
                }
            }
        }
    }
}
