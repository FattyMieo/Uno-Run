using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
	//Singleton
	private static GameManagerScript _instance;
	public static GameManagerScript instance
	{
		get { return _instance; }
	}

	public UnoScript uno;

	void Awake()
	{
		if(_instance == null)
		{
			_instance = this;
		}
		else if(_instance != this)
		{
			Destroy(gameObject);
		}

		uno = GameObject.FindGameObjectWithTag("Uno").GetComponent<UnoScript>();
	}

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
