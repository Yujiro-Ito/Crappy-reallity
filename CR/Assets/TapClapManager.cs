using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

[RequireComponent(typeof(AudioSource))]
public class TapClapManager : MonoBehaviour, IInputClickHandler {
    public AudioSource audio;
    public float delay;
    public void OnInputClicked(InputClickedEventData eventData)
    {
        Debug.Log("AirTap");
        //audio.Play();
        audio.PlayDelayed(delay);
        //audio.loop = !audio.loop;
    }

    // Use this for initialization
    void Start () {
        AudioSource audio = GetComponent<AudioSource>();
        InputManager.Instance.PushFallbackInputHandler(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
