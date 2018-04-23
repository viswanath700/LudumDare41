using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenOpacity : MonoBehaviour {

	[SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private float _minAlpha;
    [SerializeField] private float _maxAlpha;
    [SerializeField] private float _pulseDuration;

    private bool _isBlocking;
    
    private void Awake()
    {
        FadeOut();
    }

    private void FadeOut()
    {
        iTween.Stop(gameObject);
        iTween.ValueTo(gameObject, iTween.Hash(
            "from", _maxAlpha, "to", _minAlpha,
            "time", _pulseDuration, "easetype", "linear",
            "onupdate", "SetSpriteAlpha", "oncomplete", "FadeIn"));
    }

    private void FadeIn()
    {
        iTween.Stop(gameObject);
        iTween.ValueTo(gameObject, iTween.Hash(
            "from", _minAlpha, "to", _maxAlpha,
            "time", _pulseDuration, "easetype", "linear",
            "onupdate", "SetSpriteAlpha", "oncomplete", "FadeOut"));
    }

    private void SetSpriteAlpha(float alpha)
    {
        var color = _sprite.color;
        color.a = alpha;
        _sprite.color = color;
    }
}
