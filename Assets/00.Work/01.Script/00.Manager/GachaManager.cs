using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GachaManager : MonoBehaviour
{
    private Vector3 imagesTrans;
    public Sprite[] sportsballImage;
    public Sprite[] planetballImage;
    public Sprite[] foodballImage;
    public GameObject panel;
    public Image image;
    public Sprite circle;

    private void Start()
    {
        panel.SetActive(false);
        image.enabled = false;
        imagesTrans = image.transform.position;
    }

    public void ResetBall()
    {
        image.sprite = circle;
        string ballName = circle.name;
        PlayerPrefs.SetString("sprite", ballName);
        PlayerPrefs.Save();
    }

    public void GachaBtnClick()
    {
        int index = Random.Range(0, sportsballImage.Length);
        string ballName = sportsballImage[index].name;

        image.sprite = sportsballImage[index];
        StartCoroutine(FadeImage());

        PlayerPrefs.SetString("sprite", ballName);
        PlayerPrefs.Save();
    }
    public void GachaPlanetball()
    {
        int index = Random.Range(0, planetballImage.Length);
        string ballName = planetballImage[index].name;

        image.sprite = planetballImage[index];
        StartCoroutine(FadeImage());

        PlayerPrefs.SetString("sprite", ballName);
        PlayerPrefs.Save();
    }

    public void GachaFruitball()
    {
        int index = Random.Range(0, foodballImage.Length);
        string ballName = foodballImage[index].name;

        image.sprite = foodballImage[index];
        StartCoroutine(FadeImage());

        PlayerPrefs.SetString("sprite", ballName);
        PlayerPrefs.Save();
    }

    public void ExitBtn()
    {
        SceneManager.LoadScene("TitleScene");
    }

    private IEnumerator FadeImage()
    {
        panel.SetActive(true);
        image.rectTransform.DOMoveY(500, 0.7f);
        image.enabled = true;
        image.transform.position = imagesTrans;
        yield return new WaitForSeconds(1f);
        image.enabled = false;
        panel.SetActive(false);
    }

}
