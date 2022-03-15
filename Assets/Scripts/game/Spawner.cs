using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _spawnPoints;
    [SerializeField] private float _spawnInterval;
    
    private ObjectPool _objectPool;
    private int _spawnPointsCount;
    private float _timer;
    
    private void Awake()
    {
        _spawnPointsCount = _spawnPoints.Length;
        _objectPool = GetComponentInChildren<ObjectPool>();
    }
    
    private void Update()
    {
        SpawnPerInterval();
    }

    private void SpawnPerInterval()
    {
        if (_timer <= 0)
        {
            Spawn();
            _timer = _spawnInterval;
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }

    private void Spawn()
    {
        var prefab = _objectPool.TakeRandomObjectFromPool();
        prefab.transform.position = SetRandomSpawnPoint();
        prefab.SetActive(true);
    }

    private Vector3 SetRandomSpawnPoint()
    {
        return _spawnPoints[Random.Range(0, _spawnPointsCount)].transform.position;
    }
}
