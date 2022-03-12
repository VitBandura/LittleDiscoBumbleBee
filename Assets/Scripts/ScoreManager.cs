using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreUI;
    private float _score;
    private void Awake()
    {
        RefreshScore();
    }
    private void RefreshScore()
    {
        _score = 0;
        _scoreUI.text = _score.ToString();
    }
    public void AddScorePoint()
    {
        _score++;
        _scoreUI.text = _score.ToString();
    }
}
