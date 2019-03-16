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
		if (gameObject.transform.position.z < -30){
			float x_coord = gameObject.transform.position.x;
			float y_coord = gameObject.transform.position.y;
			string clr = gameObject.GetComponent<MeshRenderer>().material.name.Split('_')[1];
			clr = clr.Split(' ')[0];

			//string clr = objectMaterial.name.Split('_')[1];
			//Report.isHit = false;
        	OutputManager.writePlay(x_coord, y_coord, false, clr);
			Destroy(gameObject);
		}
	}
	
}
