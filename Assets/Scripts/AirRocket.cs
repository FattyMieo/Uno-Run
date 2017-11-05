using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirRocket : MonoBehaviour
{
	public Transform target;
	public float spawnTime;
	private float spawnTimePassed;
	public float explosionTime;
	private float explosionTimePassed;
	public GameObject debrisPrefab;

	// Use this for initialization
	public void DelayedStart ()
	{
		Vector2 diff = transform.position - target.position;
		float angle = (Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg);
		transform.rotation = Quaternion.Euler(0, 0, angle - 180);
	}
	
	// Update is called once per frame
	void Update ()
	{
		spawnTimePassed += Time.deltaTime;
		if(spawnTimePassed >= spawnTime)
		{
			Instantiate(debrisPrefab, target.transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
