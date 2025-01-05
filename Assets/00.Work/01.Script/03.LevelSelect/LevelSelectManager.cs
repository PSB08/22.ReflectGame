using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
    public Button[] buttons;

    private void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);

        for (int i = 0; i < buttons.Length; i++)
        {
            if (i + 2 > levelAt)
            {
                buttons[i].interactable = false;
            }
        }

    }

    public void Stage1()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void Stage2()
    {
        SceneManager.LoadScene("Stage2");
    }
    public void Stage3()
    {
        SceneManager.LoadScene("Stage3");
    }
    public void Stage4()
    {
        SceneManager.LoadScene("Stage4");
    }
    public void Stage5()
    {
        SceneManager.LoadScene("Stage5");
    }
    public void Stage6()
    {
        SceneManager.LoadScene("Stage6");
    }
    public void Stage7()
    {
        SceneManager.LoadScene("Stage7");
    }
    public void Stage8()
    {
        SceneManager.LoadScene("Stage8");
    }
}
