using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [Serializable]
    public enum MoveXY
    {
        X, Y
    }

    [Header("TweenInfo")]

    [SerializeField] private MoveXY _moveXY;
    [SerializeField] private LoopType _loopType;
    [SerializeField] private Ease _ease;
    [SerializeField] private int _loopCnt;
    [SerializeField] private float _endValue;
    [SerializeField] private float _duration;

    private Tween _moveTween;

    private void Awake()
    {
        SetXY();
        _moveTween.Play();
    }

    private void SetXY()
    {
        switch (_moveXY)
        {
            case MoveXY.X:
                _moveTween = transform.DOMoveX(transform.position.x + _endValue, _duration).SetLoops(_loopCnt, _loopType).SetEase(_ease).Pause();
                break;
            case MoveXY.Y:
                _moveTween = transform.DOMoveY(transform.position.y + _endValue, _duration).SetLoops(_loopCnt, _loopType).SetEase(_ease).Pause();
                break;
        }
    }

    private void OnDestroy()
    {
        _moveTween.Kill();
    }
}
