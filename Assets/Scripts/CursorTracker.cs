using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTracker : MonoBehaviour
{
	static bool enabled;

	private void Awake()
	{
		enabled = true;
	}
	// Update is called once per frame
	void Update()
	{
		if (!enabled) return;

		//moves CursorTracker object to follow the cursor while staying locked to the grid
		Vector3 mousePos = new Vector3((int)Input.mousePosition.x, (int)Input.mousePosition.y, 1f);
		mousePos = Camera.main.ScreenToWorldPoint(mousePos);
		Vector3 RoundedmousePos = new Vector3(Mathf.RoundToInt(mousePos.x), Mathf.RoundToInt(mousePos.y), 1f);
		transform.position = RoundedmousePos;
	}

	public static void SetCursorTracker(bool status)
	{
		enabled = status;
	}
}
