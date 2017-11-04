using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaunletRocket : MonoBehaviour {

	public Transform target;
	private Rigidbody2D rb;
	private float timer = 0f;
	private bool reset = false;
	public GameObject smoke;

	void Awake(){
		rb = gameObject.GetComponent<Rigidbody2D>();
	}

	void FixedUpdate(){
		if(timer > 0.0f)
			timer -= Time.deltaTime;
		if(timer < 0.0f)
			timer = 0.0f;
		if(timer == 0.0){
			if(!reset){
				reset = true;
				rb.velocity = new Vector2();
			}
			Vector2 diff = transform.position - target.position;
			float angle = (Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg);
			transform.rotation = Quaternion.Euler(0, 0, angle - 180);
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.collider.tag == "Uno"){
			smoke.transform.parent = null;
			var main = smoke.GetComponent<ParticleSystem>();
			main.loop = false;
			Destroy(gameObject);
		}
	}
}
