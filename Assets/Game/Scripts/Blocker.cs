using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private DroneBlocker _droneBlocker;

    private Coroutine _disablerCoroutine;

    private bool _isBlocking;
    public bool IsBlocking
    {
        get { return _isBlocking; }
        set
        {
            _isBlocking = value;
            SetSpriteState();
            if (_isBlocking)
            {
                if (_disablerCoroutine != null) StopCoroutine(_disablerCoroutine);
                _disablerCoroutine = StartCoroutine(WaitAndDisable());
            }
        }
    }

    public void Initialize()
    {
        IsBlocking = false;
    }

    private IEnumerator WaitAndDisable()
    {
        yield return new WaitForSeconds(_droneBlocker.DisableWaitDec);
        IsBlocking = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsBlocking)
        {
            var drone = other.GetComponent<Drone>();
            if (drone != null) drone.DoDamage();
            IsBlocking = false;
        }
    }

    private void OnMouseEnter()
    {
        Debug.Log("enter");
    }
    private void OnMouseExit()
    {
        Debug.Log("exit");
    }

    private void OnMouseDown()
    {
        IsBlocking = true;
    }

    private void SetSpriteState()
    {
        if (IsBlocking)
        {
            iTween.Stop(gameObject);
            SetSpriteAlpha(1f);
        }
        else FadeOut();
    }

    private void FadeOut()
    {
        iTween.Stop(gameObject);
        iTween.ValueTo(gameObject, iTween.Hash(
            "from", _droneBlocker.MaxAlpha, "to", _droneBlocker.MinAlpha,
            "time", _droneBlocker.PulseDuration, "easetype", "linear",
            "onupdate", "SetSpriteAlpha", "oncomplete", "FadeIn"));
    }

    private void FadeIn()
    {
        iTween.Stop(gameObject);
        iTween.ValueTo(gameObject, iTween.Hash(
            "from", _droneBlocker.MinAlpha, "to", _droneBlocker.MaxAlpha,
            "time", _droneBlocker.PulseDuration, "easetype", "linear",
            "onupdate", "SetSpriteAlpha", "oncomplete", "FadeOut"));
    }

    private void SetSpriteAlpha(float alpha)
    {
        var color = _sprite.color;
        color.a = alpha;
        _sprite.color = color;
    }
}

