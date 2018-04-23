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
        foreach (Transform blocker in transform)
        {
            if(blocker.GetComponent<Blocker>() != null)
                _blockers.Add(blocker.GetComponent<Blocker>());
        }
    }


}
