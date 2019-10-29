using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {
    [SerializeField] private Vector2 moveVelocity = Vector2.left*0.0625f*48f;
    [SerializeField] private float maxY = -27;
    [SerializeField] private float minY = -383;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = moveVelocity;
    }
}
