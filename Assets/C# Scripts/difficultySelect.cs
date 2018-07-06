using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class difficultySelect : MonoBehaviour
{
	public void easy()
	{
		SceneManager.LoadScene(2);
	}
	public void medium()
	{
		SceneManager.LoadScene(3);
	}
	public void hard()
	{
		SceneManager.LoadScene(4);
	}
}