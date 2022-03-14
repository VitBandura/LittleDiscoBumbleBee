using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField] private float _movementSpeed;
   [SerializeField] private float _verticalOffset;
   [SerializeField] private float _maxHeight;
   [SerializeField] private float _minHeight;
   
   private Vector3 _targetPosition;
   private readonly Vector3 _startPosition = new(-20, 0);
   
   private void Start()
   {
      InitializePlayerStartPosition();
   }

   private void Update()
   { 
      MoveToTargetPosition();
      UpdateTargetPosition();
   }
   
   private void InitializePlayerStartPosition()
   {
      transform.position = _startPosition;
      _targetPosition = _startPosition;
   }

   private void MoveToTargetPosition()
   {
      var step = _movementSpeed * Time.deltaTime;
      transform.position = Vector3.MoveTowards(transform.position, _targetPosition, step);
   }

   private void UpdateTargetPosition()
   {
      if (Input.GetKeyDown(KeyCode.W) && _targetPosition.y < _maxHeight)
      {
         _targetPosition = new Vector3(_targetPosition.x, _targetPosition.y + _verticalOffset);
      }
      else if (Input.GetKeyDown(KeyCode.S) && _targetPosition.y > _minHeight)
      {
         _targetPosition = new Vector3(_targetPosition.x, _targetPosition.y - _verticalOffset);
      }
   }
}
