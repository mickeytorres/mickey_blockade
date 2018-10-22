using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

	public GameManager gameManager;
	
	private float timer; 
	
	private Rigidbody2D player;
	
	private Vector2 move;
	
	private Vector3 moveWhere;
	private Vector3 originalPos;
	
	private int playerOneScore;
	private int playerTwoScore;
	
	public int playerNumber;
	
	public GameObject body;
	private GameObject clone;
	
	public float speed;
	
	public Text scoreP1Text;
	public Text scoreP2Text;
	
	
	
	
	// Use this for initialization
	void Start ()
	{
		player = GetComponent<Rigidbody2D>();
		originalPos = gameObject.transform.position;
		scoreP1Text.text = "";
		scoreP2Text.text = "";
		playerOneScore = 0;
		playerTwoScore = 0;
		
		if (playerNumber % 2 == 0) //this should make it so any even numbered players go up while any odd numbers go down
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

		if (playerNumber % 2 == 0)
		{
			EvenPlayerMove();
		} 
		else
		{
			OddPlayerMove();
		}

		if (timer >= speed) //gets the body to instantiate
		{
			moveWhere = transform.position;
			player.position += move;
			Instantiate(body, moveWhere, transform.rotation); //it's still skipping a space so what's up?
			timer = 0; //resets it to zero that it will continue to instantiate the body on each frame
		}
		
		if (playerOneScore == 5 || playerTwoScore == 5)
		{
			gameManager.gameOver();
		}
		
	}

	void EvenPlayerMove()
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

	void OddPlayerMove()
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
		if (!other.gameObject.CompareTag("Border") && !other.gameObject.CompareTag("Body")) 
			
			return;
			Debug.Log("Hit border");
			if (playerNumber == 2)
				AddP1Score();
			else if (playerNumber == 1) 
				AddP2Score();


		GameObject[] growingBody = GameObject.FindGameObjectsWithTag("Body");
		foreach(GameObject body in growingBody)
			Destroy(body);
		RestartLevel();
		


	}
	
	public void AddP1Score ()
	{
		playerOneScore++;
		scoreP1Text.text = playerOneScore.ToString();
	}
	
	public void AddP2Score ()
	{
		playerTwoScore++;
		scoreP2Text.text = playerTwoScore.ToString();
	}

	void RestartLevel()
	{
		gameObject.transform.position = originalPos;
	}
}
