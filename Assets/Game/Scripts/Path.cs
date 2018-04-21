using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private List<Transform> _points = new List<Transform>();

    public List<Transform> Points { get { return _points; } }

    private void Update()
    {
        DrawDebugPath();
    }

    private void DrawDebugPath()
    {
        for(int i = 0; i < _points.Count - 1; i++)
        {
            Debug.DrawLine(_points[i].position, _points[i + 1].position, Color.red);
        }
    }

    [ContextMenu ("Load Points To Path")]
    private void LoadPoints()
    {
        _points.Clear();
        foreach (Transform point in transform)
        {
            _points.Add(point);
        }
    }
}
