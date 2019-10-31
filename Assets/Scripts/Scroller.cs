using UnityEngine;

public class Scroller : MonoBehaviour {
    [SerializeField] private Vector2 scrollVelocity = Vector2.right*0.03125f;

    private Material _material;

    // Start is called before the first frame update
    void Start() {
        _material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update() {
        _material.mainTextureOffset = scrollVelocity*Time.time;
    }
}
