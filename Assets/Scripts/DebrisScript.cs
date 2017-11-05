using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisScript : MonoBehaviour
{

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.collider.tag == "Uno")
		{
			Debug.Log("Hit");
			GameManagerScript.instance.uno.reactScript.incomingDebris.Remove(transform);
			if(++ZoomingScript.instance.zoomState >= 3)
			{
				ZoomingScript.instance.charChanger.stage = --GameManagerScript.instance.uno.health;
				ZoomingScript.instance.charChanger.change();
				ZoomingScript.instance.zoomState = 0;
			}
			Destroy(gameObject);
		}
	}
}
