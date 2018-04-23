using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBlocker : MonoBehaviour
{
    [SerializeField] private float _minAlpha;
    [SerializeField] private float _maxAlpha;
    [SerializeField] private float _pulseDuration;
    [SerializeField] private float _disableWaitDec;

    private bool _isInverted;
    public bool IsInverted { get { return _isInverted;} set { _isInverted = value; SetBlockState(); } }

    public float MinAlpha { get { return _minAlpha; } }
    public float MaxAlpha { get { return _maxAlpha; } }
    public float PulseDuration { get { return _pulseDuration; } }
    public float DisableWaitDec { get { return _disableWaitDec; } }

    private List<Blocker> _blockers = new List<Blocker>();

    private void Awake()
    {
        LoadBlockers();
    }

    private void LoadBlockers()
    {
        _blockers.Clear();
        foreach (Transform blockerTransform in transform)
        {
            if(blockerTransform.GetComponent<Blocker>() != null)
            {
                var blocker = blockerTransform.GetComponent<Blocker>();
                blocker.Initialize();
                _blockers.Add(blocker);
            }
        }
    }

    private void SetBlockState()
    {

    }

    [ContextMenu("Toggle Invert State")]
    private void ToggleInvertState()
    {
        IsInverted = !IsInverted;
    }
}
