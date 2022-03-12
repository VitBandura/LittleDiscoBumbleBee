using System;
using System.Collections;
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
        _flowerPool = new Queue<GameObject>();
        InitializeFlowerPool();
    }
    private void InitializeFlowerPool()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            var flower = Instantiate(_flower);
            flower.GetComponent<Flower>().IncreaseScore += _scoreManager.AddScorePoint;
            flower.SetActive(false);
            _flowerPool.Enqueue(flower);
        }
    }
    public GameObject TakeFlowerFromPool()
    {
        IncreaseEmptyPoolSize();
        return _flowerPool.Dequeue();
    }
    private void IncreaseEmptyPoolSize()
    {
        if (_flowerPool.Count < 1)
        {
            InitializeFlowerPool();
        }
    }
}
