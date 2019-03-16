using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionsParameters : MonoBehaviour {
	public Dropdown handType;
	public Slider difficulty;
	public Toggle handTracker;
	public Dropdown concept;
	public Slider speed;
	public Toggle cognitive;
	public Dropdown stance;

	public void passInputs()
	{
		GameSettings.handType = handType.options[handType.value].text;
		GameSettings.difficulty = (int)difficulty.value;
		GameSettings.handTracker = handTracker.isOn;
		GameSettings.concept = concept.options[concept.value].text.Split(' ')[0];
		GameSettings.speed = (int)speed.value;
		GameSettings.cognitive = cognitive.isOn;
		GameSettings.stance = stance.options[stance.value].text;

		Debug.Log("from parameters, ul text: " + GameSettings.upLeft);
		Debug.Log("from parameters, ul text: " + GameSettings.up);
		Debug.Log("from parameters, ul text: " + GameSettings.upRight);
		Debug.Log("from parameters, ul text: " + GameSettings.midLeft);
		Debug.Log("from parameters, ul text: " + GameSettings.midRight);
		Debug.Log("from parameters, ul text: " + GameSettings.downLeft);
		Debug.Log("from parameters, ul text: " + GameSettings.down);
		Debug.Log("from parameters, ul text: " + GameSettings.downRight);
		Debug.Log("from parameters, handType text: " + GameSettings.handType);
		Debug.Log("from parameters, handType text: " + GameSettings.difficulty);
		Debug.Log("from parameters, handType text: " + GameSettings.handTracker);
		Debug.Log("from parameters, handType text: " + GameSettings.concept);
		Debug.Log("from parameters, handType text: " + GameSettings.speed);
		Debug.Log("from parameters, handType text: " + GameSettings.cognitive);
		Debug.Log("from parameters, handType text: " + GameSettings.stance);


	}
}
