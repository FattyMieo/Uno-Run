using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnoReactScript : MonoBehaviour
{
	public List<Transform> incomingYoyos;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Q))
		{
			if(incomingYoyos.Count > 0)
			{
				Debug.Log("Deflected");
				incomingYoyos[0].GetComponent<YoyoScript>().Retract();
				incomingYoyos.RemoveAt(0);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Yoyo")
		{
			incomingYoyos.Add(other.gameObject.transform);
		}
	}
}
