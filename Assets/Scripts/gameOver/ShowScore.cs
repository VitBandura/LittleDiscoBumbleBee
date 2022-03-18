using TMPro;
using UnityEngine;

public class ShowScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private ScoreManager _scoreManager;

    private void Awake()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
        _scoreText.text = $"Your score: {_scoreManager.score.ToString()}";
        Destroy(_scoreManager.gameObject);
    }
}
