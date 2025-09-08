using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

	public float movementSpeed;
	public float extraSpeedPerHit;
	public float maxExtraSpeed;

	int hitCounter = 0; 
	// Use this for initialization
	void Start () {
		StartCoroutine(StartBall());
	}

	void PositionBall(bool isPlayer1Starting)
	{
		this.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
		if (isPlayer1Starting)
		{
			this.gameObject.transform.localPosition = new Vector3(-100, 0, 0);
		}
		else
		{
			this.gameObject.transform.localPosition = new Vector3(100, 0, 0);
		}
	}
	
	public IEnumerator StartBall(bool isStartPlayer1=true)
	{
		PositionBall(isStartPlayer1);
		hitCounter = 0;
		yield return new WaitForSeconds(2);
		if (isStartPlayer1) {
			this.MoveBall(new Vector2(-1, 0));
		}
		else
		{
			this.MoveBall(new Vector2(1, 0));
		}

	}
	public void MoveBall(Vector2 dir)
	{
		dir=dir.normalized;
		float speed=movementSpeed+hitCounter*extraSpeedPerHit;
		Rigidbody2D rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
		rigidbody2D.velocity = dir * speed;
	}
	public void IncreaseHitCounter()
	{
		if (hitCounter * extraSpeedPerHit <= maxExtraSpeed)
		{
			hitCounter++;
		}
	}
}
