using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleHelper : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private Vector3 startScale;
    [SerializeField] private Vector3 endScale;
    [SerializeField] private Ease ease;

    private Tween tween;

    private void Awake()
    {
        Scale();
    }

    public void Scale()
    {
        transform.localScale = startScale;

        if (tween != null) tween.Kill();

        transform.DOScale(endScale, duration).SetEase(ease);
    }

    public void ScaleOut()
    {
        transform.localScale = endScale;

        if (tween != null) tween.Kill();

        transform.DOScale(Vector2.zero, duration).SetEase(ease).SetDelay(1.5f);
    }
}
