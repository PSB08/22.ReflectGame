using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReflectUIManager : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void ClickBtn()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void RetryBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitBtn()
    {
        SceneManager.LoadScene("TitleScene");
    }

}
