using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreUI;
   
    public float score { get; private set; }

    private void Awake()
    {
        RefreshScore();
    }
    
    private void RefreshScore()
    {
        score = 0;
        _scoreUI.text = score.ToString();
    }
    
    public void AddScorePoint()
    {
        score++;
        _scoreUI.text = score.ToString();
    }
}
