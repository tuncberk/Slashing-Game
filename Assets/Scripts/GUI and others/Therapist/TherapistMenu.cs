using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TherapistMenu : MonoBehaviour
{
    public Text therapistInfoTxt;

    // Use this for initialization
    void Start()
    {
        DBManager.instance.CallGetAllTherapies();
        DBManager.instance.CallGetTherapistPatients();

        if (Therapist.username != null)
            therapistInfoTxt.text = "Merhaba " + Therapist.username;
    }
}
