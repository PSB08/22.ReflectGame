using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonEffect : MonoBehaviour, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DORewind();
        transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0.2f), 0.25f).SetAutoKill(false).SetUpdate(true);
    }

}
