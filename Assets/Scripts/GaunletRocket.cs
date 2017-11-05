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

	void Start()
	{
		target = GameManagerScript.instance.unoTrans;
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
		if(col.collider.tag == "Uno")
		{
			//Particle Effects
			smoke.transform.parent = null;
			ParticleSystem part = smoke.GetComponent<ParticleSystem>();
			part.loop = false;

			Debug.Log("Hit");
			GameManagerScript.instance.uno.reactScript.incomingGauntlets.Remove(transform);
			GameManagerScript.instance.uno.reactScript.hackTimer = 0.0f;
			if(++ZoomingScript.instance.zoomState >= 3)
			{
				ZoomingScript.instance.charChanger.stage = --GameManagerScript.instance.uno.health;
				ZoomingScript.instance.charChanger.change();
				ZoomingScript.instance.zoomState = 0;
			}

			Explode();
		}
	}

	public void Explode()
	{
		Destroy(gameObject);
	}
}
