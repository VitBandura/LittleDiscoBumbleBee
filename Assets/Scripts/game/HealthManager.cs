using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public event Action OnPlayerDead;
    
    [SerializeField] private Canvas _healthBar;

    private Image[] _honeyHearts;
    private int _health;

    private void Awake()
    {
        _honeyHearts = _healthBar.GetComponentsInChildren<Image>();
        RefreshHealth();
    }

    public void TakeDamage()
    {
        _honeyHearts[_health].gameObject.SetActive(false);
        _health--;
        if (_health >= 0) return;
        OnPlayerDead?.Invoke();
    }

    private void RefreshHealth()
    {
        _health = 2;
        foreach (var honeyHeart in _honeyHearts)
        {
            honeyHeart.gameObject.SetActive(true);
        }
    }
}
