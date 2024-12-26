using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectObject : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 direction;

    void Start()
    {
        // 초기 방향 설정
        direction = new Vector2 (1, -0.2f);
    }

    void Update()
    {
        // 물체 이동
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌 시 반사 벡터 계산
        Vector2 normal = collision.contacts[0].normal;
        direction = Vector2.Reflect(direction, normal);
    }
}
