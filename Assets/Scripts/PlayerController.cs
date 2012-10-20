using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	private Engine engine;
	private bool inited = false;
	// Use this for initialization
	void Start()
	{
		engine = gameObject.GetComponent<Engine>();
		if (engine != null) inited = true;
	}

	// Update is called once per frame
	void Update()
	{
		if (!inited)
			return;

		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			engine.setMovement(MovmentType.Left);
		}
		else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
			engine.setMovement(MovmentType.Right);
		}
		else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
		{
			engine.setMovement(MovmentType.Down);
		}
		else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
		{
			engine.setMovement(MovmentType.Up);
		}
		else
		{
			engine.setMovement(MovmentType.Stop);
		}

		if (Input.GetKey(KeyCode.Space)) {
			engine.shoot();
		}

	}
}
