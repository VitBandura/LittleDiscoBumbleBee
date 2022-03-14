using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabsForSpawn;
    [SerializeField] private int _countOfEachPrefabInPool;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private HealthManager _healthManager;

    private List<GameObject> _objectPool;

    private void Awake()
    {
        InitializePool();
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
        return _objectPool[randomIndex];
    }

    public void ReturnUsedObjectIntoPool(GameObject usedObject)
    {
        usedObject.SetActive(false);
        _objectPool.Add(usedObject);
    }
    private void IncreasePoolSize()
    {
        var prefabsForSpawnCount = _prefabsForSpawn.Length;
        for (int i = 0; i < prefabsForSpawnCount; i++)
        {
            for (int j = 0; j < _countOfEachPrefabInPool; j++)
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
            SubscribeScoreManagerOnThisFlower(prefab);
        }
        else if (prefab.GetComponent<Cactus>() != null)
        {
            SubscribeHealthManagerOnThisCactus(prefab);
        }
    }

    private void SubscribeHealthManagerOnThisCactus(GameObject prefab)
    {
        prefab.GetComponent<Cactus>().HarmPlayer += _healthManager.TakeDamage;
    }

    private void SubscribeScoreManagerOnThisFlower(GameObject prefab)
    {
        prefab.GetComponent<Flower>().IncreaseScore += _scoreManager.AddScorePoint;
    }
}
