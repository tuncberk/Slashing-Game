using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonListControlTherapies : MonoBehaviour
{
    private string therapy_id;
    [SerializeField]
    private GameObject buttonTemplate;
    void Start()
    {
        for (int i = 0; i < Therapist.therapies.Length - 1; i++)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);

            therapy_id = Therapist.therapies[i].ToString();

            button.GetComponent<ButtonListButtonTherapies>().setText(therapy_id);
            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }
    public void setPatientInfo(string text)
    {
        Patient.therapyId = int.Parse(text);
    }
}
