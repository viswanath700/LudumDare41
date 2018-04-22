using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneButtonManager : MonoBehaviour
{
    [SerializeField] private List<LaneButton> _laneButtons;

    private void Awake()
    {
        ToggleButtons(false);
    }

    public void SelectLane(LaneType laneType)
    {
        ToggleButtons(false);
        GameManager.Instance.SetPathAndSpawn(PathManager.Instance.GetPath(laneType));
    }

    public void ToggleButtons(bool isActive)
    {
        foreach(var button in _laneButtons)
        {
            button.gameObject.SetActive(isActive);
        }
    }
}
