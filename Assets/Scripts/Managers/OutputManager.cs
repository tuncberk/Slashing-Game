using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Diagnostics;

public static class OutputManager
{
    public static int item_id = 0;

    public static void writeGameSettings(string path)
    {
        //gameSettingsfilePath = path;
        using (StreamWriter writer = new StreamWriter(path, true))
        {
            var csvFileLenth = new System.IO.FileInfo(path).Length;
            if (csvFileLenth == 0)
            {
                writer.WriteLine("id,handType,difficulty,handTracker,concept,speed,cognitive,stance,file_name");
            }
            writer.WriteLine(GameSettings.id.ToString() +
                        "," + GameSettings.handType.ToString() +
                        "," + GameSettings.difficulty.ToString() +
                        "," + GameSettings.handTracker.ToString() +
                        "," + GameSettings.concept.ToString() +
                        "," + GameSettings.speed.ToString() +
                        "," + GameSettings.cognitive.ToString() +
                        "," + GameSettings.stance.ToString() +
                        "," + timeStampHour + "-" + GameSettings.id.ToString());
        }
    }
    private static void incrementItemId()
    {
        item_id += 1;
    }

    //------------------------------------------------------------------------------//
    static string gameTablePath = Application.dataPath;
    static string timeStamp = System.DateTimeOffset.Now.ToString("yyyy-MM-dd");
    static string timeStampHour = System.DateTime.Now.ToString("HH-mm-ss");

    private static void EnsureDirectoryExists(string filePath)
    {
        FileInfo fi = new FileInfo(filePath);
        if (!fi.Directory.Exists)
        {
            System.IO.Directory.CreateDirectory(fi.DirectoryName);
        }
    }

    public static void writePlay(float x_coord, float y_coord, bool isHit, string color)
    {

        string userGamefilePath = gameTablePath + "/Players" + "/" + Patient.name + Patient.surname + "/" + timeStamp + "/";
        EnsureDirectoryExists(userGamefilePath);
        string userGameFullPath = userGamefilePath + timeStampHour + "-" + GameSettings.id.ToString() + ".csv";
        string txt;

        using (StreamWriter writer = new StreamWriter(userGameFullPath, true))
        {
            var csvFileLenth = new System.IO.FileInfo(userGameFullPath).Length;
            if (csvFileLenth == 0)
            {
                UnityEngine.Debug.Log("Lenght is 0");
                string textPath = gameTablePath + "/credentials.txt";
                using (StreamWriter textwr = new StreamWriter(textPath, true))
                {
                    string writeToText = Patient.name + Patient.surname + "," + timeStamp + "," + timeStampHour + "," + GameSettings.id.ToString();
                    textwr.WriteLine(writeToText);
                };
                string gameSettingsfilePath = userGamefilePath + "GameSettings.csv";
                writeGameSettings(gameSettingsfilePath);

                writer.WriteLine("player_id,therapy_id,item_id,x_coord,y_coord,hit,color");
            }

            txt = (Patient.id.ToString() +
                   "," + GameSettings.id.ToString() +
                   "," + item_id.ToString() +
                   "," + x_coord.ToString() +
                   "," + y_coord.ToString() +
                   "," + isHit.ToString() +
                   "," + color );
                   //"," + DateTime.Today.ToString().Split(' ')[0]);
            writer.WriteLine(txt);
            incrementItemId();
        }
    }
    public static void writeHeatmapPython()
    {
        Process p = new Process();
        p.StartInfo.FileName = "python";
        p.StartInfo.Arguments = "heatmap.py";
        p.StartInfo.RedirectStandardError = true;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.CreateNoWindow = true;

        p.StartInfo.WorkingDirectory = Application.dataPath;
        p.StartInfo.UseShellExecute = false;

        p.Start();
        int timeout = 50000; // some normal value in milliseconds

        p.WaitForExit(timeout);

        try
        {
            //ExitCode throws if the process is hanging
            UnityEngine.Debug.Log(p.ExitCode);
        }
        catch (System.InvalidOperationException ioex)
        {
            UnityEngine.Debug.Log(ioex.ToString());
        }
        UnityEngine.Debug.Log(p.StandardOutput.ReadToEnd());
        p.WaitForExit();
        p.Close();
    }
    public static void writeBarchartPython()
    {
        Process p = new Process();
        p.StartInfo.FileName = "python";
        p.StartInfo.Arguments = "generatebar.py";
        // Pipe the output to itself - we will catch this later
        p.StartInfo.RedirectStandardError = true;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.CreateNoWindow = true;

        // Where the script lives
        //p.StartInfo.WorkingDirectory = "C:/Users/Burak/Unity Projects/EndlessRunner/";
        p.StartInfo.WorkingDirectory = Application.dataPath;
        p.StartInfo.UseShellExecute = false;

        p.Start();
        int timeout = 50000; // some normal value in milliseconds

        p.WaitForExit(timeout);

        try
        {
            //ExitCode throws if the process is hanging
            UnityEngine.Debug.Log(p.ExitCode);
        }
        catch (System.InvalidOperationException ioex)
        {
            UnityEngine.Debug.Log(ioex.ToString());
        }
        UnityEngine.Debug.Log(p.StandardOutput.ReadToEnd());
        p.WaitForExit();
        p.Close();
    }



}
