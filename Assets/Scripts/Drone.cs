using UnityEngine;

public class Drone : MonoBehaviour {
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private float gravity = 20f;
    private Rigidbody2D _rb;
    private bool isLifting = false;
    private AudioSource droneSound;

    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody2D>();
        droneSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        bool newIsLifting = Input.GetButton("Jump");
        _rb.gravityScale = newIsLifting ? -gravity : gravity;
        if(newIsLifting != isLifting) {
            if(newIsLifting) {
                droneSound.Play();
            }
            else {
                droneSound.Stop();
            }

            isLifting = newIsLifting;
        }

        if(isLifting) {
            droneSound.volume = .25f;
        }
    }

    public void MuteDroneSound() {
        droneSound.volume = 0;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Die();
    }

    private void Die() {
        droneSound.Stop();
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position);
        FindObjectOfType<ScoreTrigger>().Stop();
        foreach(Pipe p in FindObjectsOfType<Pipe>()) {
            p.GetComponent<Rigidbody2D>().simulated = false;
        }

        FindObjectOfType<PipeSpawner>().StopSpawning();
        Object.FindObjectOfType<Game>().TransitionState("Title");
    }
}
