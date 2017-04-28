using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseScript : MonoBehaviour {

	[SerializeField]AudioClip release;
	private AudioSource releaseSource;
	private AudioSource attackSource;
	private AudioSource sustainSource;
	private double playReleaseHere;
	double positionOnSustainClip;
	double sustainSamples;
	double sampleRate;
	double dspSamples;
	double attackSamples;
	double attackLength;
	double positionOnAttackClip;
	double timeWhenAttackWasPlayed;
	double timeAtKeyUp;
	double sustainLength;
	double timesSustainHasLooped;
	double sustainLoopSamples;

	// Use this for initialization
	void Start () {
		sampleRate = AudioSettings.outputSampleRate;
		releaseSource = GetComponent<AudioSource> ();
		releaseSource.clip = release;
		attackSource = GameObject.Find ("Attack").GetComponent<AudioSource> ();
		sustainSource = GameObject.Find ("Sustain").GetComponent <AudioSource> ();
		sustainSamples = GameObject.Find ("Sustain").GetComponent<AudioSource> ().clip.samples;
		attackSamples = GameObject.Find ("Attack").GetComponent<AudioSource> ().clip.samples;
//		attackTime = 2.546734694f;
		attackLength = attackSource.clip.samples / sampleRate;
		sustainLength = sustainSource.clip.samples / sampleRate;

 	}
	
	// Update is called once per frame
	void Update () {

		print ("attack length = " + attackLength);
//		Debug.Log
//			((timeWhenAttackWasPlayed + attackLength - timeAtKeyUp) //the time sustain was played
//				* sampleRate /
//				sustainSamples);
//

		timesSustainHasLooped = ((AttackScript.instance.attackTime + attackLength + sustainLength) * sampleRate)/ sustainSamples;

 		dspSamples = AudioSettings.dspTime * sampleRate;
		positionOnSustainClip = sustainSource.timeSamples;
		positionOnAttackClip = attackSource.timeSamples;
	
//		timesSustainHasLooped = ((AttackScript.instance.attackTime + attackLength) / sustainLength;
 //		Debug.Log ("position on sustain clip: " + positionOnSustainClip);

	 
		if (Input.GetKeyUp (KeyCode.Space)) {
			PlayRelease ();
   		}

 
	}

	void PlayRelease(){
//		Debug.Log("Playing in " + ((sustainSamples - positionOnSustainClip)/sampleRate) + " seconds");
		//TimeWhenYouPlayedAttack + LengthOfAttack + (LengthOfSustain * TimesSustainHasLooped)


//		releaseSource.PlayScheduled (
//						AttackScript.instance.attackTime + 
//			 			attackLength + //+ length of attack
//						(sustainLength * 
//						timesSustainHasLooped)
//						//times sustain has looped.
							//time
//					);
//		releaseSource.PlayScheduled (
//			AttackScript.instance.attackTime + 
// 			attackLength + //+ length of attack
//			sustainLength
////			(sustainLength * ((sustainSamples-positionOnSustainClip)/sustainSamples))
//			//times sustain has looped.
//				//time
//		);
//
		

//		releaseSource.PlayScheduled (AudioSettings.dspTime 
//			+ (attackSamples / sampleRate) //length in seconds of attack clip 
//			+ ((attackSamples - positionOnAttackClip)/sampleRate) // length in seconds until attack clip completes? 
//			- (sustainSamples / sampleRate) // length in seconds of sustain loop
//			+ ((sustainSamples - positionOnSustainClip)/sampleRate)); //length in seconds until sustain loop completes
		

//		releaseSource.PlayScheduled (AudioSettings.dspTime 
//									+ (attackSamples/sampleRate) //length in seconds of attack clip 
//									- (sustainSamples / sampleRate) // length in seconds of sustain loop
//									+ ((sustainSamples - positionOnSustainClip)/sampleRate)); //length in seconds until sustain loop completes
//

		releaseSource.PlayScheduled (AudioSettings.dspTime + 
									attackLength + sustainLength + 
									((sustainSamples - positionOnSustainClip)/sampleRate));
		
//		FOR REFERENCE 
//		releaseSource.PlayScheduled (AudioSettings.dspTime 
//									+ 2.546734694f // length of attack in seconds
//									+ 2.4f); 		// length of sustain in seconds
	}
}
