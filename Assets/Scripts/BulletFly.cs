using UnityEngine;
using System.Collections;

public class BulletFly : MonoBehaviour
{

	public int team;
	private const float BULLET_SPEED = 2.5f;

	void Start()
	{

	}

	void OnTriggerEnter(Collider other)
	{
		DestroyObject(this.gameObject);
	}

	void FixedUpdate()
	{

		float a = transform.rotation.eulerAngles.y;
		Vector3 pos = transform.position;
		pos.x -= Mathf.Cos(Mathf.Deg2Rad * a) * BULLET_SPEED;
		pos.z += Mathf.Sin(Mathf.Deg2Rad * a) * BULLET_SPEED;

		float size = collider.bounds.size.y;
		if (pos.x + size < -PlayerMovment.SCENE_SIZE || pos.x - size > PlayerMovment.SCENE_SIZE ||
			pos.z + size < -PlayerMovment.SCENE_SIZE || pos.z - size > PlayerMovment.SCENE_SIZE)
		{
			DestroyObject(this.gameObject);
			return;
		}

		transform.position = pos;

	}
}
