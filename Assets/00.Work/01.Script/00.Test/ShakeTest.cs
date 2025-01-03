using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeTest : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    public float duration;
    public float strength;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShakeCamera();
        }
    }

    public void ShakeCamera()
    {
        mainCam.DOShakePosition(duration, strength);
    }

}
