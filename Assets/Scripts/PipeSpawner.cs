using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour {
    [SerializeField] private float minSeconds = 2;
    [SerializeField] private float maxSeconds = 3;

    [SerializeField] private float minY = -383;
    [SerializeField] private float maxY = -27;

    [SerializeField] private GameObject pipePrefab;

    [SerializeField] private bool spawning = true;

    // Start is called before the first frame update
    void Start() {
        if(spawning) {
            StartSpawning();
        }
    }

    public void StartSpawning() {
        spawning = true;
        StartCoroutine(Spawn());
    }

    public void StopSpawning() {
        spawning = false;
    }

    private IEnumerator Spawn() {
        do {
            yield return new WaitForSeconds(Random.Range(minSeconds, maxSeconds));
            float y = Random.Range(minY, maxY);
            Vector3 pos = new Vector3(transform.position.x, y, transform.position.z);
            if(spawning) {
                Instantiate(pipePrefab, pos, Quaternion.identity);
            }
        } while(spawning);
    }
}
 