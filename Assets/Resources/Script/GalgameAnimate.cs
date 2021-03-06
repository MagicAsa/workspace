﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GalgameAnimate {

    public void DoCharacterHide(GameObject target, GalgameKeyframe keyframe, Action callback, float duration = 0.1f)
    {
        Sequence sequence = DOTween.Sequence();
        if (GalgameUtil.Instance.IsBaseChange(target, keyframe)) {
            sequence.Join(target.GetComponent<SpriteRenderer>().DOFade(0.95f, duration));
        }
        GameObject face = target.transform.GetChild(0).gameObject;
        if (GalgameUtil.Instance.IsFaceChange(face, keyframe))
        {
            sequence.Join(face.GetComponent<SpriteRenderer>().DOFade(0.95f, duration));
        }
        sequence.AppendCallback(new TweenCallback(callback));
    }

    public void DoCharacterShow(GameObject target, GalgameKeyframe keyframe, Action callback, float endValue = 1,float duration = 0.2f)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Join(target.GetComponent<SpriteRenderer>().DOFade(endValue, duration));
        GameObject face = target.transform.GetChild(0).gameObject;
        sequence.Join(face.GetComponent<SpriteRenderer>().DOFade(endValue, duration));
        sequence.AppendCallback(new TweenCallback(callback));
    }

    public void DoLocalMove(GameObject target, GalgameKeyframe keyframe, Action callback =null, float endValue = 1, float duration = 0.2f)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Join(target.transform.DOLocalMove(keyframe.Position, duration));
        if(callback!=null) sequence.AppendCallback(new TweenCallback(callback));
    }

    public void DoLocalRotate(GameObject target, GalgameKeyframe keyframe, Action callback = null, float endValue = 1, float duration = 0.2f)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Join(target.transform.DOLocalRotate(keyframe.Rotation, duration));
        if (callback != null) sequence.AppendCallback(new TweenCallback(callback));
    }

    public void DoScale(GameObject target, GalgameKeyframe keyframe, Action callback = null, float endValue = 1, float duration = 0.2f)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Join(target.transform.DOScale(keyframe.Scale, duration));
        if (callback != null) sequence.AppendCallback(new TweenCallback(callback));
    }

    //单例模式
    private static GalgameAnimate _instance = null;

    private GalgameAnimate()
    {

    }

    public static GalgameAnimate Instance
    {
        get { return _instance ?? (_instance = new GalgameAnimate()); }
    }
}
