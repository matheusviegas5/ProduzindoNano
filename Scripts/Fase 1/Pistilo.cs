using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistilo : MonoBehaviour
{
    Transform pistilo;
    public float speed;
    float factor;
    public bool goingDown;
    // Start is called before the first frame update
    void Start()
    {
        factor = speed;
        pistilo = GetComponent<Transform>();
    }

    private void Update()
    {

        if (pistilo.transform.localPosition.y > 6f && !goingDown)
        {
            factor = -speed;
            goingDown = true;
        }

        else if (pistilo.transform.localPosition.y < 1.1f)
        {
            factor = speed;
            goingDown = false;
        }

    }
    private void FixedUpdate()
    {
        pistilo.transform.position = new Vector3(pistilo.transform.position.x, pistilo.transform.position.y + factor, -1);   
    }




}
