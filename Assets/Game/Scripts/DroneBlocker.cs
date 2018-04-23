using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBlocker : MonoBehaviour
{
    private List<Blocker> _blockers = new List<Blocker>();

    private void Awake()
    {
        LoadBlockers();
    }

    private void LoadBlockers()
    {
        _blockers.Clear();
        foreach (Blocker blocker in transform)
        {
            _blockers.Add(blocker);
        }
    }


}
