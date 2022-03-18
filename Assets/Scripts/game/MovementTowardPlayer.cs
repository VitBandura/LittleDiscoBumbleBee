using UnityEngine;

public class MovementTowardPlayer : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    
    private void Update()
    {
        MoveTowardsPlayer();
    }
    
    private void MoveTowardsPlayer()
    {
        var step = _movementSpeed * Time.deltaTime;
        transform.Translate(Vector3.left * step);
    }
}
