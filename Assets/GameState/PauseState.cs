﻿using TMPro;
using UnityEngine;

namespace GameState {
    class PauseState : IState {
        private float oldTimeScale;

        public void Enter() {
            oldTimeScale = Time.timeScale;
            Time.timeScale = 0;
            foreach(GameObject go in GameObject.FindGameObjectsWithTag("Title")) {
                go.GetComponent<TMP_Text>().enabled = true;
            }

            Object.FindObjectOfType<Drone>().MuteDroneSound();
        }

        public void Exit() {
            Time.timeScale = oldTimeScale;
            foreach(GameObject go in GameObject.FindGameObjectsWithTag("Title")) {
                go.GetComponent<TMP_Text>().enabled = false;
            }
        }

        public void Update() {
            if(Input.GetButtonDown("Jump") || Input.GetButtonDown("Cancel")) {
                Object.FindObjectOfType<Game>().TransitionState("Play");
            }
        }
    }
}
