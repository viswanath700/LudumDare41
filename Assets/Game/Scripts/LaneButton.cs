using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LaneButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private LaneButtonManager _laneButtonManager;
    [SerializeField] private LaneType _laneType;
    [SerializeField] private Button _button;
    [SerializeField] private Image _image;
    [SerializeField] private float _pulseDuration = 0.5f;
    [SerializeField] private float _maxAlpha = 0.5f;

    private void Awake()
    {
        _button.onClick.AddListener(Button_Onclick);
    }

    private void Button_Onclick()
    {
        _laneButtonManager.SelectLane(_laneType);
    }

    private void OnEnable()
    {
        ToggleImagePusle(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ToggleImagePusle(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ToggleImagePusle(true);
    }

    private void ToggleImagePusle(bool isPulsing)
    {
        if (isPulsing)
        {
            FadeOut();
        }
        else
        {
            iTween.Stop(gameObject);
            SetImageAlpha(_maxAlpha);
        }
    }

    private void FadeOut()
    {
        iTween.Stop(gameObject);
        iTween.ValueTo(gameObject, iTween.Hash(
            "from", _maxAlpha, "to", 0.0f,
            "time", _pulseDuration, "easetype", "linear",
            "onupdate", "SetImageAlpha", "oncomplete", "FadeIn"));
    }

    private void FadeIn()
    {
        iTween.Stop(gameObject);
        iTween.ValueTo(gameObject, iTween.Hash(
            "from", 0.0f, "to", _maxAlpha,
            "time", _pulseDuration, "easetype", "linear",
            "onupdate", "SetImageAlpha", "oncomplete", "FadeOut"));
    }

    private void SetImageAlpha(float alpha)
    {
        var color = _image.color;
        color.a = alpha;
        _image.color = color;
    }
}
