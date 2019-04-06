using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListButtonTherapies : MonoBehaviour {

	
	[SerializeField]
	private Text myText;
	[SerializeField]
	private ButtonListControlTherapies buttonContol;
	public void setText(string text)
	{
		myText.text = text;
	}
	public void onClick()
	{
		buttonContol.setPatientInfo(myText.text);
		DBManager.instance.CallSubmitPatientTherapy();
	}
}
