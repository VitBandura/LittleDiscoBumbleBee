using System.Collections.Generic;
using UnityEngine;

public class FlowerPool : MonoBehaviour
{
    [SerializeField] private GameObject _flower;
    [SerializeField] private float _poolSize;
    [SerializeField] private ScoreManager _scoreManager;

    private Queue<GameObject> _flowerPool;
    
    private void Start()
    {
        InitializeFlowerPool();
    }
    
    private void InitializeFlowerPool()
    {
        _flowerPool = new Queue<GameObject>();
        IncreasePoolSize();
    }
    
    public GameObject TakeFlowerFromPool()
    {
        if (_flowerPool.Count < 1)
        {
            IncreasePoolSize();
        }
        return _flowerPool.Dequeue();
    }
    
    private void IncreasePoolSize()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            var flower = Instantiate(_flower);
            flower.GetComponent<Flower>().IncreaseScore += _scoreManager.AddScorePoint;
            flower.SetActive(false);
            _flowerPool.Enqueue(flower);
        }
    }
}
