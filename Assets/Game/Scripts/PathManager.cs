using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    [SerializeField] private Path _topLane;
    [SerializeField] private Path _middleLane;
    [SerializeField] private Path _bottomLane;

    public static PathManager Instance { private set; get; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public Path GetPath(LaneType laneType)
    {
        switch (laneType)
        {
            case LaneType.TopLane:
                return _topLane;
            case LaneType.MiddleLane:
                return _middleLane;
            case LaneType.BottomLane:
                return _bottomLane;
        }

        return null;
    }
}

public enum LaneType
{
    TopLane,
    MiddleLane,
    BottomLane,
}
