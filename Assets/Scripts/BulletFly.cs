using UnityEngine;
using System.Collections;

public class BulletFly : MonoBehaviour
{

	public int team;
	public GameObject currentDetonator;
	public GameObject owner;
	private const float BULLET_SPEED = 2.5f;

	void Start()
	{

	}
	
	 void OnTriggerEnter(Collider other) {
		
		//if (other.gameObject.GetComponent<Block>() != null)
		
		GameObject expl =  Instantiate (GameObject.Find("Explo"), other.gameObject.transform.position, Quaternion.identity) as GameObject;
		
		(expl.GetComponent<Detonator>() as Detonator).Explode();
			DestroyObject(other.gameObject);
		
			DestroyObject(this.gameObject);
		//(owner.GetComponent<PlayerMovment>() as PlayerMovment).bullsCnt--;
    }

	void FixedUpdate()
	{

		float yaw = transform.rotation.eulerAngles.y;

		Vector3 pos = transform.position;
		pos.x -= Mathf.Cos(Mathf.Deg2Rad * yaw) * BULLET_SPEED;
		pos.z += Mathf.Sin(Mathf.Deg2Rad * yaw) * BULLET_SPEED;

		float size = collider.bounds.size.y;
		if (pos.x + size < -Engine.SCENE_SIZE || pos.x - size > Engine.SCENE_SIZE ||
			pos.z + size < -Engine.SCENE_SIZE || pos.z - size > Engine.SCENE_SIZE)
		{
			DestroyObject(gameObject);
			return;
		}

		transform.position = pos;

	}
}
