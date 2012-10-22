using UnityEngine;
using System.Collections;

public enum MovmentType
{
	Stop,
	Left,
	Right,
	Up,
	Down
}


public class Engine : MonoBehaviour
{

	// public int bullsCnt;
	public GameObject bulletType;

	public int team = 0;
	public float TankSpeed = 4.0f;
	public const float SCENE_SIZE = 240.0f;

	private Vector3 oldPos;
	private float yaw;
	private Vector3 direction = new Vector3();
	private GameObject bullet;

	void OnTriggerEnter(Collider other)
	{
		transform.position = oldPos;
	}

	void OnTriggerStay(Collider other)
	{
		transform.position = oldPos;
	}

	void Start()
	{
		bullet = null;
	}

	void FixedUpdate()
	{
		rigidbody.velocity = Vector3.zero;

		if (direction == Vector3.zero)
			return;

		oldPos = transform.position;
		var pos = transform.position + direction;

		pos.x = Mathf.Round(Mathf.Clamp(pos.x, -SCENE_SIZE, SCENE_SIZE) * TankSpeed) / TankSpeed;
		pos.z = Mathf.Round(Mathf.Clamp(pos.z, -SCENE_SIZE, SCENE_SIZE) * TankSpeed) / TankSpeed;

		transform.position = pos;
		transform.rotation = Quaternion.Euler(new Vector3(0, yaw, 0));

		//Debug.Log(oldPos);
	}

	public void shoot()
	{
		if (bullet == null)
		{
			bullet = Instantiate(bulletType, transform.position, transform.rotation) as GameObject;
			var bf = bullet.GetComponent<BulletFly>();
			bf.team = team;
		}
	}

	public void setMovement(MovmentType movementTypt)
	{
		direction.x = 0;
		direction.z = 0;

		if (movementTypt == MovmentType.Left)
		{
			direction.x -= TankSpeed;
			yaw = 0.0f;
		}
		else if (movementTypt == MovmentType.Right)
		{
			direction.x += TankSpeed;
			yaw = 180.0f;
		}
		else if (movementTypt == MovmentType.Up)
		{
			direction.z += TankSpeed;
			yaw = 90.0f;
		}
		else if (movementTypt == MovmentType.Down)
		{
			direction.z -= TankSpeed;
			yaw = -90.0f;
		}
	}
}
