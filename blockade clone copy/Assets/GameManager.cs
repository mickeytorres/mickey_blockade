﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public Text EndGame;
	private float gameTimer;
	public Text countdown;
	public AudioSource witchWin;
	public AudioSource background;
	
	
	
	// Use this for initialization
	void Start ()
	{
		EndGame.text = "";
		gameTimer = 30;
		countdown.text = gameTimer.ToString("f0");
		background.Play();

	}
	
	// Update is called once per frame
	void Update ()
	{
		SetTimer();
		
		if (gameTimer <= 0)
		{
			background.Stop();
			gameOver();
			witchWin.Play();
			EndGame.text = "Oh no, the witch is gone! \n Press SPACE to restart";
		}

		restart();
	}
	
	void SetTimer() //runs the timer
	{
		gameTimer -= Time.deltaTime; //decreases time
		countdown.text = gameTimer.ToString("f0"); //prints the timer
		//Debug.Log("Time left:" + gameTimer);
	}

	public void gameOver()
	{
		
		Time.timeScale = 0;
		
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

