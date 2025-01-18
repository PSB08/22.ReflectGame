using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GachaManager : MonoBehaviour
{
    private Vector3 imagesTrans;
    public Sprite[] ballImages;
    public GameObject panel;
    public Image image;

    private void Start()
    {
        panel.SetActive(false);
        image.enabled = false;
        imagesTrans = image.transform.position;
    }

    public void GachaBtnClick()
    {
        int index = Random.Range(0, ballImages.Length);
        string ballName = ballImages[index].name;

        image.sprite = ballImages[index];
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
        image.rectTransform.DOMoveY(500, 1);
        image.enabled = true;
        image.transform.position = imagesTrans;
        yield return new WaitForSeconds(2f);
        image.enabled = false;
        panel.SetActive(false);
    }

}
