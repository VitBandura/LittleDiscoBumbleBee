using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameOverScene : MonoBehaviour
{
   [SerializeField] private HealthManager _healthManager;

   private void Awake()
   {
      _healthManager.OnPlayerDead += MoveToGameOverScene;
   }

   private void MoveToGameOverScene()
   {
      SceneManager.LoadScene(2);
   }
}
