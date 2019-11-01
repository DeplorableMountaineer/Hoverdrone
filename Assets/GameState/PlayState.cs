using UnityEngine;

namespace GameState {
    class PlayState : IState {
        public void Enter() {
          
        }

        public void Exit() {
        }

        public void Update() {
            if(Input.GetButtonDown("Cancel")) {
                Object.FindObjectOfType<Game>().TransitionState("Pause");
            }
        }
    }
}
