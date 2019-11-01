using UnityEngine;

namespace GameState {
    class NewGameState : IState {
        public void Enter() {
            Object.FindObjectOfType<PipeSpawner>().NewGame();
            Object.FindObjectOfType<Drone>().GetComponent<Rigidbody2D>().simulated = true;
            foreach(Pipe p in Object.FindObjectsOfType<Pipe>()) {
                p.GetComponent<Rigidbody2D>().simulated = true;
            }

            Object.FindObjectOfType<PipeSpawner>().ResumeSpawning();
            Object.FindObjectOfType<Game>().TransitionState("Play");
        }

        public void Exit() {
        }

        public void Update() {
        }
    }
}
