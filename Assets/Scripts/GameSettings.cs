﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSettings {
	public static int id = 1;
	public static string handType = "Sol";
	public static int difficulty = 2;
	public static bool handTracker = false;
	public static string concept = "Kutu";
	public static int speed = 70;
	public static bool cognitive = false;
	public static string stance = "Ayakta";
	public static int upLeft = 3;
	public static int up = 3;
	public static int upRight = 3;
	public static int midLeft = 3;
	public static int midRight = 3;
	public static int downLeft = 3;
	public static int down = 3;
	public static int downRight = 3;
	public static void setGameSettings(string[] parameters)
	{
		GameSettings.id = int.Parse(parameters[1]);
		GameSettings.handType = parameters[2];
		GameSettings.difficulty = int.Parse(parameters[3]);
		GameSettings.handTracker = parameters[4] != "False"; //if not False, then True.
		GameSettings.concept = parameters[5];
		GameSettings.speed = int.Parse(parameters[6]);
		GameSettings.cognitive = parameters[7] != "False";
		GameSettings.stance = parameters[8];
		GameSettings.upLeft = int.Parse(parameters[9]);
		GameSettings.up = int.Parse(parameters[10]);
		GameSettings.upRight = int.Parse(parameters[11]);
		GameSettings.midLeft = int.Parse(parameters[12]);
		GameSettings.midRight = int.Parse(parameters[13]);
		GameSettings.downLeft = int.Parse(parameters[14]);
		GameSettings.down = int.Parse(parameters[15]);
		GameSettings.downRight = int.Parse(parameters[16]);
	}
	public static void debugLogSettings()
	{
		Debug.Log(GameSettings.id);
		Debug.Log(GameSettings.handType);
		Debug.Log(GameSettings.difficulty);
		Debug.Log(GameSettings.handTracker);
		Debug.Log(GameSettings.concept);
		Debug.Log(GameSettings.speed);
		Debug.Log(GameSettings.cognitive);
		Debug.Log(GameSettings.stance);
		Debug.Log(GameSettings.upLeft);
		Debug.Log(GameSettings.up);
		Debug.Log(GameSettings.upRight);
		Debug.Log(GameSettings.midLeft);
		Debug.Log(GameSettings.midRight);
		Debug.Log(GameSettings.downLeft);
		Debug.Log(GameSettings.down);
		Debug.Log(GameSettings.downRight);

	}
}

