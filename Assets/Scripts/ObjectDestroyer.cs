using System;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public event Action<GameObject> ReturningIntoPoolEvent;

    private void OnTriggerEnter2D(Collider2D other)
   {
       if(other.gameObject.GetComponent<Cactus>() != null || 
          other.gameObject.GetComponent<Flower>() != null)
           ReturningIntoPoolEvent?.Invoke(other.gameObject);
   }
}
