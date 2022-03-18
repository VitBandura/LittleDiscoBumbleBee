using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _spawnPoints;
    [SerializeField] private float _maxSpawnInterval;
    [SerializeField] private float _minSpawnInterval;
    [SerializeField] private float _intervalOfSpawnSpeedIncreasing;
    
    private ObjectPool _objectPool;
    private int _spawnPointsCount;
    private float _spawnInterval;
    private float _timer;
    
    private void Awake()
    {
        SetCountOfPossibleSpawnPoints();
        InitializeObjectPool();
        DecreaseSpawnInterval();
    }

    private void Update()
    {
        SpawnPerInterval();
    }
   
    private void SetCountOfPossibleSpawnPoints()
    {
        _spawnPointsCount = _spawnPoints.Length;
    }
    
    private void InitializeObjectPool()
    {
        _objectPool = GetComponentInChildren<ObjectPool>();
    }
    
    private void DecreaseSpawnInterval()
    {
        _spawnInterval = _maxSpawnInterval;
        StartCoroutine(IncreaseSpawnSpeedPerTime());
    }

    private void SpawnPerInterval()
    {
        if (_timer <= 0)
        {
            SpawnObjectFromPool();
            _timer = _spawnInterval;
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }

    private void SpawnObjectFromPool()
    {
        var prefab = _objectPool.TakeRandomObjectFromPool();
        InitializeObjectFromPool(prefab);
    }

    private void InitializeObjectFromPool(GameObject prefab)
    {
        prefab.transform.position = SetRandomSpawnPoint();
        prefab.SetActive(true);
    }

    private Vector3 SetRandomSpawnPoint()
    {
        return _spawnPoints[Random.Range(0, _spawnPointsCount)].transform.position;
    }

    private IEnumerator IncreaseSpawnSpeedPerTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(_intervalOfSpawnSpeedIncreasing);
            _maxSpawnInterval /= 2;
            _spawnInterval = Mathf.Max(_maxSpawnInterval, _minSpawnInterval);
            if (_spawnInterval <= _minSpawnInterval)
            {
               StopAllCoroutines();
            }
        }
    }
}
