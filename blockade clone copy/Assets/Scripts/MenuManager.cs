using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

	public AudioSource menuBackground;

	private void Start()
	{
		menuBackground.Play();
	}

	public void PlayGame()
	{
		SceneManager.LoadScene("Game");
	}
}
