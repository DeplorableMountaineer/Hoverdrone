using UnityEngine;

namespace GameState {
    class PlayState : IState {
        public void Enter() {
            Object.FindObjectOfType<Drone>().GetComponent<Rigidbody2D>().simulated = true;
            Object.FindObjectOfType<PipeSpawner>().NewGame();
        }

        public void Exit() {
        }

        public void Update() {
        }
    }
}
