using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PrintTherapies : MonoBehaviour
{
    public ScrollRect scroll;
    public RectTransform scrollableContent;
    void Start()
    {
        scroll = GetComponent<ScrollRect>();
        printTherapies();
    }
    private void printTherapies()
    {
		scrollableContent = this.GetComponent<RectTransform>();
        Text myText = scrollableContent.GetComponent<Text>();
        for (int i = 0; i < Therapist.therapies.Length - 1; i++)
        {
            myText.text += Therapist.therapies[i] + "\n";

        }
        //scroll.content = scrollableContent;
    }
}
