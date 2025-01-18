using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GachaManager : MonoBehaviour
{
    public Sprite[] ballImages;
    public Image image;

    private void Start()
    {
        image.enabled = false;
    }

    public void GachaBtnClick()
    {
        int index = Random.Range(0, ballImages.Length);
        string ballName = ballImages[index].name;
        
        image.sprite = ballImages[index];
        image.enabled = true;

        PlayerPrefs.SetString("sprite", ballName);
        PlayerPrefs.Save();
    }

    public void ExitBtn()
    {
        SceneManager.LoadScene("TitleScene");
    }

}
