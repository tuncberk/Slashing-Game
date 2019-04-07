using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuGUI : MonoBehaviour {
	public GameObject loginButton;
	public Text userInfoText;

	// Use this for initialization
	void Start () {
		//Debug.Log(Patient.name);

		if (Patient.name != null)
		{
			loginButton.SetActive(false);
			userInfoText.text = "Merhaba " + Patient.name + " " + Patient.surname;
			DBManager.instance.CallGetUserTherapy();
		}
	}
}
