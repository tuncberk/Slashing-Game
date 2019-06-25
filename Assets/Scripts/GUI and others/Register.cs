using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
public class Register : MonoBehaviour
{
    public InputField nameField;
    public InputField surnameField;
    public InputField usernameField;
    public InputField passwordField;
    public Toggle therapistToggle;

    public Button submitButton;

    public void CallRegister()
    {
        StartCoroutine(Registerer());

    }
    IEnumerator Registerer()
    {
        string targetURL;
        if (therapistToggle.isOn)
            targetURL = "http://localhost/slashing_game/sqlconnect/register_therapist.php";
        else 
            targetURL = "http://localhost/slashing_game/sqlconnect/register_patient.php";

        Debug.Log("Registering " + targetURL);

        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("surname", surnameField.text);
        form.AddField("username", usernameField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW(targetURL, form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("User created successfully");
            //UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
        else
        {
            Debug.Log("User creation failed. Error #" + www.text);
        }
    }
    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 2 &&
                                    surnameField.text.Length >= 2 &&
                                    usernameField.text.Length >= 4 &&
                                    passwordField.text.Length >= 4);
    }
}