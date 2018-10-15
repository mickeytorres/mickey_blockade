using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerOne : MonoBehaviour
{
	public GameObject body;
	
	private Vector2 go = Vector2.down; //player two will be Vector2 up I think?
	private Vector2 startPosition;
	private List<Transform> newBody = new List<Transform>();
	private bool isMoving = true;

	// Use this for initialization
	void Start ()
	{

			
		InvokeRepeating("Movement", 0.9f, 0.9f);
		
	}
	
	// Update is called once per frame
	void Update () {

			if (Input.GetKey(KeyCode.RightArrow))
			{
				go = Vector2.right;
			} 
			else if(Input.GetKey(KeyCode.LeftArrow))
			{
				go = Vector2.left;
			}
			else if (Input.GetKey(KeyCode.UpArrow))
			{
				go = Vector2.up;
			}
			else if (Input.GetKey(KeyCode.DownArrow))
			{
				go = Vector2.down;
			}
		
	}

	void Movement()
	{
		startPosition = transform.position;
		transform.Translate(go);

		if (isMoving)
		{
			GameObject grow = Instantiate(body, transform.position + transform.forward, transform.rotation);
			newBody.Insert(0, grow.transform);
		} 
		else if(newBody.Count > 0)
		{
			newBody.Last().position = startPosition;

			newBody.Insert(0, newBody.Last());
			newBody.RemoveAt(newBody.Count - 1);

		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Border")) //for now it's game over when player hits a border
		{
			Debug.Log("Hit border");
			isMoving = false;
			if (Input.GetKey(KeyCode.Space))
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}
	}
}
