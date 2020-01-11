using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	private float speed = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate( 
			new Vector3( 
				Input.GetAxis("Horizontal"), 
				0, 
				Input.GetAxis("Vertical")
			) * Time.deltaTime * speed
			+ new Vector3(0,Input.GetAxis("Mouse ScrollWheel")*10,0)
			, 
			Space.World);
		
	}
}
