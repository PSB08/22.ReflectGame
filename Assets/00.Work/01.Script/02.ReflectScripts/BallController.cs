using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    [SerializeField] private ReflectManager reflectManager;
    [SerializeField] private string sceneName;
    public float speed = 10f;
    private Vector2 direction;
    private bool isActioned = false;

    // LineRenderer 추가
    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2; 
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isActioned)
        {
            LaunchBall();
            isActioned = true;
        }

        if (!isActioned)
        {
            ShowLaunchDirection();
        }
    }

    private void LaunchBall()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition - (Vector2)transform.position).normalized;

        GetComponent<Rigidbody2D>().velocity = direction * speed;

        lineRenderer.enabled = false;
    }

    private void ShowLaunchDirection()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition - (Vector2)transform.position).normalized;

        lineRenderer.SetColors(Color.white, Color.gray);

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position + (Vector3)direction * 7);

        lineRenderer.enabled = true; 
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            reflectManager.lists.Remove(collision.gameObject);
            Destroy(collision.gameObject);
            
            Vector2 normal = collision.contacts[0].normal;
            direction = Vector2.Reflect(direction, normal);
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
        else if (collision.gameObject.CompareTag("Paddle"))
        {
            Destroy(gameObject);
            Vector2 normal = collision.contacts[0].normal;
            
            float offset = transform.position.x - collision.transform.position.x;
            direction = new Vector2(offset, 1).normalized; 
            
            GetComponent<Rigidbody2D>().velocity = direction * speed;

            if (IsListEmpty(reflectManager.lists))
            {
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 normal = collision.contacts[0].normal;
            direction = Vector2.Reflect(direction, normal);
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
        else if (collision.gameObject.CompareTag("DeathWall"))
        {
            Application.Quit();
            #if UNITY_EDITOR
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            #endif
        }
    }

    private bool IsListEmpty(List<GameObject> list)
    {
        return list.Count == 0; // 리스트의 개수가 0이면 비어있음
    }

}
