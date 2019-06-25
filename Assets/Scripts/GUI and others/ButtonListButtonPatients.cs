using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListButtonPatients : MonoBehaviour {
	[SerializeField]
	private Text myText;
	[SerializeField]
	private ButtonListControlPatients buttonContol;
	public void setText(string text)
	{
		myText.text = text;
	}
	public void onClick()
	{
		GUIManager.fromPlayersScene = true;
		string name = myText.text.Split(' ')[0];
		string surname = myText.text.Split(' ')[1];
		buttonContol.setPatientInfo(name, surname);
		UnityEngine.SceneManagement.SceneManager.LoadScene("Therapies");
	}
}
