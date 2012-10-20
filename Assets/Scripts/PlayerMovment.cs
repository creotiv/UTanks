using UnityEngine;
using System.Collections;

public class PlayerMovment : MonoBehaviour
{

	public GameObject bullet;
	public int bullsCnt;

	private const float TANK_SPEED = 2.0f;
	public const float SCENE_SIZE = 240.0f;

	private Vector3 oldPos;
	private float angleY;

	void OnTriggerEnter(Collider other)
	{
		gameObject.transform.position = oldPos;
	}

	void OnTriggerStay(Collider other)
	{
		gameObject.transform.position = oldPos;
	}

	void Start()
	{
		bullsCnt = 0;
	}

	void FixedUpdate()
	{

		Vector3 pos = gameObject.transform.position;

		oldPos = pos;

		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			pos.x -= TANK_SPEED;

			angleY = 0.0f;
			gameObject.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);

			if (pos.x < -SCENE_SIZE)
				pos.x = -SCENE_SIZE;
		}
		else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
			pos.x += TANK_SPEED;

			angleY = 180.0f;
			gameObject.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
			gameObject.transform.Rotate(new Vector3(0.0f, angleY, 0.0f));

			if (pos.x > SCENE_SIZE)
				pos.x = SCENE_SIZE;
		}
		else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
		{
			pos.z += TANK_SPEED;

			angleY = 90.0f;
			gameObject.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
			gameObject.transform.Rotate(new Vector3(0.0f, angleY, 0.0f));

			if (pos.z > SCENE_SIZE)
				pos.z = SCENE_SIZE;
		}
		else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
		{
			pos.z -= TANK_SPEED;

			angleY = -90.0f;
			gameObject.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
			gameObject.transform.Rotate(new Vector3(0.0f, angleY, 0.0f));


			if (pos.z < -SCENE_SIZE)
				pos.z = -SCENE_SIZE;
		}

		if (Input.GetKey(KeyCode.Space) && bullsCnt == 0)
		{
			GameObject new_bullet = Instantiate(bullet, oldPos, Quaternion.Euler(new Vector3(0, angleY, 0))) as GameObject;
			BulletFly bf = new_bullet.GetComponent<BulletFly>() as BulletFly;
			//bf.owner = this.gameObject;
			bullsCnt++;
		}

		gameObject.transform.position = pos;
	}
}
