using UnityEngine;

public class ScoreTrigger : MonoBehaviour {
    private Score _score;

    // Start is called before the first frame update
    void Start() {
        _score = FindObjectOfType<Score>();
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Pipe")) {
            _score.IncrementScore();
        }
    }
}
