using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectHint : MonoBehaviour
{
    [SerializeField] private GameObject point;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = point.GetComponent<SpriteRenderer>();
        SetAlhpa(0);
        StartCoroutine(Wait());
    }

    private void SetAlhpa(float alpha)
    {
        Color color = spriteRenderer.color;
        color.a = alpha;
        spriteRenderer.color = color;
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
        SetAlhpa(255);
    }
}
