using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonImageChange : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Sprite originImage;
    [SerializeField] private Sprite changedImage;
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(ChangeImage());
    }

    private IEnumerator ChangeImage()
    {
        image.sprite = changedImage;
        yield return new WaitForSeconds(0.5f);
        image.sprite = originImage;
    }


}
