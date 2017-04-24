using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseScript : MonoBehaviour {

	[SerializeField]AudioClip release;
	AudioSource releaseSource;
	private double playReleaseHere;
	double positionOnSustainClip;
	double sustainSamples;
	double sampleRate;
	double dspSamples;
	double attackSamples;
	double attackTime;
	double positionOnAttackClip;

	// Use this for initialization
	void Start () {
		sampleRate = AudioSettings.outputSampleRate;
		releaseSource = GetComponent<AudioSource> ();
		releaseSource.clip = release;
		sustainSamples = GameObject.Find ("Sustain").GetComponent<AudioSource> ().clip.samples;
		attackSamples = GameObject.Find ("Attack").GetComponent<AudioSource> ().clip.samples;
		attackTime = 2.546734694f;
 	}
	
	// Update is called once per frame
	void Update () {
 		dspSamples = AudioSettings.dspTime * sampleRate;
		positionOnSustainClip = GameObject.Find ("Sustain").GetComponent<AudioSource> ().timeSamples;
		positionOnAttackClip = GameObject.Find ("Attack").GetComponent<AudioSource> ().timeSamples;
		Debug.Log ("position on sustain clip: " + positionOnSustainClip);
		if (Input.GetKey (KeyCode.Space)) {
			PlayRelease ();
//			Debug.Log ("Position on sustain clip: " + (105840 - positionOnSustainClip));
		}
	}

	void PlayRelease(){
//		Debug.Log("Playing in " + ((sustainSamples - positionOnSustainClip)/sampleRate) + " seconds");
		releaseSource.PlayScheduled (AudioSettings.dspTime + 
									2.546734694f +
									((sustainSamples - positionOnSustainClip)/sampleRate));
//
		 

//		FOR REFERENCE 
//		releaseSource.PlayScheduled (AudioSettings.dspTime 
//									+ 2.546734694f // length of attack in seconds
//									+ 2.4f); 		// length of sustain in seconds
	}
}
