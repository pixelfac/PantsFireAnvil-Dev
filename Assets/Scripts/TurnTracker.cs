using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnTracker : MonoBehaviour
{
	static Controller[] controllers = new Controller[6];

	static Image[] images = new Image[6];

	static RectTransform arrow;

	private void Awake()
	{
		controllers[0] = GameObject.Find("Pants").GetComponent<Controller>();
		controllers[1] = GameObject.Find("PantsAI").GetComponent<Controller>();
		controllers[2] = GameObject.Find("Fire").GetComponent<Controller>();
		controllers[3] = GameObject.Find("FireAI").GetComponent<Controller>();
		controllers[4] = GameObject.Find("Anvil").GetComponent<Controller>();
		controllers[5] = GameObject.Find("AnvilAI").GetComponent<Controller>();

		images[0] = GameObject.Find("PantsImage").GetComponent<Image>();
		images[1] = GameObject.Find("PantsAIImage").GetComponent<Image>();
		images[2] = GameObject.Find("FireImage").GetComponent<Image>();
		images[3] = GameObject.Find("FireAIImage").GetComponent<Image>();
		images[4] = GameObject.Find("AnvilImage").GetComponent<Image>();
		images[5] = GameObject.Find("AnvilAIImage").GetComponent<Image>();

		arrow = GameObject.Find("arrow").GetComponent<RectTransform>();
	}

	public static void UpdateTurnTracker(GameState state)
	{
		for (int i=0; i< controllers.Length; i++)
		{
			if (!controllers[i].alive)
				images[i].color = KillImage(images[i].color);
		}
		if ((int)state < 6)
			arrow.position = new Vector3(arrow.position.x, images[(int)state].gameObject.GetComponent<RectTransform>().position.y, arrow.position.z);
	}

	public static Color KillImage(Color color)
	{
		return new Color(color.r, color.g, color.b, 0.4f);
	}

}
