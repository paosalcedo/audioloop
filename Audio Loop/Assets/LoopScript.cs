using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopScript : MonoBehaviour {

	double delay = 0.00001f;
	public AudioClip[] clips;
	private AudioSource[] sources;
	int loops = 1;
	double lastTime;	
	bool nowInSustain;
	double attackStartTime;

	// Use this for initialization
	void Start ()
	{
		lastTime = -1;

		sources = new AudioSource[3];
		
		for (int i = 0; i < 3; i++) {
			sources[i] = gameObject.AddComponent<AudioSource>();
			
			sources[i].clip = clips[i];
			print("Clip" + i + " : " + clips[i].length);
		}

		sources[0].loop = false;
		sources[1].loop = true;
		sources[2].loop = false;

		sources[0].playOnAwake = false;
		sources[1].playOnAwake = false;
		sources[2].playOnAwake = false;
 	
//		sources[0].PlayScheduled(AudioSettings.dspTime);
//		sources[1].PlayScheduled(AudioSettings.dspTime + sources[0].clip.length);
//		sources[2].PlayScheduled(AudioSettings.dspTime + sources[0].clip.length + sources[1].clip.length);
//		sources[2].SetScheduledStartTime(AudioSettings.dspTime + sources[0].clip.length + sources[1].clip.length);

	}
	
	// Update is called once per frame
	void Update ()
	{
//		print("_____");
//		print(sources[1].time);
		
		int myInt = 0;
		for (int i = 0; i < 1000000; i++) {
			myInt += i;
		}
//		print(sources[1].timeSamples);

		if (Input.GetKeyDown (KeyCode.Space)) {
			attackStartTime = AudioSettings.dspTime + delay;
//			double sustainStartTime = attackStartTime + sources [0].clip.length;
			nowInSustain = true;
			sources [0].PlayScheduled (attackStartTime);
			sources [1].PlayScheduled (attackStartTime + sources [0].clip.length);
			print("aStart: " + attackStartTime);
			print("sStart: " + (attackStartTime + sources [0].clip.length));
			sources [1].loop = true; 

		} 

		if (Input.GetKeyUp (KeyCode.Space)) {
//			double timeNow = AudioSettings.dspTime;

			sources [1].loop = false;
 
//		LOOP COUNT METHOD
			sources[2].PlayScheduled(attackStartTime + sources[0].clip.length + (sources[1].clip.length * loops));

//			print("Sustain position in samples: " + sources[1].timeSamples);

//		SAMPLE COUNT ATTEMPT

//
//			if (sources [0].isPlaying) {
//				sources [2].PlayScheduled (timeNow +
//				((sources [0].clip.samples - sources [0].timeSamples)/AudioSettings.outputSampleRate) +
//				sources [1].clip.length);
//			}
//
//			print("Time left in Attack: " + (sources[0].clip.samples - sources[0].timeSamples));
//
//			if (sources [1].isPlaying) {
//				sources [2].PlayScheduled (	timeNow + 
//											((sources [1].clip.samples - sources[1].timeSamples)
//											/AudioSettings.outputSampleRate));
//			}

		
			
//			print("rStartNew: " + (attackStartTime + sources[0].clip.length + (sources[1].clip.length * loops)));
//			print("rStartSample: " + (timeNow + (sources [1].clip.samples - sources [1].timeSamples)/AudioSettings.outputSampleRate)/sources[1].clip.length);
//			print("rStartOld: " + (timeNow + (sources [1].clip.length - sources [1].time)));


//			sources[2](timeNow +
//				(sources [0].clip.length - sources [0].time) +
//				sources [1].clip.length)
			loops = 0;
//			nowInSustain = false;
		}

		if (nowInSustain && lastTime > sources [1].time) {
			loops += 1;
//			print("looped");
		}
	
		lastTime = sources[1].time;
		
//		if (Input.GetKeyDown (KeyCode.Space)) {
//			sources [0].PlayScheduled (attackStartTime);
//			sources [1].PlayScheduled (AudioSettings.dspTime + sources [0].clip.length);
//			sources [1].loop = true;
//		} 
//
//		if (Input.GetKeyUp (KeyCode.Space)) {
//			sources [1].loop = false;
// 
//			if (sources [0].isPlaying) {
//				sources [2].PlayScheduled (AudioSettings.dspTime +
//				(sources [0].clip.length - sources [0].time) +
//				sources [1].clip.length);
//			}
//			if (sources [1].isPlaying) {
//				sources [2].PlayScheduled (AudioSettings.dspTime + (sources [1].clip.length - sources [1].time));
//			}			
//		}

	

	}
}
