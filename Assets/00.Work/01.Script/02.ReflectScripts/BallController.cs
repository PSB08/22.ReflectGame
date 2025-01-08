using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    [SerializeField] private UnityEvent ballSound;
    [Header("Serial")]
    [SerializeField] private ReflectManager reflectManager;
    [SerializeField] private Camera mainCam;
    [SerializeField] private GameObject effectPrefab;
    [Space(10)]
    [Header("Value")]
    public float speed = 10f;
    public float duration;
    public float strength;
    public int nextSceneLoad;
    private Vector2 direction;
    private bool isActioned = false;

    private LineRenderer lineRenderer;
    private BGMScript bgmScript;

    private void Start()
    {
        bgmScript = FindAnyObjectByType<BGMScript>();
        lineRenderer = GetComponentInChildren<LineRenderer>();
        lineRenderer.positionCount = 2;
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
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

        //lineRenderer.SetColors(Color.white, Color.gray);

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

            ShakeCamera();
            ballSound?.Invoke();
            StartCoroutine(EffectCoroutine());

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
                SceneManager.LoadScene(nextSceneLoad);
                if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
                {
                    PlayerPrefs.SetInt("levelAt", nextSceneLoad);
                }
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            ballSound?.Invoke();
            StartCoroutine(EffectCoroutine());
            Vector2 normal = collision.contacts[0].normal;
            direction = Vector2.Reflect(direction, normal);
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
        else if (collision.gameObject.CompareTag("DeathWall"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private bool IsListEmpty(List<GameObject> list)
    {
        return list.Count == 0;
    }

    public void ShakeCamera()
    {
        mainCam.DOShakePosition(duration, strength);
    }

    private IEnumerator EffectCoroutine()
    {
        Vector3 pos = transform.position;
        GameObject effect = Instantiate(effectPrefab, pos, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        Destroy(effect);
    }

}
