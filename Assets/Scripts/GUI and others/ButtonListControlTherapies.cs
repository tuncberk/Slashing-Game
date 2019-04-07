using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListControlTherapies : MonoBehaviour
{
    //public static bool isSelected = false;
    public static int selectedTherapyId;
    private string therapy_id;
    [SerializeField]
    private GameObject buttonTemplate;
    [SerializeField]
    private Text therapyInfo;
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
    public void setSelectedTherapy(string id)
    {
        selectedTherapyId = int.Parse(id);
    }
    public void showTherapyInfo()
    {
        string[] settings = GameSettings.getGameSettings();
        therapyInfo.text = "Terapi No: " + settings[0] + "\n"
                            + "El: " + settings[1] + "\n"
                            + "Zorluk Seviyesi: " + settings[2] + "\n"
                            + "El Sabitleyici: " + settings[3] + "\n"
                            + "Oyun Konsepti: " + settings[4] + "\n"
                            + "Engel Hizi: " + settings[5] + "\n"
                            + "Bilissel Unsur: " + settings[6] + "\n"
                            + "Durus: " + settings[7] + "\n" + "\n"

                            + "Sol Ust: " + settings[8] + "\n"
                            + "Orta Ust: " + settings[9] + "\n"
                            + "Sag Ust: " + settings[10] + "\n"
                            + "Sol Orta: " + settings[11] + "\n"
                            + "Sag Orta: " + settings[12] + "\n"
                            + "Sol Alt: " + settings[13] + "\n"
                            + "Orta Alt: " + settings[14] + "\n"
                            + "Sag Alt: " + settings[15] + "\n";
    }
}
