﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

	public GameManager gameManager;
	public GameObject villagerTrail;

	private float timer;
	public float speed;
	
	private Rigidbody2D player;
	
	private Vector2 move;
	private Vector3 moveWhere;
	
	public int PlayerNumber;

	public AudioSource villagerWin;
	public AudioSource allFail;
	

	// Use this for initialization
	void Start ()
	{
		player = GetComponent<Rigidbody2D>();
		
		if (PlayerNumber == 2)
		{
			move = Vector2.up;
		} 
		else
		{
			move = Vector2.down;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;

		if (PlayerNumber == 2)
		{
			P2Move();
		} 
		else
		{
			P1Move();
		}

		if (timer >= speed) //gets the body to instantiate
		{
				moveWhere = transform.position;
				player.position += move;

			if (PlayerNumber == 1)
			{
				Instantiate(villagerTrail, moveWhere, transform.rotation);
			}
				timer = 0; //resets it to zero that it will continue to instantiate the body on each frame
		}
	}

	void P2Move()
	{
		if (Input.GetKey(KeyCode.D))
		{
			move = Vector2.right;
		} 
		else if(Input.GetKey(KeyCode.A))
		{
			move = Vector2.left;
		}
		else if (Input.GetKey(KeyCode.W))
		{
			move = Vector2.up;
		}
		else if (Input.GetKey(KeyCode.S))
		{
			move = Vector2.down;
		}
	}

	void P1Move()
	{
		if (Input.GetKey(KeyCode.RightArrow))
		{
			move = Vector2.right;
		} 
		else if(Input.GetKey(KeyCode.LeftArrow))
		{
			move = Vector2.left;
		}
		else if (Input.GetKey(KeyCode.UpArrow))
		{
			move = Vector2.up;
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			move = Vector2.down;
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.gameObject.CompareTag("Border"))
		{
			Debug.Log("Hit border");
			gameManager.background.Stop();
			gameManager.gameOver();
			allFail.Play();
			gameManager.EndGame.text = "Village? Cursed. \n Witch? Burned. \n Press SPACE to restart";
			GameObject[] growingBody = GameObject.FindGameObjectsWithTag("Body");
			foreach (GameObject villagerTrail in growingBody)
				Destroy(villagerTrail);
		}
		else if (other.gameObject.CompareTag("Body") && PlayerNumber == 2)
		{
			Debug.Log("Hit enemy");
			gameManager.background.Stop();
			gameManager.gameOver();
			villagerWin.Play();
			gameManager.EndGame.text = "The village is safe again! \n Press SPACE to restart";
			GameObject[] growingBody = GameObject.FindGameObjectsWithTag("Body");
			foreach (GameObject villagerTrail in growingBody)
				Destroy(villagerTrail);
		}else if (other.gameObject.CompareTag("Player"))
		{
			Debug.Log("Hit player");
			gameManager.background.Stop();
			gameManager.gameOver();
			allFail.Play();
			gameManager.EndGame.text = "Village? Cursed. \n Witch? Burned. \n Press SPACE to restart";
			GameObject[] growingBody = GameObject.FindGameObjectsWithTag("Body");
			foreach (GameObject villagerTrail in growingBody)
				Destroy(villagerTrail);
		}


	
		
	}
}
