using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    [SerializeField] private ObjectPool _objectPool;
    
    private void OnTriggerEnter2D(Collider2D other)
   {
     _objectPool.ReturnUsedObjectIntoPool(other.gameObject);
   }
}
