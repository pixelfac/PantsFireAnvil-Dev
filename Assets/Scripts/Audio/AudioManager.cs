using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : Singleton<AudioManager>
{
	public Sound[] sounds;

	private bool sfxBuffer = false, musicBuffer = false;

	private Image sfxImage, musicImage;

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

		RestartBGM();
	}

	private void Start()
	{
		Play("BGM1");
	}

	private void RestartBGM()
	{
		Debug.Log("restarting bgm");
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


	public void ToggleMusic(bool val)
	{
		//I need to get the image, but only when the button is on screen
		//this bit of code runs only once on the first func call
		if (!musicBuffer)
		{
			musicImage = GameObject.Find("Music_Button").GetComponent<Image>();
			musicBuffer = true;
		}

		if (val)
		{
			musicImage.color = new Color(0.5f, 0.5f, 0.5f);

			if (GetSource("BGM1").isPlaying)
				GetSource("BGM1").Pause();

			GetSource("Victory").volume = 0f;
			GetSource("Defeat").volume = 0f;
		}
		else
		{
			musicImage.color = new Color(1f,1f,1f);
			GetSource("BGM1").UnPause();
			GetSource("Victory").volume = 1f;
			GetSource("Defeat").volume = 1f;
		}
	}

	public void ToggleSFX(bool val)
	{
		//I need to get the image, but only when the button is on screen
		//this bit of code runs only once on the first func call
		if (!sfxBuffer)
		{
			sfxImage = GameObject.Find("SFX_Button").GetComponent<Image>();
			sfxBuffer = true;
		}

		if (val)
		{
			sfxImage.color = new Color(0.5f, 0.5f, 0.5f);
			GetSource("Impact").volume = 0f;
		}
		else
		{
			sfxImage.color = new Color(1f,1f,1f);
			GetSource("Impact").volume = 1f;
		}
	}

}
