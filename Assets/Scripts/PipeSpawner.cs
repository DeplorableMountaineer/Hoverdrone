using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour {
    [SerializeField] private float minSeconds = 2;
    [SerializeField] private float maxSeconds = 3;

    [SerializeField] private float minMidpoint = -384;
    [SerializeField] private float maxMidpoint = 384;

    [SerializeField] private float minHalfGap = 50;
    [SerializeField] private float maxHalfGap = 150;
    [SerializeField] private float pipeHalfHeight = 192;

    [SerializeField] private GameObject pipePrefab;

    [SerializeField] private bool spawning = true;

    // Start is called before the first frame update
    void Start() {
        Random.InitState((int)System.DateTime.Now.Ticks);
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
            float halfGap = Random.Range(minHalfGap, maxHalfGap);
            float midpoint = Random.Range(minMidpoint + halfGap, maxMidpoint - halfGap);
            Vector3 pos = new Vector3(transform.position.x, midpoint - halfGap - pipeHalfHeight, transform.position.z);
            Vector3 pos2 = new Vector3(transform.position.x, midpoint + halfGap + pipeHalfHeight, transform.position.z);

            if(spawning) {
                Instantiate(pipePrefab, pos, Quaternion.identity);
                Instantiate(pipePrefab, pos2, Quaternion.Euler(0, 0, 180));
            }
        } while(spawning);
    }
}
