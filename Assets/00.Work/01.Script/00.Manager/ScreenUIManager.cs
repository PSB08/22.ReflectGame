using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScreenUIManager : MonoBehaviour
{
    [Header("ScreenSize")]
    [SerializeField] private TMP_Dropdown screenModeDropdown;
    [SerializeField] private TMP_Text modeText;
    [SerializeField] private GameObject warningMessage;

    private void Start()
    {
        warningMessage.SetActive(false);
        GameObject template = screenModeDropdown.template.gameObject;

        Image back = template.GetComponent<Image>();
        if (back != null)
        {
            Color color = back.color;
            color.a = 0f;
            back.color = color;
        }

        LoadScreenMode();
        screenModeDropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        UpdateScreenMode(screenModeDropdown.value);
    }

    private void Update()
    {
        if (Screen.width != 1920 || Screen.height != 1080)
        {
            warningMessage.SetActive(true);
        }
        else
        {
            warningMessage.SetActive(false);
        }
    }

    #region ScreenSize
    private void OnDropdownValueChanged(int index)
    {
        UpdateScreenMode(index);
    }

    private void UpdateScreenMode(int index)
    {
        switch (index)
        {
            case 0:
                Screen.fullScreen = false;
                Screen.SetResolution(1920, 1080, false);
                modeText.text = "창 모드";
                break;
            case 1:
                Screen.fullScreen = false;
                Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, false);
                modeText.text = "테두리 없는 창 모드";
                break;
            case 2:
                Screen.fullScreen = true;
                modeText.text = "전체화면";
                break;
        }
        PlayerPrefs.SetInt("screenMode", index); // 선택한 모드 저장
    }

    private void LoadScreenMode()
    {
        if (PlayerPrefs.HasKey("screenMode"))
        {
            int savedMode = PlayerPrefs.GetInt("screenMode");
            screenModeDropdown.value = savedMode; // 드롭다운 값 설정
            UpdateScreenMode(savedMode); // 화면 모드 업데이트
        }
    }



    #endregion

    private IEnumerator ShowWarning()
    {
        warningMessage.SetActive(true);
        yield return new WaitForSeconds(2f);
        warningMessage.SetActive(false);
    }
}
