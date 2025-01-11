using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UISoundManager : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioMixer audioMixer;
    [Space(10)]
    [Header("Slider")]
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [Space(10)]
    [Header("Txt")]
    [SerializeField] private TextMeshProUGUI masterTxt;
    [SerializeField] private TextMeshProUGUI musicTxt;
    [SerializeField] private TextMeshProUGUI sfxTxt;
    [Space(10)]
    [Header("MuteBtn")]
    [SerializeField] private Button masterMuteBtn;
    [SerializeField] private Button musicMuteBtn;
    [SerializeField] private Button sfxMuteBtn;
    [Space(10)]
    [Header("Value")]
    [SerializeField] private Sprite sound;
    [SerializeField] private Sprite mute;
    private bool isMasterMuted = false;
    private bool isSfxMuted = false;
    private bool isMusicMuted = false;

    private void Start()
    {
        LoadVolume();
        LoadMuteStates();
        UpdateButtonText();
        masterMuteBtn.onClick.AddListener(ToggleMasterMute);
        musicMuteBtn.onClick.AddListener(ToggleMusicMute);
        sfxMuteBtn.onClick.AddListener(ToggleSfxMute);
    }

    #region volume

    public void SetMasterVolume()
    {
        float volume = masterSlider.value;
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
        masterTxt.text = $"Master Volume : {Mathf.Round(volume * 10)}";
        PlayerPrefs.SetFloat("masterVolume", volume);

        if (volume == 0.001f)
        {
            if (!isMasterMuted)
            {
                ToggleMasterMute();
            }
        }
        else if (isMasterMuted)
        {
            ToggleMasterMute();
        }
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        musicTxt.text = $"Music Volume : {Mathf.Round(volume * 10)}";
        PlayerPrefs.SetFloat("musicVolume", volume);

        if (volume == 0.001f)
        {
            if (!isMusicMuted)
            {
                ToggleMusicMute();
            }
        }
        else if (isMusicMuted)
        {
            ToggleMusicMute();
        }
    }

    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        sfxTxt.text = $"SFX Volume : {Mathf.Round(volume * 10)}";
        PlayerPrefs.SetFloat("sfxVolume", volume);

        if (volume == 0.001f)
        {
            if (!isSfxMuted)
            {
                ToggleSfxMute();
            }
        }
        else if (isSfxMuted)
        {
            ToggleSfxMute();
        }
    }

    private void LoadVolume()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        }
        else
        {
            musicSlider.value = 1;
        }

        if (PlayerPrefs.HasKey("sfxVolume"))
        {
            sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        }
        else
        {
            sfxSlider.value = 1;
        }
        if (PlayerPrefs.HasKey("masterVolume"))
        {
            masterSlider.value = PlayerPrefs.GetFloat("masterVolume");
        }
        else
        {
            masterSlider.value = 1;
        }

        SetMusicVolume();
        SetSFXVolume();
        SetMasterVolume();
    }
    #endregion

    private void ToggleMasterMute()
    {
        isMasterMuted = !isMasterMuted;
        if (!isMasterMuted)
        {
            float currentVolume = masterSlider.value;
            SetMasterMute(false);
            audioMixer.SetFloat("Master", Mathf.Log10(currentVolume) * 20);
        }
        else
        {
            SetMasterMute(true);
        }

        SaveMuteState("masterMute", isMasterMuted);
        UpdateButtonText();
    }

    private void ToggleMusicMute()
    {
        isMusicMuted = !isMusicMuted;
        if (!isMusicMuted)
        {
            float currentVolume = musicSlider.value;
            SetMusicMute(false);
            audioMixer.SetFloat("Music", Mathf.Log10(currentVolume) * 20);
        }
        else
        {
            SetMusicMute(true);
        }

        SaveMuteState("musicMute", isMusicMuted);
        UpdateButtonText();
    }

    private void ToggleSfxMute()
    {
        isSfxMuted = !isSfxMuted;
        if (!isSfxMuted)
        {
            float currentVolume = sfxSlider.value;
            SetSfxMute(false);
            audioMixer.SetFloat("SFX", Mathf.Log10(currentVolume) * 20);
        }
        else
        {
            SetSfxMute(true);
        }

        SaveMuteState("sfxMute", isSfxMuted);
        UpdateButtonText();
    }

    private void SetMasterMute(bool mute)
    {
        audioMixer.SetFloat("Master", mute ? -80f : PlayerPrefs.GetFloat("masterVolume", 0));
    }
    private void SetMusicMute(bool mute)
    {
        audioMixer.SetFloat("Music", mute ? -80f : PlayerPrefs.GetFloat("musicVolume", 0));
    }
    private void SetSfxMute(bool mute)
    {
        audioMixer.SetFloat("SFX", mute ? -80f : PlayerPrefs.GetFloat("sfxVolume", 0));
    }

    private void UpdateButtonText()
    {
        masterMuteBtn.GetComponentInChildren<Image>().sprite = isMasterMuted ? mute : sound;
        musicMuteBtn.GetComponentInChildren<Image>().sprite = isMusicMuted ? mute : sound;
        sfxMuteBtn.GetComponentInChildren<Image>().sprite = isSfxMuted ? mute : sound;
    }

    private void SaveMuteState(string key, bool state)
    {
        PlayerPrefs.SetInt(key, state ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void LoadMuteStates()
    {
        isMasterMuted = PlayerPrefs.GetInt("masterMute", 0) == 1;
        isSfxMuted = PlayerPrefs.GetInt("sfxMute", 0) == 1;
        isMusicMuted = PlayerPrefs.GetInt("musicMute", 0) == 1;

        SetMasterMute(isMasterMuted);
        SetSfxMute(isSfxMuted);
        SetMusicMute(isMusicMuted);
    }

}
