using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrushingPlayer : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().enabled = false;
            collision.transform.localScale = new Vector3(collision.transform.localScale.x, collision.transform.localScale.y - 0.05f, collision.transform.localScale.z);
            if (collision.transform.localScale.y < 0.1f)
            {
                PlayerLife_Planta.PlayerDeath();
            }
        }

    }

}
