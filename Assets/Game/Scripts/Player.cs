using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private FollowPath _followPath;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _targetReach;
    [SerializeField] private Vector3 _modelPosition;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Vector3 _friendPosition;
    [SerializeField] private Vector3 _enemyPosition;

    public PlayerType PlayerType { get; private set; }

    public void InitializePlayer(PlayerProperties _playerProperties)
    {
        gameObject.name = _playerProperties.PlayerName;
        PlayerType = _playerProperties.PlayerType;

        if (PlayerType == PlayerType.Friend) transform.localPosition = _friendPosition;
        else transform.localPosition = _enemyPosition;

        if (_playerProperties.PlayerModel != null)
        {
            var model = Instantiate(_playerProperties.PlayerModel, transform);
            model.transform.localPosition = _modelPosition;
        }
        else _meshRenderer.enabled = true;

        _rigidbody.mass = _playerProperties.Mass;
        _followPath.InitializeProperties(_playerProperties.PlayerType, 
            _playerProperties.MovementSpeed, _rotationSpeed, _targetReach);
    }

    public void SetPath(Path path)
    {
        _followPath.SetPath(path);
    }
}
