using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomingScript : MonoBehaviour
{
	//Singleton
	private static ZoomingScript _instance;
	public static ZoomingScript instance
	{
		get { return _instance; }
	}

	[Range(0, 3)]
	public int zoomState;
	public float speed;
	public List<Transform> aliTransList;
	public List<Vector2> camPosList;
	public List<float> camSizeList;

	public CharacterChanger charChanger;

	// Use this for initialization
	void Awake ()
	{
		if(_instance == null)
		{
			_instance = this;
		}
		else if(_instance != this)
		{
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		GameManagerScript.instance.aliTrans.position = Vector3.Lerp(GameManagerScript.instance.aliTrans.position, aliTransList[zoomState].position, Time.deltaTime * speed);
		Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(camPosList[zoomState].x, camPosList[zoomState].y, -10.0f), Time.deltaTime * speed);
		Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, camSizeList[zoomState], Time.deltaTime * speed);
	}
}
