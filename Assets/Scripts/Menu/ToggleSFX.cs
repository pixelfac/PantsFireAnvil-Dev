using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSFX : MonoBehaviour
{
	Image sfxImage;

	public void Start()
	{
		sfxImage = gameObject.GetComponent<Image>();
	}
    public void main(bool val)
	{

		if (val)
		{
			sfxImage.color = new Color(0.5f, 0.5f, 0.5f);
			AudioManager.Instance.GetSource("Impact").volume = 0f;
		}
		else
		{
			sfxImage.color = new Color(1f, 1f, 1f);
			AudioManager.Instance.GetSource("Impact").volume = 1f;
		}
	}
}
