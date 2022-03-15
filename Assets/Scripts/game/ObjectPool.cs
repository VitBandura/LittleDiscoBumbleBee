using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabsForSpawn;
    [SerializeField] private int _countOfEachPrefabInPool;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private HealthManager _healthManager;
    [SerializeField] private Player _player;
    [SerializeField] private ObjectDestroyer _objectDestroyer;
    [SerializeField] private SoundManager _soundManager;

    private List<GameObject> _objectPool;

    private void Awake()
    {
        InitializePool();
        SubscribePlayerOnPool();
        SubscribeOnObjectDestroyer();
    }
    
    private void InitializePool()
    {
        _objectPool = new List<GameObject>();
        IncreasePoolSize();
    }
    
    public GameObject TakeRandomObjectFromPool()
    {
        if (_objectPool.Count < 1)
        {
            IncreasePoolSize();
        }
        var randomIndex = Random.Range(0, _objectPool.Count);
        var randomObject = _objectPool[randomIndex];
        _objectPool.RemoveAt(randomIndex);
        return randomObject;
    }

    private void ReturnUsedObjectIntoPool(GameObject usedObject)
    {
        usedObject.SetActive(false);
        _objectPool.Add(usedObject);
    }
    private void IncreasePoolSize()
    {
        var prefabsForSpawnCount = _prefabsForSpawn.Length;
        for (var i = 0; i < prefabsForSpawnCount; i++)
        {
            for (var j = 0; j < _countOfEachPrefabInPool; j++)
            {
                AddUniquePrefabIntoPool(i);
            }
        }
        
    }

    private void AddUniquePrefabIntoPool(int i)
    {
        var prefab = Instantiate(_prefabsForSpawn[i]);
        SubscribeManagers(prefab);
        prefab.SetActive(false);
        _objectPool.Add(prefab);
    }

    private void SubscribeManagers(GameObject prefab)
    {
        if (prefab.GetComponent<Flower>() != null)
        {
            SubscribeScoreAndSoundManagersOnThisFlower(prefab);
        }
        else if (prefab.GetComponent<Cactus>() != null)
        {
            SubscribeHealthAndSoundManagersOnThisCactus(prefab);
        }
    }

    private void SubscribeHealthAndSoundManagersOnThisCactus(GameObject prefab)
    {
        prefab.GetComponent<Cactus>().HarmPlayer += _healthManager.TakeDamage;
        prefab.GetComponent<Cactus>().HarmPlayer += _soundManager.PlayHarmPlayerSound;
    }

    private void SubscribeScoreAndSoundManagersOnThisFlower(GameObject prefab)
    {
        prefab.GetComponent<Flower>().IncreaseScore += _scoreManager.AddScorePoint;
        prefab.GetComponent<Flower>().IncreaseScore += _soundManager.PlayIncreaseScoreSound;
    }

    private void SubscribePlayerOnPool()
    {
        _player.ReturningIntoPoolEvent += ReturnUsedObjectIntoPool;
    }

    private void SubscribeOnObjectDestroyer()
    {
        _objectDestroyer.ReturningIntoPoolEvent += ReturnUsedObjectIntoPool;
    }
}
