using UnityEngine;
using System.Collections;

public class PlayerMovment : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			gameObject.transform.Translate(new Vector3());
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
