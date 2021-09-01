using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void PlayGame()
	{
		SceneManager.LoadScene("GameScene");
	}
	
	public void InstructionScene()
	{
		SceneManager.LoadScene("InstructionScene");
	}
	
	public void MenuScene()
	{
		SceneManager.LoadScene("MenuScene");
	}
	
	public void CreditsScene()
	{
		SceneManager.LoadScene("CreditsScene");
	}
	
	public void YouLoseScene()
	{
		SceneManager.LoadScene("YouLoseScene");
	}
	
	public void doExitGame()
	{
		Application.Quit();
	}
}
