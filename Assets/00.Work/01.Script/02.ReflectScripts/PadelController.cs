using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadelController : MonoBehaviour
{ 
    private void Check()
    {
        Debug.Log("Clear");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            collision.gameObject.SetActive(false);
            Check();
        }
    }

}
