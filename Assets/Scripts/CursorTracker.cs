using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTracker : MonoBehaviour
{
	// Update is called once per frame
	void Update()
	{
		//moves CursorTracker object to follow the cursor while staying locked to the grid
		Vector3 mousePos = new Vector3((int)Input.mousePosition.x, (int)Input.mousePosition.y, 1f);
		mousePos = Camera.main.ScreenToWorldPoint(mousePos);
		Vector3 RoundedmousePos = new Vector3(Mathf.RoundToInt(mousePos.x), Mathf.RoundToInt(mousePos.y), 1f);
		transform.position = RoundedmousePos;
	}
}
