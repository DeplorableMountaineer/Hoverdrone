using System.Collections;
using UnityEngine;

public class PipeSpawner : MonoBehaviour {
    [SerializeField] private float minSeconds = 2;
    [SerializeField] private float maxSeconds = 3;

    [SerializeField] private float minMidpoint = -384;
    [SerializeField] private float maxMidpoint = 384;
    [SerializeField] private float maxHeightDiffMult = 100;
    [SerializeField] private float minHalfGap = 50;
    [SerializeField] private float maxHalfGap = 150;
    [SerializeField] private float pipeHalfHeight = 192;

    [SerializeField] private GameObject pipePrefab;

    [SerializeField] private bool spawning = true;

    private float _lastMidpoint = 0;

    // Start is called before the first frame update
    void Start() {
        NewGame();
    }

    public void NewGame() {
        StopAllCoroutines();
        foreach(Pipe pipe in FindObjectsOfType<Pipe>()) {
            Destroy(pipe.gameObject);
        }

        FindObjectOfType<Score>().ResetScore();
        Drone d = FindObjectOfType<Drone>();
        d.transform.position = Vector3.left*151.7f;
        d.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Random.InitState(42);
        if(spawning) {
            StartSpawning();
        }
    }

    public void StartSpawning() {
        spawning = true;
        FindObjectOfType<ScoreTrigger>().Resume();
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn() {
        do {
            float time = Random.Range(minSeconds, maxSeconds);
            yield return new WaitForSeconds(time);
            float halfGap = Random.Range(minHalfGap, maxHalfGap);
            float midpoint = Random.Range(Mathf.Max(minMidpoint + halfGap, _lastMidpoint - time*maxHeightDiffMult),
                Mathf.Min(maxMidpoint - halfGap, _lastMidpoint + time*maxHeightDiffMult));
            Vector3 pos = new Vector3(transform.position.x, midpoint - halfGap - pipeHalfHeight, transform.position.z);
            Vector3 pos2 = new Vector3(transform.position.x, midpoint + halfGap + pipeHalfHeight, transform.position.z);

            if(spawning) {
                Instantiate(pipePrefab, pos, Quaternion.identity);
                var p = Instantiate(pipePrefab, pos2, Quaternion.identity);
                p.transform.localScale = new Vector3(p.transform.localScale.x, -p.transform.localScale.y,
                    p.transform.localScale.z);
                p.tag = "Pipe";
                _lastMidpoint = midpoint;
            }
        } while(spawning);
    }
}
