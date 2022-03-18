using UnityEngine;

public class ScreenSlider : MonoBehaviour
{
   [SerializeField] private Canvas _mainMenuScreen;
   [SerializeField] private Canvas _rulesScreen;
   
   private void Awake()
   {
      SwitchToMainMenuScreen();
   }

   public void SwitchToMainMenuScreen()
   {
      _mainMenuScreen.gameObject.SetActive(true);
      _rulesScreen.gameObject.SetActive(false);
   }

   public void SwitchToRulesScreen()
   {
      _rulesScreen.gameObject.SetActive(true);
      _mainMenuScreen.gameObject.SetActive(false);
   }
}
