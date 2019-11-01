using UnityEngine;

public class Drone : MonoBehaviour {
    [SerializeField] private float gravity = 20f;
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        _rb.gravityScale = Input.GetButton("Jump") ? -gravity : gravity;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Die();
    }

    private void Die() {
        FindObjectOfType<ScoreTrigger>().Stop();
        foreach(Pipe p in FindObjectsOfType<Pipe>()) {
            p.GetComponent<Rigidbody2D>().simulated = false;
        }

        FindObjectOfType<PipeSpawner>().StopSpawning();
        Object.FindObjectOfType<Game>().TransitionState("Title");
    }
}
