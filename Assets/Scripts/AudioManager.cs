using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour 
{
	[SerializeField] private Sound[] sounds;	
	void Awake () 
	{
		foreach(Sound s in sounds)
		{
			s.audioSource = gameObject.AddComponent<AudioSource>();
			s.audioSource.clip = s.clip;
			s.audioSource.volume = s.volume;
		}
	}

	public void Play (string name)
	{
		Sound s = Array.Find(sounds, sound => sound.name == name);
		s.audioSource.Play();
	}
}
