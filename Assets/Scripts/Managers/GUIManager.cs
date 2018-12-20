using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public static GUIManager instance;

    public Text scoreTxt;
    private int score;

    // Use this for initialization
    void Awake()
    {
        instance = GetComponent<GUIManager>();
    }

    public void upgradeScore(int increment)
    {
		score += increment;
		scoreTxt.text = score.ToString();
    }
}
