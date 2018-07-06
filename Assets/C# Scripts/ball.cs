using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class ball : MonoBehaviour {

	public Text playerScore, OpponentText;
	public AudioClip hit;
	public void updatePlayerScore()
	{
		playerScore.text = (Convert.ToInt32(playerScore.text)+1).ToString();
	}
	public void updateOpponentScore()
	{
		OpponentText.text = (Convert.ToInt32(OpponentText.text)+1).ToString();
	}
	[SerializeField]float speed = 10f;
	float rightEnd = 8f;
	float leftEnd = -8f;
	backToDifficultySelect score;
	float prob;
	public static float velocityX1,velocityY1,xcoor,ycoor;
	float veloctiyX,veloctiyY;
	Rigidbody2D rb2d;
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		summon(true);
	}
	void OnCollisionEnter2D(Collision2D c)
	{
		AudioSource audio = GetComponent<AudioSource>();
		audio.PlayOneShot(hit);
	}
	IEnumerator waitMate()
	{
		rb2d.velocity = new Vector2(0,0);
		yield return null;
		yield return new WaitForSeconds(1.5f);
		yield return new WaitForEndOfFrame();
		rb2d.velocity = new Vector2(veloctiyX,veloctiyY);
	}
	void summon(bool towardsPlayer)
	{
		StartCoroutine(waitMate());
		transform.position = new Vector2(0,0);
		float sine,prob=UnityEngine.Random.Range(0f,1f);
		if(prob > 0.5f)
		{
			sine = UnityEngine.Random.Range(0.2f,0.8f);
		}
		else
		{
			sine = UnityEngine.Random.Range(-0.8f,-0.2f);
		}
		veloctiyX = speed * Mathf.Sqrt(1-(sine*sine));
		veloctiyY = sine * speed;
		if(!towardsPlayer)
		{
			veloctiyX = -veloctiyX;
			if(UnityEngine.Random.Range(0,1) > 0.5f)
			{
				sine = UnityEngine.Random.Range(0.1f,0.5f);
			}
			else
			{
				sine = UnityEngine.Random.Range(-0.5f,-0.1f);
			}
		}
	}
	void Update () {
		velocityX1 = rb2d.velocity.x;
		velocityY1 = rb2d.velocity.y;
		if(transform.localPosition.x>=rightEnd)
		{
			rb2d.velocity = new Vector2(0,0);
			updateOpponentScore();
			summon(true);
		}
		else if(transform.localPosition.x<=leftEnd)
		{
			rb2d.velocity = new Vector2(0,0);
			updatePlayerScore();
			summon(false);
		}
		xcoor = transform.localPosition.x;
		ycoor = transform.localPosition.y;
	}	
}
