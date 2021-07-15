using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : Singleton<AudioManager>
{
	public Sound[] sounds;

	private bool sfxBuffer = true, musicBuffer = true;

	protected override void Awake()
	{
		base.Awake();

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.loop = s.loop;
		}
	}

	private void Start()
	{
		Play("BGM1");
		SceneManager.sceneLoaded += RestartBGM;
	}

	private void RestartBGM(Scene scene, LoadSceneMode mode)
	{
		if (!GetSource("BGM1").isPlaying)
			Play("BGM1");
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


	public void ToggleMusic(bool val)
	{
		//the toggle event calls this function on enable for some reason
		//so audiomanager isn't set up yet. That is why this buffer is needed to avoid NullReferenceExection
		if (musicBuffer)
		{
			musicBuffer = false;
			return;
		}

		if (val)
		{
			if (GetSource("BGM1").isPlaying)
				GetSource("BGM1").Pause();

			GetSource("Victory").volume = 0f;
			GetSource("Defeat").volume = 0f;
		}
		else
		{
			GetSource("BGM1").UnPause();
			GetSource("Victory").volume = 1f;
			GetSource("Defeat").volume = 1f;
		}
	}

	public void ToggleSFX(bool val)
	{
		//the toggle event calls this function on enable for some reason
		//so audiomanager isn't set up yet. That is why this buffer is needed to avoid NullReferenceExection
		if (sfxBuffer)
		{
			sfxBuffer = false;
			return;
		}

		if (val)
		{
			GetSource("Impact").volume = 0f;
		}
		else
		{
			GetSource("Impact").volume = 1f;
		}
	}

}
