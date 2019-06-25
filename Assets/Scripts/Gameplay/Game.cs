using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static int itemCounter;
    public static int destroyedItemCounter;

    // Use this for initialization
    void Start()
    {
        itemCounter = GameSettings.getItemLength();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(itemCounter);
        if (itemCounter <= 0)
        {
            GUIManager.instance.activateGameOverMenu();

			//OutputManager.writeHeatmapPython();
			//OutputManager.writeBarchartPython();

			itemCounter += 1;
        }
    }
}
