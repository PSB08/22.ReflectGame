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

    public void StageSelect(int index)
    {
        SceneManager.LoadScene("Stage" + index);
    }

    
}
