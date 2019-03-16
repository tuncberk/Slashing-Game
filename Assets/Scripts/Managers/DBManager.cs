using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBManager : MonoBehaviour
{
    public static DBManager instance;
    public int id;
    public string username;
    public int therapyID;
    public string[] patients;
    public string[] therapies;
    public bool LoggedIn { get { return username != ""; } }
    void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        instance = GetComponent<DBManager>();

    }
    public void LogOut()
    {
        username = null;
    }
    public void CallGetTherapies()
    {
        StartCoroutine(GetTherapies());
    }
    public void CallGetUserTherapy()
    {
        StartCoroutine(GetUserTherapy());
    }
    public void CallSubmitTherapy()
    {
        StartCoroutine(SubmitTherapy());
    }
    IEnumerator GetTherapies()
    {
        string targetURL = "http://localhost/slashing_game/sqlconnect/get_therapies.php";
        Debug.Log("Getting therapies " + targetURL);

        WWWForm form = new WWWForm();
        WWW www = new WWW(targetURL, form);
        yield return www;
        if (www.text[0] == '1')
        {
            Debug.Log("Therapy. Error # " + www.text);

        }
        else
        {
            //DBManager.username = usernameField.text; 
            therapies = www.text.Split('\t');
            Debug.Log(www.text);
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
    }
    IEnumerator GetUserTherapy()
    {
        string targetURL = "http://localhost/slashing_game/sqlconnect/get_user_therapy.php";
        Debug.Log("Getting therapies " + targetURL);

        WWWForm form = new WWWForm();
        form.AddField("patient_id", Patient.id);
        WWW www = new WWW(targetURL, form);

        yield return www;
        if (www.text[0] == '0')
        {
            Debug.Log("Therapy. Error # " + www.text);

        }
        else
        {
            Debug.Log(www.text);
            //DBManager.username = usernameField.text; 
            //Patient.therapyId = int.Parse(www.text);
            string[] therapyParameters = www.text.Split('\t');
            GameSettings.setGameSettings(therapyParameters);
            GameSettings.debugLogSettings();
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
    }
    IEnumerator SubmitTherapy()
    {
        string targetURL = "http://localhost/slashing_game/sqlconnect/submit_therapy.php";
        Debug.Log("Logining patient " + targetURL);

        WWWForm form = new WWWForm();
        //addTherapyFields(form);
        //form.AddField("id", GameSettings.id);
        form.AddField("handType", GameSettings.handType);
        form.AddField("difficulty", GameSettings.difficulty);
        form.AddField("handTracker", GameSettings.handTracker.ToString());
        form.AddField("concept", GameSettings.concept);
        form.AddField("speed", GameSettings.speed);
        form.AddField("cognitive", GameSettings.cognitive.ToString());
        form.AddField("stance", GameSettings.stance);
        form.AddField("upLeft", GameSettings.upLeft);
        form.AddField("up", GameSettings.up);
        form.AddField("upRight", GameSettings.upRight);
        form.AddField("midLeft", GameSettings.midLeft);
        form.AddField("midRight", GameSettings.midRight);
        form.AddField("down", GameSettings.down);
        form.AddField("downLeft", GameSettings.downLeft);
        form.AddField("downRight", GameSettings.downRight);
       
        WWW www = new WWW(targetURL, form);
        yield return www;
        Debug.Log(www.text);
        if (www.text[0] == '0')
        {
            Debug.Log("therapy added succesfully");

            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
        else
        {
            Debug.Log("User login failed. Error # " + www.text);
        }
    }
    public void addTherapyFields(WWWForm form)
    {
        form.AddField("id", GameSettings.id);
        form.AddField("handType", GameSettings.handType);
        form.AddField("difficulty", GameSettings.difficulty);
        form.AddField("handTracker", GameSettings.handTracker.ToString());
        form.AddField("concept", GameSettings.concept);
        form.AddField("speed", GameSettings.speed);
        form.AddField("cognitive", GameSettings.cognitive.ToString());
        form.AddField("stance", GameSettings.stance);
        form.AddField("upLeft", GameSettings.upLeft);
        form.AddField("up", GameSettings.up);
        form.AddField("upRight", GameSettings.upRight);
        form.AddField("midLeft", GameSettings.midLeft);
        form.AddField("midRight", GameSettings.midRight);
        form.AddField("down", GameSettings.down);
        form.AddField("downLeft", GameSettings.downLeft);
        form.AddField("downRight", GameSettings.downRight);
    }
}
