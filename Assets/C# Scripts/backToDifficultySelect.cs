using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class backToDifficultySelect : MonoBehaviour {
	public void backToDiff()
	{
		SceneManager.LoadScene(1);
	}
	public void backToMain()
	{
		SceneManager.LoadScene(0);
	}
}