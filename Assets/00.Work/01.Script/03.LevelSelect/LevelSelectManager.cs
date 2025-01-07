using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
    [Header("StageButton")]
    public Button[] stageButtons;
    [Header("PageButton")]
    public Button[] pageButtons;

    private void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);

        for (int i = 0; i < stageButtons.Length; i++)
        {
            if (i + 2 > levelAt)
            {
                stageButtons[i].interactable = false;
            }
        }

        pageButtons[0].interactable = false;
        pageButtons[1].interactable = true;
        pageButtons[2].interactable = true;
        pageButtons[3].interactable = true;
        pageButtons[4].interactable = true;

    }

    public void StageSelect(int index)
    {
        SceneManager.LoadScene("Stage" + index);
    }

    public void StageButton(int index)
    {
        switch (index)
        {
            case 1:
                for (int i = 0; i < 5; i++)
                {
                    stageButtons[i].gameObject.SetActive(true);
                }
                for (int j = 5; j < 10; j++)
                {
                    stageButtons[j].gameObject.SetActive(false);
                }
                for (int k = 10; k < 15; k++)
                {
                    stageButtons[k].gameObject.SetActive(false);
                }
                for (int l = 15; l < 20; l++)
                {
                    stageButtons[l].gameObject.SetActive(false);
                }
                pageButtons[0].interactable = false;
                pageButtons[1].interactable = true;
                pageButtons[2].interactable = true;
                pageButtons[3].interactable = true;
                pageButtons[4].interactable = true;
                break;
            case 2:
                for (int i = 0; i < 5; i++)
                {
                    stageButtons[i].gameObject.SetActive(false);
                }
                for (int j = 5; j < 10; j++)
                {
                    stageButtons[j].gameObject.SetActive(true);
                }
                for (int k = 10; k < 15; k++)
                {
                    stageButtons[k].gameObject.SetActive(false);
                }
                for (int l = 15; l < 20; l++)
                {
                    stageButtons[l].gameObject.SetActive(false);
                }
                pageButtons[0].interactable = true;
                pageButtons[1].interactable = false;
                pageButtons[2].interactable = true;
                pageButtons[3].interactable = true;
                pageButtons[4].interactable = true;
                break;
            case 3:
                for (int i = 0; i < 5; i++)
                {
                    stageButtons[i].gameObject.SetActive(false);
                }
                for (int j = 5; j < 10; j++)
                {
                    stageButtons[j].gameObject.SetActive(false);
                }
                for (int k = 10; k < 15; k++)
                {
                    stageButtons[k].gameObject.SetActive(true);
                }
                for (int l = 15; l < 20; l++)
                {
                    stageButtons[l].gameObject.SetActive(false);   
                }
                pageButtons[0].interactable = true;
                pageButtons[1].interactable = true;
                pageButtons[2].interactable = false;
                pageButtons[3].interactable = true;
                pageButtons[4].interactable = true;
                break;
            case 4:
                for (int i = 0; i < 5; i++)
                {
                    stageButtons[i].gameObject.SetActive(false);
                }
                for (int j = 5; j < 10; j++)
                {
                    stageButtons[j].gameObject.SetActive(false);
                }
                for (int k = 10; k < 15; k++)
                {
                    stageButtons[k].gameObject.SetActive(false);
                }
                for (int l = 15; l < 20; l++)
                {
                    stageButtons[l].gameObject.SetActive(true);
                }
                pageButtons[0].interactable = true;
                pageButtons[1].interactable = true;
                pageButtons[2].interactable = true;
                pageButtons[3].interactable = false;
                pageButtons[4].interactable = true;
                break;
            default:
                break;
        }

        
    }
    
}
