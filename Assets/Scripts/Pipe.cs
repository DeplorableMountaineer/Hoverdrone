using UnityEngine;

public class Pipe : MonoBehaviour {
    [SerializeField] private Vector2 moveVelocity = 48f*0.0625f*Vector2.left;

    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = moveVelocity;
    }
}
