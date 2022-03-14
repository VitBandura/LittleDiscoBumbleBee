using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
   {
     other.gameObject.SetActive(false);
   }
}
