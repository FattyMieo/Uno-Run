using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliScript : MonoBehaviour
{
	public GameObject yoyoPrefab;
	public Transform yoyoSpawnpoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	[ContextMenu("Fire Yoyo")]
	public void FireYoyo()
	{
		Instantiate(yoyoPrefab, yoyoSpawnpoint.position, Quaternion.identity);
	}
}
