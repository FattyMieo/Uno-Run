using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnExitScreen : MonoBehaviour
{
	// Update is called once per frame
	void Update ()
	{
		if(transform.position.x < -20.0f)
		{
			gameObject.SetActive(false);
		}
	}
}
