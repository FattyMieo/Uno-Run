using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTimerScript : MonoBehaviour
{
	public float timeRequired;
	private float timePassed = 0.0f;

	private Vector3 curScale;

	// Use this for initialization
	void Start ()
	{
		curScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(timePassed < timeRequired)
		{
			timePassed += Time.deltaTime;
			curScale.x = curScale.y = Mathf.Lerp(0.0f, timeRequired, timePassed / timeRequired);
			transform.localScale = curScale;
		}
	}
}
