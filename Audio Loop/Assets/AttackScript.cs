using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {

	[SerializeField]AudioClip attack;
	AudioSource attackSource;
	public double attackTime;
	private double playAttackHere;
	private double sampleRate;

	public static AttackScript instance;
	// Use this for initialization

	void Start () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this);
		} else {
			Destroy(gameObject);
		}

		attackSource = GetComponent<AudioSource> ();	
		attackSource.clip = attack;
		sampleRate = AudioSettings.outputSampleRate;
		playAttackHere = 0.0005f;
		attackTime = AudioSettings.dspTime + playAttackHere; 

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
//			attackSource.PlayScheduled (AudioSettings.dspTime + playAttackHere);
			attackSource.PlayScheduled (attackTime);
		}
	}


}
