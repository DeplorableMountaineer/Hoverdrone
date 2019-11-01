using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour {
    private void Awake() {
        if(PlayerPrefs.HasKey("Volume")) {
            AudioListener.volume = PlayerPrefs.GetFloat("Volume");
        }
        else {
            AudioListener.volume = .5f;
        }

        GetComponent<Slider>().SetValueWithoutNotify(AudioListener.volume);
    }

    public void SetVolume() {
        AudioListener.volume = GetComponent<Slider>().value;
        PlayerPrefs.SetFloat("Volume", AudioListener.volume);
    }
}
