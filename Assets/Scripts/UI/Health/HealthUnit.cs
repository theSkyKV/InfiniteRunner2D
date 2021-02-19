﻿using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthUnit : MonoBehaviour
{
    [SerializeField] private float _lerpDuration;

    private Image _image;

    private void OnEnable()
    {
        _image = GetComponent<Image>();
    }

    public void ToFill()
    {
        StartCoroutine(Filling(0, 1, _lerpDuration, Fill));
    }

    public void ToEmpty()
    {
        StartCoroutine(Filling(1, 0, _lerpDuration, Destroy));
    }

    private IEnumerator Filling(float startValue, float endValue, float duration, UnityAction<float> lerpingEnd)
    {
        float elapsedTime = 0;
        float nextValue;

        while (elapsedTime < duration)
        {
            nextValue = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
            _image.fillAmount = nextValue;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        lerpingEnd?.Invoke(endValue);
    }

    private void Destroy(float value)
    {
        _image.fillAmount = value;
        Destroy(gameObject);
    }

    private void Fill(float value)
    {
        _image.fillAmount = value;
    }
}
