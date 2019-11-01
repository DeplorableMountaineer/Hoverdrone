﻿using UnityEngine;

public class ScoreTrigger : MonoBehaviour {
    [SerializeField] private float speedupRate = 1.014f;

    private Score _score;
    private bool _active = true;

    // Start is called before the first frame update
    void Start() {
        _score = FindObjectOfType<Score>();
        Resume();
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(_active && other.CompareTag("Pipe")) {
            _score.IncrementScore();
            Time.timeScale *= speedupRate;
        }
    }

    public void Stop() {
        _active = false;
    }

    public void Resume() {
        _active = true;
    }
}
