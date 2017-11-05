using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatLoadSceneScript : MonoBehaviour
{
	//Singleton
	private static DefeatLoadSceneScript _instance;
	public static DefeatLoadSceneScript instance
	{
		get { return _instance; }
	}
	public GameObject panel;

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
		panel.SetActive(false);
	}

	[ContextMenu("Defeat")]
	public void EnablePanel()
	{
		Time.timeScale = 0.0f;
		panel.SetActive(true);
	}

	public void GoToMainMenu()
	{
		Time.timeScale = 1.0f;
		SceneManager.LoadScene(0);
	}
	public void RestartGame()
	{
		Time.timeScale = 1.0f;
		SceneManager.LoadScene(1);
	}
}
