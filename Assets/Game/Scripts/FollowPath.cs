using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    [SerializeField] private Path _path;
    [SerializeField] private float _speed;
    [SerializeField] private float _targetReach;

    private int _currentIndex;
    private bool _isfollowingPath;
    private Vector3 _targetPosition;

    private void Start()
    {
        StartFollowing();
    }

    [ContextMenu ("Start Following")]
    private void StartFollowing()
    {
        _targetPosition = _path.Points[_currentIndex].position;
        _isfollowingPath = true;
    }

    [ContextMenu("Stop Following")]
    private void StopFollowing()
    {
        _isfollowingPath = false;
    }

    private void FixedUpdate()
    {
        FollowPathPoints();
        //transform.rotation = Quaternion.identity;
    }

    private void FollowPathPoints()
    {
        if (_isfollowingPath)
        {
            transform.position = Vector3.Lerp(transform.position, _targetPosition, _speed * Time.deltaTime);
            SetRotation();

            var distance = Vector3.SqrMagnitude(transform.position - _path.Points[_currentIndex].position);

            if (distance < _targetReach)
            {
                _currentIndex++;
                if (_currentIndex >= _path.Points.Count) _currentIndex = 0;
                _targetPosition = _path.Points[_currentIndex].position;
            }
        }
    }

    private void SetRotation()
    {
        var direction = _targetPosition - transform.position;
        direction.y = 0;
        var rotation = transform.localEulerAngles;
        rotation.x = 0;
        rotation.y = 90 - Vector3.Angle(direction, Vector3.right);
        rotation.z = 0;
        transform.localEulerAngles = rotation;
    }
}
