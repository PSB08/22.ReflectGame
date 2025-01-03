using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReflectUIManager : MonoBehaviour
{
    public Image fadeImage;

    [SerializeField] private string sceneName;

    private void Start()
    {
        Time.timeScale = 1.0f;
        fadeImage.gameObject.SetActive(true);
        FadeIn();
    }

    public void ClickBtn()
    {
        FadeOutAndLoadScene(sceneName);
    }
    public void RetryBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitBtn()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void FadeIn()
    {
        fadeImage.DOFade(0, 1.5f).OnComplete(() => fadeImage.gameObject.SetActive(false));
    }

    public void FadeOutAndLoadScene(string sceneName)
    {
        fadeImage.gameObject.SetActive(true);
        fadeImage.DOFade(1, 1.5f).OnComplete(() => SceneManager.LoadScene(sceneName));
    }

}
