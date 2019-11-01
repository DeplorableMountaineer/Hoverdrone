using System.Collections.Generic;
using GameState;
using UnityEngine;

public class Game : MonoBehaviour {
    [SerializeField] private IState state = null;

    private Dictionary<string, IState> states = new Dictionary<string, IState>();

    // Start is called before the first frame update
    void Start() {
        states["Title"] = new TitleState();
        states["Play"] = new PlayState();
        states["NewGame"] = new NewGameState();
        states["Pause"] = new PauseState();
        TransitionState("Title");
    }

    // Update is called once per frame
    void Update() {
        if(state != null) {
            state.Update();
        }
    }

    public void TransitionState(string newState) {
        TransitionState(states[newState]);
    }

    public void TransitionState(IState newState) {
        if(state != null) {
            state.Exit();
        }

        state = newState;
        state.Enter();
    }
}
