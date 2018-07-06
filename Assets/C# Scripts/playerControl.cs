using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerControl : MonoBehaviour
{
	Touch touch;
	float endY = 3.63f;
	void Update()
	{
		 if(Input.touchCount != 0)
		 {
			 touch = Input.GetTouch(0);
			 if(transform.position.y>=endY && touch.deltaPosition.y<0)
		 	{
				 transform.Translate(0,touch.deltaPosition.y/100,0);
		 	}
			 else if(transform.position.y<=-endY && touch.deltaPosition.y>0)
			 {
				 transform.Translate(0,touch.deltaPosition.y/100,0);
			 }
			 else if(transform.position.y<=endY && transform.position.y>=-endY)
			 {
			 transform.Translate(0,touch.deltaPosition.y/100,0);
		 	}
		 }
	}
}
