using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static bool gameEnded = false, paused = false;
	public int nextScene;
	public GameObject WinPanel, StartPanel, pausePanel;
	public AnimationClip panelAnimClip;

	public void Start()
	{
		paused = false;
		gameEnded = false;
		pausePanel.SetActive(false);
		StartPanel.SetActive(true);
		WinPanel.SetActive(false);
	}
	public void Update()
	{
		if (gameEnded) 
		{
			StartCoroutine(GameOver());
			return;
		}

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			pause();
		}
	}

	IEnumerator GameOver()
	{
		WinPanel.SetActive(true);
		yield return new WaitForSeconds(panelAnimClip.length);
		SceneManager.LoadScene (nextScene);
	}

	void pause()
	{
		paused = !paused;
		pausePanel.SetActive(paused);
		StartPanel.SetActive(false);
	}
	public void Exit()
	{
		SceneManager.LoadScene(0);
	}
}
