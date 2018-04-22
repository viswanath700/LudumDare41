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
    private Player _enemyPlayer;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        StartCoroutine(RandomlyPickPlayer());
        StartCoroutine(RandomlySpawnEnemies());
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

    private IEnumerator RandomlySpawnEnemies()
    {
        yield return new WaitForSeconds(_spawnRate);

        while (true)
        {
            _enemyPlayer = Instantiate(_playerPrefab, transform);
            var randomIndex = Random.Range(0, _enemyPlayers.Count);
            _enemyPlayer.InitializePlayer(_enemyPlayers[randomIndex]);
            _enemyPlayer.SetPath(GetRandomPath());

            yield return new WaitForSeconds(_spawnRate);
        }
    }

    private Path GetRandomPath()
    {
        var randomIndex = Random.Range(0, 3);
        var laneType = LaneType.TopLane;

        switch (randomIndex)
        {
            case 1:
                laneType = LaneType.MiddleLane;
                break;
            case 2:
                laneType = LaneType.BottomLane;
                break;
        }

        return PathManager.Instance.GetPath(laneType);
    }
}

public enum PlayerType
{
    Friend,
    Enemy,
}
