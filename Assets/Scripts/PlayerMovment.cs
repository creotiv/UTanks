using UnityEngine;
using System.Collections;

public class PlayerMovment : MonoBehaviour
{

	public GameObject bullet;
	public int bullsCnt;

	public float TankSpeed = 1.0f;
	public const float SCENE_SIZE = 240.0f;

	private Vector3 oldPos;
	private float angleY;
	private Vector3 direction = new Vector3();

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
			pos.x -= TankSpeed;

			angleY = 0.0f;

			if (pos.x < -SCENE_SIZE)
				pos.x = -SCENE_SIZE;
		}
		else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
			pos.x += TankSpeed;

			angleY = 180.0f;

			if (pos.x > SCENE_SIZE)
				pos.x = SCENE_SIZE;
		}
		else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
		{
			pos.z += TankSpeed;

			angleY = 90.0f;
			
			if (pos.z > SCENE_SIZE)
				pos.z = SCENE_SIZE;
		}
		else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
		{
			pos.z -= TankSpeed;
			if (pos.z < -SCENE_SIZE)
				pos.z = -SCENE_SIZE;
		}

		if (Input.GetKey(KeyCode.Space) && bullsCnt == 0)
		{
			GameObject new_bullet = Instantiate(bullet, oldPos, Quaternion.Euler(new Vector3(0, angleY, 0))) as GameObject;
			BulletFly bf = new_bullet.GetComponent<BulletFly>() as BulletFly;
			bf.owner = this.gameObject;
			bullsCnt++;
		}

		gameObject.transform.position = pos;
		transform.position += direction;
		transform.rotation = Quaternion.Euler(new Vector3(0, angleY, 0));
	}

	void shoot() {
		if (bullsCnt == 0)
		{
			var newBullet = Instantiate(bullet, oldPos, Quaternion.Euler(new Vector3(0, angleY, 0))) as GameObject;
			var bf = newBullet.GetComponent<BulletFly>();
			bf.owner = this.gameObject;
			bullsCnt++;
		}
	}
}
