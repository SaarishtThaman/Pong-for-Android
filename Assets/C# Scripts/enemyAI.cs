using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour {
	float ETA,finalYcoor,initYcoor;
	float upperEnd = 4.8f, lowerEnd = -4.8f, gap = 7.23f, deltaY = 0.1f, endY = 3.63f;
	bool timeToMove;
	float calculateFinalYcoor(float ETA,float initYcoor)
	{
		if((initYcoor+(ETA*ball.velocityY1)) <= upperEnd && (initYcoor+(ETA*ball.velocityY1)) >= lowerEnd)
		{
			return initYcoor+(ETA*ball.velocityY1);
		}
		else if((initYcoor+(ETA*ball.velocityY1)) > upperEnd)
		{
			return (2*upperEnd)-initYcoor-(ETA*ball.velocityY1);
		}
		else
		{
			return (2*lowerEnd)-initYcoor-(ETA*ball.velocityY1);
		}
	}
	void Update () {
		if(ball.velocityX1 < 0 && ball.xcoor < 0)
		{
			timeToMove = true;
		}
		if(ball.velocityX1 >= 0)
		{
			timeToMove = false;
		}
		if(ball.xcoor < 0 && ball.xcoor >= -0.2f && ball.velocityX1 < 0)
		{
			ETA = -gap/ball.velocityX1;
			initYcoor = ball.ycoor;
			finalYcoor = calculateFinalYcoor(ETA ,initYcoor);
		}
		if(timeToMove && transform.localPosition.y < finalYcoor-deltaY)
		{
			if(finalYcoor > endY)
			{
				finalYcoor = endY;
			}
			transform.Translate(new Vector2(0,2.8f*Time.deltaTime));
		}
		else if(timeToMove && transform.localPosition.y > finalYcoor+deltaY)
		{
			if(finalYcoor < -endY)
			{
				finalYcoor = -endY;
			}
			transform.Translate(new Vector2(0,-2.8f*Time.deltaTime));
		}
	}
}