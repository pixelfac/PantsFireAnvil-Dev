using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public Sound[] sounds;

	protected override void Awake()
	{
		base.Awake();

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
		}
	}

	public void Play(string name)
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
			return;
		}
		
		soundToPlay.Play();

	}

}
