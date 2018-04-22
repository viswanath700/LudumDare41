using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSpawner : MonoBehaviour
{
    [SerializeField] private Drone _dronePrefab;
    [SerializeField] private float _spawnRatePerSec;
    [SerializeField] private Transform _spawnPointer;
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();

    public static Coroutine SpawnerCoroutine;

    private void Awake()
    {
        SpawnerCoroutine = StartCoroutine(SpawnDronesFrequently());
    }

    private IEnumerator SpawnDronesFrequently()
    {
        yield return new WaitForSeconds(1 / _spawnRatePerSec);

        while (true)
        {
            var randomSpawnIndex = Random.Range(0, _spawnPoints.Count);
            var drone = Instantiate(_dronePrefab, _spawnPoints[randomSpawnIndex]);
            drone.transform.localPosition = Vector3.zero;
            drone.transform.localScale = Vector3.one;

            yield return new WaitForSeconds(1 / _spawnRatePerSec);
        }
    }

    [ContextMenu("Load Spawn Points")]
    private void LoadSpawnPoints()
    {
        _spawnPoints.Clear();

        foreach(Transform child in _spawnPointer.transform)
        {
            _spawnPoints.Add(child);
        }
    }
}
