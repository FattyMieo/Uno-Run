using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnoReactScript : MonoBehaviour
{
	public List<Transform> incomingProjectiles;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Q))
		{
			if(incomingProjectiles.Count > 0)
			{
				Debug.Log("Deflected");
				Transform transToBeRemoved = incomingProjectiles[0];
				incomingProjectiles.RemoveAt(0);
				Destroy(transToBeRemoved.gameObject);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Projectile")
		{
			incomingProjectiles.Add(other.gameObject.transform);
		}
	}
}
