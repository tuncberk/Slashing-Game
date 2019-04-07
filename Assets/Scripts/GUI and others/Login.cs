using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.IO;
public class Login : MonoBehaviour
{
    public Text txt;
    public InputField usernameField;
    public InputField passwordField;
    public Button submitButton;
    public Toggle therapistToggle;
    //public DBManager db;

    public void CallLogin()
    {
        //if (therapistToggle.isOn)
        StartCoroutine(LoginTherapist());
        //else
        //StartCoroutine(LoginPatient());
    }
    IEnumerator LoginTherapist()
    {
        string targetURL = "http://localhost/slashing_game/sqlconnect/login_therapist.php";
        Debug.Log("Logining therapist" + targetURL);

        WWWForm form = new WWWForm();
        form.AddField("username", usernameField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW(targetURL, form);
        yield return www;
        Debug.Log(www.text);
        if (www.text[0] == '0')
        {
            DBManager.instance.username = usernameField.text;
            Therapist.username = usernameField.text;
            Therapist.id = int.Parse(www.text.Split('\t')[1]);

            Debug.Log(Therapist.id);
            Debug.Log(Therapist.username);

            DBManager.instance.CallGetAllTherapies();
            UnityEngine.SceneManagement.SceneManager.LoadScene("Therapist");
        }
        else
        {
            Debug.Log("User login failed. Error # " + www.text);
            StartCoroutine(LoginPatient());
        }
    }
    IEnumerator LoginPatient()
    {
        string targetURL = "http://localhost/slashing_game/sqlconnect/login_patient.php";
        Debug.Log("Logining patient " + targetURL);

        WWWForm form = new WWWForm();
        string usrnm = usernameField.text;
        form.AddField("username", usrnm);
        form.AddField("password", passwordField.text);
        WWW www = new WWW(targetURL, form);
        yield return www;
        if (www.text[0] == '0')
        {
            DBManager.instance.username = usrnm;
            //Debug.Log("login"+DBManager.instance.LoggedIn);
            //Debug.Log("login"+DBManager.instance.username);

            Patient.id = int.Parse(www.text.Split('\t')[1]);
            Patient.name = www.text.Split('\t')[2];
            Patient.surname = www.text.Split('\t')[3];

            // Debug.Log("id"+Patient.id);
            // Debug.Log("id"+Patient.name);
            //Debug.Log("surname"+Patient.surname);

            //DBManager.instance.id = int.Parse(www.text.Split('\t')[1]);
            //DBManager.instance.CallGetUserTherapy();
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
        else
        {
            Debug.Log("User login failed. Error # " + www.text);
            txt.text = "Kullanıcı Bulunamadı";
        }
    }
    public void VerifyInputs()
    {
        submitButton.interactable = (usernameField.text.Length >= 4 &&
                                    passwordField.text.Length >= 4);
    }
}
