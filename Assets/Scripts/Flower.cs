using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
  public event Action IncreaseScore;

  private void OnTriggerEnter2D(Collider2D other)
  {
    if(other.gameObject.GetComponent(typeof(Player)) != null)
    {
      IncreaseScore?.Invoke();
    }
  }
}
