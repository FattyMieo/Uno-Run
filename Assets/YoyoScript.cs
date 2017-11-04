using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoyoScript : MonoBehaviour
{
	private ConstantForce2D constForce;
	private Rigidbody2D rb;
	private LineRenderer lineRend;
	private Vector2 initForce;
	public bool isRetracting;
	public float speed;
	public UnoReactScript reactScript;

	void Awake ()
	{
		constForce = GetComponent<ConstantForce2D>();
		rb = GetComponent<Rigidbody2D>();
		initForce = constForce.relativeForce;
		lineRend = GetComponentInChildren<LineRenderer>();
		lineRend.SetPosition(0, transform.position);
	}
	
	// Update is called once per frame
	void Update ()
	{
		lineRend.SetPosition(1, transform.position);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.collider.tag == "Uno")
		{
			Debug.Log("Hit");
			reactScript.incomingYoyos.Remove(gameObject.transform);
			Retract();
		}
		else if(collision.collider.tag == "Ali")
		{
			Debug.Log("Retracted");
			gameObject.SetActive(false);
		}
	}

	public void Retract()
	{
		rb.velocity = Vector2.zero;
		constForce.relativeForce = -initForce;
	}
}
