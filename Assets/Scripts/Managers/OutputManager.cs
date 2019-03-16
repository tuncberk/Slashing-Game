using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//using Newtonsoft.Json;
using System.IO;

public static class OutputManager
{
    public static int item_id = 0;
    //static string gameSettingsfilePath;
    //public static bool isHit = false;
    static string gameSettingsfilePath = Application.dataPath + "Game_Settings.csv";
    static string userGamefilePath = Application.dataPath + "User_Play.csv";
    
    public static void writePlay(float x_coord,float  y_coord,bool isHit,string color)
    {
        using (StreamWriter writer = new StreamWriter(userGamefilePath, true))
        {
            var csvFileLenth = new System.IO.FileInfo(userGamefilePath).Length;
            if (csvFileLenth == 0)
            {
                writer.WriteLine("player_id,therapy_id,item_id,x_coord,y_coord,hit,color");
            }
			//string clr = color.ToString().Split('_')[1];
            writer.WriteLine(Patient.id.ToString() +
						"," + GameSettings.id.ToString() +
						"," + item_id.ToString() +
                        "," + x_coord.ToString() +
                        "," + y_coord.ToString() +
                        "," + isHit.ToString() +
                        "," + color);
        }
        incrementItemId();
    }
    public static void writeGameSettings()
    {
        using (StreamWriter writer = new StreamWriter(gameSettingsfilePath, true))
        {
            var csvFileLenth = new System.IO.FileInfo(gameSettingsfilePath).Length;
            if (csvFileLenth == 0)
            {
                writer.WriteLine("id,handType,difficulty,handTracker,concept,speed,cognitive,stance");
            }
            writer.WriteLine(GameSettings.id.ToString() +
                        "," + GameSettings.handType.ToString() +
                        "," + GameSettings.difficulty.ToString() +
                        "," + GameSettings.handTracker.ToString() +
                        "," + GameSettings.concept.ToString() +
                        "," + GameSettings.speed.ToString() +
                        "," + GameSettings.cognitive.ToString() +
                        "," + GameSettings.stance.ToString());
        }
    }
    private static void incrementItemId()
    {
        item_id += 1;
    }

}
