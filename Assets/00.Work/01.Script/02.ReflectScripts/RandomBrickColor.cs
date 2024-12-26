using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RandomBrickColor : MonoBehaviour
{
    private SpriteRenderer spr;
    private void Start()
    {
        Color rand = new Color(Random.value, Random.value, Random.value);

        spr = GetComponent<SpriteRenderer>();

        if (spr != null)
        {
            spr.material.color = rand;
        }
    }

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }

}
