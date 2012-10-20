using UnityEngine;
using System.Collections;

public class PlayerMovment : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 pos = gameObject.transform.position;
		
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			gameObject.transform.Translate(pos + new Vector3(10.0, 0.0, 0.0));
		}
		
		if (Input.GetKey(KeyCode.RightArrow))
		{
		}

		if (Input.GetKey(KeyCode.UpArrow))
		{
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
		}
}
}
