using System;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    public event Action HarmPlayer;
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent(typeof(Player)) != null)
        {
           HarmPlayer?.Invoke();
        }
    }
}
