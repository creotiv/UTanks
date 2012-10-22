using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{

	public bool invulnerable = false;
	public int live = 1;

	private int _live = 1;
	// Use this for initialization
	void Start()
	{
		_live = live;
	}

	// Update is called once per frame
	void Update()
	{

	}

	internal bool onDamage(int damage)
	{
		if (invulnerable)
			return false;

		_live -= damage;

		if (_live <= 0)
		{
			Destroy(gameObject);
		}

		return true;
	}
}
