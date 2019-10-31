using TMPro;
using UnityEngine;

public class Score : MonoBehaviour {
    private int _score;
    private TMP_Text _scoreText;

    private void Start() {
        _scoreText = GetComponent<TMP_Text>();
        ResetScore();
    }

    public int GetScore() {
        return _score;
    }

    public void IncrementScore(int amount = 1) {
        _score += amount;
        UpdateScore();
    }

    public void ResetScore() {
        _score = 0;
        UpdateScore();
    }

    private void UpdateScore() {
        _scoreText.text = _score.ToString();
    }
}
