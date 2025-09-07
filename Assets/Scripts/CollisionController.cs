using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour {

	public BallMovement ballMovement;
	public ScoreController scoreController;
	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2")
		{
			this.BounceFromRacket(collision);
		}
		else if (collision.gameObject.name == "LeftWall")
		{
			scoreController.GoalPlayer2();
		}
		else if (collision.gameObject.name == "RightWall")
		{
			scoreController.GoalPlayer1();
		}
	}
	public void BounceFromRacket(Collision2D collision)
	{
		Vector3  ballPosition = this.transform.position;
		Vector3 racketPosition = collision.gameObject.transform.position;
		float racketHeight = collision.collider.bounds.size.y;
		float x; 
		if(collision.gameObject.name=="Player1")
		{
			x = 1;  //Go right
		}
		else
		{
			x = -1; //Go left
		}
		float y = (ballPosition.y - racketPosition.y) / racketHeight;
		ballMovement.IncreaseHitCounter();
		ballMovement.MoveBall(new Vector2(x, y));
	}
}
