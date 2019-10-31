using UnityEngine;

public class Shredder : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<Pipe>()) {
            Destroy(other.gameObject);
        }
    }
}
