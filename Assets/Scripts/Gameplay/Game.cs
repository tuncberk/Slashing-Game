using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
	public static int itemCounter;
	// Use this for initialization
	void Start () {
		itemCounter = GameSettings.getItemLength();
	}
	
	// Update is called once per frame
	void Update () {
		if (itemCounter <= 0)
		{
			
		}	
	}
}
