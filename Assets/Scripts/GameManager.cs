using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static bool gameEnded = false;

	public void Update()
	{
		if (gameEnded == false) 
		{
			gameEnded = true;	
			Debug.Log ("GAME OVER");
			//Restart ();
		}
	}

	void Restart ()
	{	
		SceneManager.LoadScene ("SampleScene");
	}
}
