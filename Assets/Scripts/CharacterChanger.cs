using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChanger : MonoBehaviour {

	public int stage = 1;
	public ParticleSystem ps;

	[Header ("Current Sprites")]
	public SpriteRenderer body;
	public SpriteRenderer arm;

	[Header ("Uno Stage 1")]
	public Sprite body1;
	public Sprite arm1;

	[Header ("Uno Stage 2")]
	public Sprite body2;
	public Sprite arm2;
	public GameObject flyingArmor;

	[Header ("Uno Stage 3")]
	public Sprite body3;
	public Sprite arm3;
	public GameObject flyingShirt;
	public GameObject blurSmoke;

	[ContextMenu ("Change")]
	public void change()
	{
		flyingArmor.transform.position = flyingArmor.transform.parent.position;
		flyingArmor.SetActive(false);
		flyingShirt.transform.position = flyingShirt.transform.parent.position;
		flyingShirt.SetActive(false);

		ps.Play();
		switch(stage)
		{
			case 3:
				body.sprite = body1;
				arm.sprite = arm1;
				blurSmoke.SetActive(false);
				break;

			case 2:
				body.sprite = body2;
				arm.sprite = arm2;
				blurSmoke.SetActive(false);
				flyingArmor.SetActive(true);
				break;

			case 1:
				body.sprite = body3;
				arm.sprite = arm3;
				blurSmoke.SetActive(true);
				flyingShirt.SetActive(true);
				break;
		}
	}
}
