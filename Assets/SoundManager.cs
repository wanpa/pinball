using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : SingletonMonoBehaviour<SoundManager> {
	public AudioClip BGM;
	public AudioClip Tap;
	public AudioClip Clear;
	public AudioClip GameOver;

	public Dictionary<string, AudioSource> m_audioDic;

	// Use this for initialization
	public void Awake () {
		if (this != Instance) {
			Destroy (this);
			Destroy (this.gameObject);
			return;
		}
		DontDestroyOnLoad (this.gameObject);

		m_audioDic = new Dictionary<string, AudioSource> ();
		AddDictionary (BGM, "audioClip1");
		AddDictionary (Tap, "audioClip1");
		AddDictionary (Clear, "audioClip1");
		AddDictionary (GameOver, "audioClip1");
	}

	public void AddDictionary(AudioClip clip, string key) {
		AudioSource source = gameObject.AddComponent<AudioSource>();
		source.clip = clip;
		m_audioDic.Add (key, source);
	}

	///////////////////////////////////////////////////////////////////////////////
	/// play method

	public void Play(string audioName, bool loop = false, bool fadeIn = false, float volume = 1f) {
		m_audioDic [audioName].loop = loop;
		m_audioDic [audioName].volume = volume;
		m_audioDic [audioName].Play ();
		if (fadeIn) {
			m_audioDic [audioName].volume = 0;
			StartCoroutine(VolumeFadeIn(audioName));
		}
	}

	public void Stop(string audioName, bool fadeOut = false) {
		if (fadeOut) {
			StartCoroutine(VolumeFadeOut(audioName, true));
		} else {
			m_audioDic [audioName].Stop ();
		}
	}

	public void FadeIn(string audioName) {
		m_audioDic [audioName].volume = 0;
		StartCoroutine(VolumeFadeIn(audioName));
	}

	public void FadeOut(string audioName) {
		StartCoroutine(VolumeFadeOut(audioName, false));
	}

	public IEnumerator VolumeFadeIn(string audioName){
		while(m_audioDic[audioName].volume < 1f) {
			m_audioDic[audioName].volume += Time.deltaTime * 0.5f;
			yield return null;
		}
	}

	public IEnumerator VolumeFadeOut(string audioName, bool isStop){
		while(m_audioDic[audioName].volume > 0f) {
			m_audioDic[audioName].volume -= Time.deltaTime * 0.5f;
			yield return null;
		}
		if (isStop) {
			m_audioDic [audioName].Stop ();
		}
	}

}