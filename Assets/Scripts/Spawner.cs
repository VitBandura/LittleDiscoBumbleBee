using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Flower[] _prefabsForSpawn;
    [SerializeField] private GameObject[] _spawnPoints;
    [SerializeField] private float _spawnInterval;

    [SerializeField] private ScoreManager _scoreManager; //refactor into separated

    private int _prefabsForSpawnCount;
    private int _spawnPointsCount;
    private float _timer;
    
    private void Awake()
    {
        _prefabsForSpawnCount = _prefabsForSpawn.Length;
        _spawnPointsCount = _spawnPoints.Length;
    }
    private void Update()
    {
        if (_timer <= 0)
        {
            SpawnInteractiveUnit();
            _timer = _spawnInterval;
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }
    private void SpawnInteractiveUnit()
    {
        var currentPrefabForSpawn = _prefabsForSpawn[Random.Range(0, _prefabsForSpawnCount)];
        var currentSpawnPoint = _spawnPoints[Random.Range(0, _spawnPointsCount)].transform.position;
        var flower = Instantiate(currentPrefabForSpawn, currentSpawnPoint,quaternion.identity);
        flower.IncreaseScore += _scoreManager.AddScorePoint;
        
    }
}
