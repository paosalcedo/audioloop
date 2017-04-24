using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopScript : MonoBehaviour {
	[SerializeField]AudioClip attack;
	[SerializeField]AudioClip sustain;
	[SerializeField]AudioClip release;
//	[SerializeField]AudioClip attackOnly;
//	[SerializeField]AudioClip releaseOnly;

	AudioSource source; 

	// Use this for initialization
	void Start () {
		Debug.Log ("attack samples: " + attack.samples);
		Debug.Log ("sustain samples: " + sustain.samples);
		Debug.Log ("release samples:" + release.samples);
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			
		}
	}
}
