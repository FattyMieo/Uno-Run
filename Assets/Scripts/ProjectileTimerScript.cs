using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTimerScript : MonoBehaviour
{
	public bool hasStarted = false;

	public float timeRequired;
	public float timePassed = 0.0f;

	private Vector3 curScale;

	// Use this for initialization
	void Start ()
	{
		curScale = transform.localScale;
		hasStarted = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(timePassed < timeRequired)
		{
			if(hasStarted) timePassed += Time.deltaTime;
			curScale.x = curScale.y = Mathf.Lerp(0.0f, 1.0f, timePassed / timeRequired);
			transform.localScale = curScale;
		}
	}
}
