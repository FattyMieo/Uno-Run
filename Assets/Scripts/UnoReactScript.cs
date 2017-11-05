using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnoReactScript : MonoBehaviour
{
	public Animator newAnimator;

	public List<Transform> incomingYoyos;

	public float slashCooldown;
	private float slashTimer;
	public bool canSlash;
	public Animator slashy;

	public List<Transform> incomingGauntlets;

	public float totalHackTime;
	public float hackTimer;
	public bool isHacking;
	public Transform indicatorTrans;
	public ProjectileTimerScript indicator;

	public List<Transform> incomingDebris;

	public float totalChargeTime;
	public float chargeTimer;
	public bool isCharging;
	public bool canCharge;
	public Animator bionicArm;
	public Animator punchy;

	// Use this for initialization
	void Start ()
	{
		canSlash = true;
		isHacking = false;
		isCharging = false;
		canCharge = false;
		slashy.Play("Slashy", 0, 1.0f);
//		punchy.Play("Punchy", 0, 1.0f);
		newAnimator.Play("Sword", 1, 1.0f);
		newAnimator.Play("Punch", 2, 1.0f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(canSlash)
		{
			if(Input.GetKeyDown(KeyCode.Q))
			{
				canSlash = false;
				if(incomingYoyos.Count > 0)
				{
					Debug.Log("Deflected");
					incomingYoyos[0].GetComponent<YoyoScript>().Retract();
					incomingYoyos.RemoveAt(0);
				}
				slashy.Play("Slashy", 0, 0.0f);
				newAnimator.Play("Sword", 1, 0.0f);
			}
		}
		else
		{
			slashTimer += Time.deltaTime;
			if(slashTimer >= slashCooldown)
			{
				slashTimer = 0.0f;
				canSlash = true;
			}

		}

		if(Input.GetKeyDown(KeyCode.W))
		{
			isHacking = true;

		}
		else if(Input.GetKeyUp(KeyCode.W))
		{
			hackTimer = 0.0f;
			isHacking = false;
		}

		if(isHacking)
		{
			hackTimer += Time.deltaTime;

			if(hackTimer >= totalHackTime)
			{
				hackTimer = 0.0f;
				isHacking = false;

				if(incomingGauntlets.Count > 0)
				{
					Debug.Log("Hacked");
					incomingGauntlets[0].GetComponent<GaunletRocket>().Explode();
					incomingGauntlets.RemoveAt(0);
				}
			}
		}

		if(incomingGauntlets.Count > 0)
		{
			indicatorTrans.gameObject.SetActive(true);
			indicatorTrans.position = incomingGauntlets[0].transform.position;
		}
		else
		{
			indicatorTrans.gameObject.SetActive(false);
		}

		indicator.hasStarted = isHacking;
		indicator.timePassed = hackTimer;
		indicator.timeRequired = totalHackTime + 0.1f;


		if(Input.GetKeyDown(KeyCode.E))
		{
			isCharging = true;
		}
		else if(Input.GetKeyUp(KeyCode.E))
		{
			chargeTimer = 0.0f;
			isCharging = false;
		}

		if(isCharging)
		{
			if(chargeTimer < totalChargeTime)
			{
				chargeTimer += Time.deltaTime;
			}
			else
			{
				canCharge = true;
			}
		}
		else
		{
			if(canCharge)
			{
				canCharge = false;
				newAnimator.Play("Punch", 2, 0.0f);

				if(incomingDebris.Count > 0)
				{
					Debug.Log("Fisted");
					punchy.Play("Punchy", 0, 0.0f);
					Destroy(incomingDebris[0].gameObject);
					incomingDebris.RemoveAt(0);
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Yoyo")
		{
			incomingYoyos.Add(other.gameObject.transform);
		}
		else if(other.tag == "Debris")
		{
			incomingDebris.Add(other.gameObject.transform);
		}
	}
}
