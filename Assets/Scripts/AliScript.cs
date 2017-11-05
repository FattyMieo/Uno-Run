using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliScript : MonoBehaviour
{
	public GameObject yoyoPrefab;
	public Transform yoyoSpawnpoint;

	public GameObject gauntletPrefab;
	public Transform gauntletSpawnpoint;

	public GameObject airRocketPrefab;
	public Transform airRocketSpawnpoint;
	public Transform airRocketTarget;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Z))
		{
			FireYoyo();
		}
		if(Input.GetKeyDown(KeyCode.X))
		{
			FireGauntlet();
		}
		if(Input.GetKeyDown(KeyCode.C))
		{
			FireAirRocket();
		}
	}

	[ContextMenu("Fire Yoyo")]
	public void FireYoyo()
	{
		Instantiate(yoyoPrefab, yoyoSpawnpoint.position, Quaternion.identity);
	}

	[ContextMenu("Fire Gauntlet")]
	public void FireGauntlet()
	{
		GameObject newGauntlet = Instantiate(gauntletPrefab, gauntletSpawnpoint.position, Quaternion.identity);
		GameManagerScript.instance.uno.reactScript.incomingGauntlets.Add(newGauntlet.transform);
	}

	[ContextMenu("Fire AirRocket")]
	public void FireAirRocket()
	{
		AirRocket ar = Instantiate(airRocketPrefab, airRocketSpawnpoint.position, Quaternion.identity).GetComponent<AirRocket>();
		ar.target = airRocketTarget;
		ar.DelayedStart();
//		Vector2 diff = arTrans.position - airRocketTarget.position;
//		float angle = (Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg);
//		arTrans.rotation = Quaternion.Euler(0, 0, angle - 180);
	}
}
