using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Brain : MonoBehaviour
{

	private Engine engine;
	private bool inited = false;
	private float moveStartTime;
	private MovmentType[] movements = 
	{
		MovmentType.Down,
		MovmentType.Left,
		MovmentType.Right,
		MovmentType.Up
	};

	public float MoveTimer = 1;

	// Use this for initialization
	void Start()
	{
		engine = gameObject.GetComponent<Engine>();
		if (engine != null) inited = true;
		moveStartTime = Time.time;
		changeMove();
	}

	// Update is called once per frame
	void Update()
	{
		var time = Time.time;
		if (time - moveStartTime >= MoveTimer)
		{
			changeMove();
			moveStartTime = time;
		}
	}

	void changeMove()
	{
		if (!inited)
			return;

		//var movements = Enum.GetValues(typeof(MovmentType));
		//var random = new System.Random();

		int index = (int)(Random.value * ((float)movements.Length - 0.00001));
		engine.setMovement(movements[index]);
	}
}
