using System;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour {
    private int _score;
    private int _highScore;
    private TMP_Text _scoreText;
    private TMP_Text _highScoreText;

    private void Start() {
        if(PlayerPrefs.HasKey("High Score")) {
            _highScore = PlayerPrefs.GetInt("High Score");
        }
        else {
            _highScore = 0;
        }

        _scoreText = GetComponent<TMP_Text>();
        foreach(TMP_Text t in FindObjectsOfType<TMP_Text>()) {
            if(t.CompareTag("High Score")) {
                _highScoreText = t;
                break;
            }
        }

        ResetScore();
    }

    public int GetScore() {
        return _score;
    }

    public void IncrementScore(int amount = 1) {
        _score += amount;
        UpdateScore();
        if(_score > _highScore) {
            UpdateHighScore();
        }
    }

    public void ResetScore() {
        _score = 0;
        UpdateScore();
        UpdateHighScore();
    }

    private void UpdateScore() {
        _scoreText.text = _score.ToString();
    }

    private void UpdateHighScore() {
        if(_score > _highScore) {
            _highScore = _score;
        }

        _highScoreText.text = _highScore.ToString();
    }

    private void OnApplicationQuit() {
        PlayerPrefs.SetInt("High Score", _highScore);
    }
}
