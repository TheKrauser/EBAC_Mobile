using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BounceHelper : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private Vector3 startScale;
    [SerializeField] private Vector3 punchForce;
    [SerializeField] private Ease ease;

    private Tween tween;

    public void Bounce()
    {
        if (tween != null) tween.Kill();

        transform.localScale = startScale;
        
        tween = transform.DOPunchScale(punchForce, duration, 10, 1).SetEase(ease);
    }
}
