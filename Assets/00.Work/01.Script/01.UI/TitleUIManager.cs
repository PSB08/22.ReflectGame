using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleUIManager : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private GameObject panel;
    [Space(10)]
    [Header("Button")]
    [SerializeField] private Button openSettingBtn;
    [SerializeField] private Button closeSettingBtn;
    [SerializeField] private Button exitBtn;

    private void Start()
    {
        panel.SetActive(false);
        exitBtn.onClick.AddListener(ExitBtn);
        openSettingBtn.onClick.AddListener(OpenSettingBtn);
        closeSettingBtn.onClick.AddListener(CloseSettingBtn);
    }


    #region Esc

    public void OpenSettingBtn()
    {
        panel.SetActive(true);
        panel.transform.DOMoveY(540, 0.5f);
    }

    public void CloseSettingBtn()
    {
        panel.transform.DOMoveY(1620, 0.5f);
    }


    public void ExitBtn()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    #endregion
}
