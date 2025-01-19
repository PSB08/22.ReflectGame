using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBall : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    private void Start()
    {
        LoadGachaSprite();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            LoadGachaSprite();
        }
    }
    private void LoadGachaSprite()
    {
        string spriteName = PlayerPrefs.GetString("sprite");
        foreach (Sprite sprite in sprites)
        {
            if (sprite.name == spriteName)
            {
                spriteRenderer.sprite = sprite;
                break;
            }
        }
    }


}
