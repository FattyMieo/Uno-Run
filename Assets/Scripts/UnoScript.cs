using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnoScript : MonoBehaviour
{
	public UnoReactScript reactScript;
	public int health = 3;

	// Use this for initialization
	void Awake ()
	{
		reactScript = GetComponentInChildren<UnoReactScript>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(health <= 0)
		{
			DefeatLoadSceneScript.instance.EnablePanel();
		}
	}
}
