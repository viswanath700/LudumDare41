using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private List<PlayerProperties> _friendlyPlayers;
    [SerializeField] private List<PlayerProperties> _enemyPlayers;
    [SerializeField] private float _spawnRate = 3f;
    [SerializeField] private LaneButtonManager _laneButtonManager;

    public static GameManager Instance { private set; get; }

    private Player _player;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        StartCoroutine(RandomlyPickPlayer());
    }

    private IEnumerator RandomlyPickPlayer()
    {
        yield return new WaitForSeconds(_spawnRate);

        _player = Instantiate(_playerPrefab, transform);
        var randomIndex = Random.Range(0, _friendlyPlayers.Count);
        _player.InitializePlayer(_friendlyPlayers[randomIndex]);

        _laneButtonManager.ToggleButtons(true);
    }

    public void SetPathAndSpawn(Path path)
    {
        _player.SetPath(path);
        StartCoroutine(RandomlyPickPlayer());
    }
}

public enum PlayerType
{
    Friend,
    Enemy,
}
