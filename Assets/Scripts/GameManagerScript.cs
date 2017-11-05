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

	public AliScript ali;
	public Transform aliTrans;
	public UnoScript uno;
	public Transform unoTrans;

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

		GameObject aliGO = GameObject.FindGameObjectWithTag("Ali");
		ali = aliGO.GetComponent<AliScript>();
		aliTrans = aliGO.transform;
		GameObject unoGO = GameObject.FindGameObjectWithTag("Uno");
		uno = unoGO.GetComponent<UnoScript>();
		unoTrans = unoGO.transform;
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
