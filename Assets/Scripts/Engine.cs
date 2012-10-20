using UnityEngine;
using System.Collections;

public enum MovmentType {
	Stop,
	Left,
	Right,
	Up,
	Down
}


public class Engine : MonoBehaviour 
{

	public GameObject bullet;
	public int bullsCnt;

	public float TankSpeed = 1.0f;
	public const float SCENE_SIZE = 240.0f;

	private Vector3 oldPos;
	private float yaw;
	private Vector3 direction = new Vector3();

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
		bullsCnt = 0;
	}

	void FixedUpdate()
	{
		if (direction == Vector3.zero)
			return;

		oldPos = transform.position;
		transform.position += direction;
		transform.rotation = Quaternion.Euler(new Vector3(0, yaw, 0));
	}

	void shoot() {
		if (bullsCnt == 0)
		{
			var newBullet = Instantiate(bullet, oldPos, Quaternion.Euler(new Vector3(0, yaw, 0))) as GameObject;
			var bf = newBullet.GetComponent<BulletFly>();
			bf.owner = this.gameObject;
			bullsCnt++;
		}
	}

	void setMovement(MovmentType movementTypt) {
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
