using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {

	[SerializeField]AudioClip attack;
	AudioSource attackSource;
	private double playAttackHere;
	private double sampleRate;


	// Use this for initialization
	void Start () {
		attackSource = GetComponent<AudioSource> ();	
		attackSource.clip = attack;
		sampleRate = AudioSettings.outputSampleRate;
		playAttackHere = 0.000000000000001f;

	}
	
	// Update is called once per frame
	void Update () {
 		if (Input.GetKeyDown(KeyCode.Space)) {
			PlayAttack ();
		}
//		Debug.Log ("attackSource.timeSamples: " + attackSource.timeSamples);

	}

	void PlayAttack(){
		if (!attackSource.isPlaying) {
			attackSource.PlayScheduled (AudioSettings.dspTime + playAttackHere);
		}
	}


}
