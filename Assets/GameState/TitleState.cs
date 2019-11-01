using TMPro;
using UnityEngine;

namespace GameState {
    class TitleState : IState {
        public void Enter() {
            Object.FindObjectOfType<Drone>().GetComponent<Rigidbody2D>().simulated = false;
            foreach(GameObject go in GameObject.FindGameObjectsWithTag("Title")) {
                go.GetComponent<TMP_Text>().enabled = true;
            }
        }

        public void Exit() {
            foreach(GameObject go in GameObject.FindGameObjectsWithTag("Title")) {
                go.GetComponent<TMP_Text>().enabled = false;
            }
        }

        public void Update() {
            if(Input.anyKeyDown) {
                Object.FindObjectOfType<Game>().TransitionState("Play");
            }
        }
    }
}
