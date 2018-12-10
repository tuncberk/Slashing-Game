using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour {
	[SerializeField]
	private float speed;
	
	
	// Use this for initialization
	void Start () {
		speed = - speed /1000;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0.0f,0.0f, speed);
		if (gameObject.transform.position.z < -35){
			Destroy(gameObject);
		}
	}
	
}
