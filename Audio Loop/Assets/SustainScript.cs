using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SustainScript : MonoBehaviour {
	[SerializeField]AudioClip sustain;
 
	public AudioSource sustainSource;
	private double playSustainHere;

	// Use this for initialization
	void Start () {
		playSustainHere = 2.546734694f; //length of attack audio clip in seconds.
		sustainSource = GetComponent<AudioSource> ();
		sustainSource.clip = sustain;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			PlaySustain ();
			sustainSource.loop = true;
		} else {
			sustainSource.loop = false;
		}
	}

	void PlaySustain(){
		if (!sustainSource.isPlaying) {
			sustainSource.PlayScheduled (AudioSettings.dspTime + playSustainHere);

		}
	}

}
