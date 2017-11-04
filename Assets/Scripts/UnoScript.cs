using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnoScript : MonoBehaviour
{
	public UnoReactScript reactScript;
	// Use this for initialization
	void Awake ()
	{
		reactScript = GetComponentInChildren<UnoReactScript>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
