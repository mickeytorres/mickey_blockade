using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public Text EndGame;
	
	
	// Use this for initialization
	void Start ()
	{
		EndGame.text = "";
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void gameOver()
	{
		
		Time.timeScale = 0;
		EndGame.text = "Game Over \n Press SPACE to restart";
		restart();
		//freeze screen and call for reset button
	}

	void restart()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			SceneManager.LoadScene("Game");
			Time.timeScale = 1;

		}
	}
	
	
}

