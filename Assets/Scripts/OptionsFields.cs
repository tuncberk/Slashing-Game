using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsFields : MonoBehaviour
{
    //public Button nextButton;
    public InputField UL;
    public InputField U;
    public InputField UR;
    public InputField ML;
    public InputField MR;
    public InputField DL;
    public InputField D;
    public InputField DR;

    void Start()
    {
        UL.text = GameSettings.upLeft.ToString();
        U.text = GameSettings.up.ToString();
        UR.text = GameSettings.upRight.ToString();
        ML.text = GameSettings.midLeft.ToString();
        MR.text = GameSettings.midRight.ToString();
        DL.text = GameSettings.downLeft.ToString();
        D.text = GameSettings.down.ToString();
        DR.text = GameSettings.downRight.ToString();
    }
    public void passInputs()
    {
        GameSettings.upLeft = int.Parse(UL.text);
        GameSettings.up = int.Parse(U.text);
        GameSettings.upRight = int.Parse(UR.text);
        GameSettings.midLeft = int.Parse(ML.text);
        GameSettings.midRight = int.Parse(MR.text);
        GameSettings.downLeft = int.Parse(DL.text);
        GameSettings.down = int.Parse(D.text);
        GameSettings.downRight = int.Parse(DR.text);


        Debug.Log("from fields, ul text: " + GameSettings.upLeft);
        Debug.Log("from fields, ul text: " + GameSettings.up);
        Debug.Log("from fields, ul text: " + GameSettings.upRight);
        Debug.Log("from fields, ul text: " + GameSettings.midLeft);
        Debug.Log("from fields, ul text: " + GameSettings.midRight);
        Debug.Log("from fields, ul text: " + GameSettings.downLeft);
        Debug.Log("from fields, ul text: " + GameSettings.down);
        Debug.Log("from fields, ul text: " + GameSettings.downRight);
        Debug.Log("from fields, handType text: " + GameSettings.handType);
        Debug.Log("from fields, handType text: " + GameSettings.difficulty);
        Debug.Log("from fields, handType text: " + GameSettings.handTracker);
        Debug.Log("from fields, handType text: " + GameSettings.concept);
        Debug.Log("from fields, handType text: " + GameSettings.speed);
        Debug.Log("from fields, handType text: " + GameSettings.cognitive);
        Debug.Log("from fields, handType text: " + GameSettings.stance);
    }
    public void onClick()
    {
        passInputs();
        UnityEngine.SceneManagement.SceneManager.LoadScene("OptionsParameters");        
    }
}
