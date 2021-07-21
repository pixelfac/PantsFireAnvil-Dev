using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : Singleton<AudioManager>
{
	public Sound[] sounds;

	private void Start()
	{
		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.loop = s.loop;
		}

		Play("BGM1");
		SceneManager.sceneLoaded += RestartBGM;
	}

	private void RestartBGM(Scene scene, LoadSceneMode mode)
	{
		Debug.Log("restarting bgm");

		if (GetSource("Victory").isPlaying)
		{
			Stop("Victory");
		}

		if (GetSource("Defeat").isPlaying)
		{
			Stop("Defeat");
		}

		if (!(GetSource("BGM1").isPlaying))
		{
			Play("BGM1");
		}
	}


	public AudioSource GetSource(string name)
	{
		AudioSource soundToPlay = null;
		foreach (Sound s in sounds)
		{
			if (s.name == name)
			{
				soundToPlay = s.source;
				break;
			}
		}
		if (soundToPlay == null)
		{
			Debug.LogWarning("Sound \"" + name + "\" not found!");
		}

		return soundToPlay;
	}

	public void Play(string name)
	{
		GetSource(name).Play();
	}

	public void Stop(string name)
	{
		GetSource(name).Stop();
	}
}
