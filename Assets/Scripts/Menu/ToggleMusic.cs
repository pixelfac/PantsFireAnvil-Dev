using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMusic : MonoBehaviour
{
	Image musicImage;

	public void Start()
	{
		musicImage = gameObject.GetComponent<Image>();
	}

	public void main(bool val)
	{
		if (val)
		{
			musicImage.color = new Color(0.5f, 0.5f, 0.5f);

			if (AudioManager.Instance.GetSource("BGM1").isPlaying)
				AudioManager.Instance.GetSource("BGM1").Pause();

			AudioManager.Instance.GetSource("Victory").volume = 0f;
			AudioManager.Instance.GetSource("Defeat").volume = 0f;
		}
		else
		{
			musicImage.color = new Color(1f, 1f, 1f);
			
			AudioManager.Instance.GetSource("BGM1").UnPause();
			AudioManager.Instance.GetSource("Victory").volume = 1f;
			AudioManager.Instance.GetSource("Defeat").volume = 1f;
		}
	}
}
