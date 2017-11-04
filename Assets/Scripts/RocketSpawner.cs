using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour {

	public GameObject rocket;
	public bool auto;
	private float timer;
	private GameObject player;
	private GameObject enemy;

	void Start(){
		player = GameObject.FindGameObjectWithTag("Uno");
		enemy = GameObject.FindGameObjectWithTag("Ali");
	}

	void Update(){
		if(auto){
			if(timer > 0.0f)
				timer -= Time.deltaTime;
			if(timer <= 0.0f){
				Fire();
				timer = Random.Range(3, 6);
			}
		}
	}

	public void Fire(){
		Vector2 pos = new Vector2(enemy.transform.position.x, transform.position.y);
		GameObject go = Instantiate(rocket, pos, Quaternion.identity);
		go.GetComponent<GaunletRocket>().target = player.transform;
	}
}
