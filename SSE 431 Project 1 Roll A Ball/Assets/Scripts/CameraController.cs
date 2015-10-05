using UnityEngine;
using System;
using System.Collections;

public class CameraController : MonoBehaviour {
	public float tiltAngle = 45.0f;
	public float smooth = 2.0f;
	public GameObject player;

	private Vector3 offset;
	private int countLoc = 0;

	// Use this for initialization
	void Start () {
		offset = transform.position - new Vector3(0f, .50f, 0f);
	}

	void Update()
	{

	}

	// Update is called once per frame
	void LateUpdate () {
		if (Input.GetKeyUp(KeyCode.E))
		{
			countLoc = (countLoc + 1)%4;
			switch (countLoc)
			{
			case 0: 
				offset = new Vector3( 0,9.49f, -10f) - new Vector3(0f, .50f, 0f);
				break;
			case 1: 
				offset = new Vector3( 10,9.49f, 0f) - new Vector3(0f, .50f, 0f);
				break;
			case 2: 
				offset = new Vector3( 0,9.49f, 10f) - new Vector3(0f, .50f, 0f);
				break;
			case 3: 
				offset = new Vector3( -10,9.49f, 0f) - new Vector3(0f, .50f, 0f);
				break;
			}
		}
		transform.position = player.transform.position + offset;
		transform.LookAt (player.transform.position);
	}
}
