using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
	private float speed = GameSettings.speed;
	
	// Use this for initialization
	void Start () {
		speed = - speed /10;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0.0f,0.0f, speed * Time.deltaTime);
		if (gameObject.transform.position.z < -30){
			float x_coord = gameObject.transform.position.x;
			float y_coord = gameObject.transform.position.y;
			string clr = gameObject.GetComponent<MeshRenderer>().material.name.Split('_')[1];
			clr = clr.Split(' ')[0];

        	OutputManager.writePlay(x_coord, y_coord, false, clr);
			Destroy(gameObject);

			Game.itemCounter -= 1;
		}
	}
	
}
