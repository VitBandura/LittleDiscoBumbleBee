using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private FlowerPool _flowerPool;
    [SerializeField] private GameObject[] _spawnPoints;
    [SerializeField] private float _spawnInterval;
    
    private int _spawnPointsCount;
    private float _timer;
    
    private void Awake()
    {
        _spawnPointsCount = _spawnPoints.Length;
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
        var flower = _flowerPool.TakeFlowerFromPool();
        flower.transform.position = SetRandomSpawnPoint();
        flower.SetActive(true);
    }

    private Vector3 SetRandomSpawnPoint()
    {
        return _spawnPoints[Random.Range(0, _spawnPointsCount)].transform.position;
    }
}
