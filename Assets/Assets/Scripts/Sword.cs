using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sword : MonoBehaviour
{
	[SerializeField]
	private float swordDistance;
	
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = Input.mousePosition;
        temp.z = swordDistance; // Set this to be the distance you want the object to be placed in front of the camera.
        this.transform.position = Camera.main.ScreenToWorldPoint(temp);
    }
		
	void OnCollisionEnter(Collision other){
		//play sound
		SFXManager.instance.PlaySFX(Clip.Cut);
		//splash
		//update score
		Destroy(other.gameObject);

		GUIManager.instance.upgradeScore(1);
	}
}
