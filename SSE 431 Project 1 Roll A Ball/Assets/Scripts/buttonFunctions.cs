using UnityEngine;
using System.Collections;

public class buttonFunctions : MonoBehaviour {

	public void onClick()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

	public void startGame()
	{
		Application.LoadLevel ("Minigame");
	}

	public void backToMainMenu()
	{
		Application.LoadLevel("Main Menu");
	}

	public void quitGame()
	{
		Application.Quit ();
	}

	public void nextLevel(string nextLevel)
	{
		Application.LoadLevel(nextLevel);
	}
}
