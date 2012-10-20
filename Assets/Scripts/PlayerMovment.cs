using UnityEngine;
using System.Collections;

public class PlayerMovment : MonoBehaviour {
	
	private const float TANK_SPEED = 2.0f;
	private const float SCENE_SIZE = 240.0f;
	
	private Vector3 oldPos;
	
 	void OnTriggerEnter(Collider other) {
		gameObject.transform.position = oldPos;
    }

	void OnTriggerStay(Collider other) {
		gameObject.transform.position = oldPos;
    }
	
	void Start () {
	
	}

	void FixedUpdate () {
		
		Vector3 pos = gameObject.transform.position;
		
		oldPos = pos;

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			pos.x -= TANK_SPEED;
			
			gameObject.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);

			if (pos.x < -SCENE_SIZE)
				pos.x = -SCENE_SIZE;
		}
		else
		if (Input.GetKey(KeyCode.RightArrow))
		{
			pos.x += TANK_SPEED;
			
			gameObject.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
			gameObject.transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));

			
			if (pos.x > SCENE_SIZE)
				pos.x = SCENE_SIZE;
		}
		else
		if (Input.GetKey(KeyCode.UpArrow))
		{
			pos.z += TANK_SPEED;

			gameObject.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
			gameObject.transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));
			
			if (pos.z > SCENE_SIZE)
				pos.z = SCENE_SIZE;
		}
		else
		if (Input.GetKey(KeyCode.DownArrow))
		{
			pos.z -= TANK_SPEED;
			
			gameObject.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
			gameObject.transform.Rotate(new Vector3(0.0f, -90.0f, 0.0f));

			
			if (pos.z < -SCENE_SIZE)
				pos.z = -SCENE_SIZE;
		}

		gameObject.transform.position = pos;
	}
}
