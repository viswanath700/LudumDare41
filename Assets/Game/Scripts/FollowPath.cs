using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    private PlayerType _payerType;
    private Path _path;
    private float _movementSpeed;
    private float _rotationSpeed;
    private float _targetReach;
    private int _currentIndex;
    private int _previousIndex;
    private bool _isfollowingPath;
    private Vector3 _targetPosition;

    private int CurrentIndex
    {
        get { return _currentIndex; }
        set
        {
            _currentIndex = value;
            if (_currentIndex >= _path.Points.Count) _currentIndex = _path.Points.Count - 1;
            if (_currentIndex < 0) _currentIndex = 0;
        }
    }

    public void InitializeProperties(PlayerType playerType, float movementSpeed,
        float rotationSpeed, float targetReach)
    {
        _payerType = playerType;
        _movementSpeed = movementSpeed;
        _rotationSpeed = rotationSpeed;
        _targetReach = targetReach;
    }

    public void SetPath(Path path)
    {
        _path = path;
        StartFollowing();
    }

    [ContextMenu ("Start Following")]
    private void StartFollowing()
    {
        if (_payerType == PlayerType.Enemy)
        {
            CurrentIndex = _path.Points.Count - 2;
            _previousIndex = CurrentIndex + 1;
        }
        else
        {
            CurrentIndex = 1;
            _previousIndex = CurrentIndex - 1;
        }

        _targetPosition = _path.Points[CurrentIndex].position;
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
    }

    private void FollowPathPoints()
    {
        if (_isfollowingPath)
        {
            var direction = (_targetPosition - transform.position);            
            transform.position = transform.position + direction.normalized * _movementSpeed * Time.deltaTime;
            SetRotation();

            var distance = Vector3.SqrMagnitude(transform.position - _targetPosition);
            if (distance < _targetReach)
            {
                _previousIndex = CurrentIndex;
                if (_payerType == PlayerType.Enemy) CurrentIndex--;
                else CurrentIndex++;
                if (_previousIndex == CurrentIndex) FinishRace();
                _targetPosition = _path.Points[CurrentIndex].position;
            }
        }
    }

    private void SetRotation()
    {
        var direction = _targetPosition - transform.position;
        direction.y = 0;
        var rotation = transform.localEulerAngles;

        rotation.x = 0;
        rotation.z = 0;

        var rot = Vector3.Dot(direction, Vector3.right) > 0 ? 1 : -1;
        rotation.y = Mathf.LerpAngle(rotation.y,  90 + rot * Vector3.Angle(direction, Vector3.right), _rotationSpeed * Time.deltaTime);

        transform.localEulerAngles = rotation;
    }

    private void FinishRace()
    {
        _isfollowingPath = false;
        Destroy(gameObject, 1f);
    }
}
