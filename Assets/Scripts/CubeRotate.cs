using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotate : MonoBehaviour {
	float rotationsPerMinute = 10.0f;
	public GameObject cube;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		cube.transform.Rotate(0,6.0f*rotationsPerMinute*Time.deltaTime,0);
	}
}
