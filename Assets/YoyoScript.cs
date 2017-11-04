using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoyoScript : MonoBehaviour
{
	public float speed;
	public UnoReactScript reactScript;
	public Transform circleIndicator; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.transform.Translate(Vector3.right * Time.deltaTime * speed);
		Vector3 scale = circleIndicator.localScale;
		scale.x += Time.deltaTime / (speed / 2.0f);
		scale.y += Time.deltaTime / (speed / 2.0f);
		circleIndicator.localScale = scale;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Uno")
		{
			Debug.Log("Hit");
			reactScript.incomingProjectiles.Remove(gameObject.transform);
			Destroy(gameObject);
		}
	}
}
