using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSettings {
	public static string therapyName = "Ornek Terapi";
	public static int id = 0;
	public static string handType = "Sol";
	public static int difficulty = 2;
	public static bool handTracker = false;
	public static string concept = "Kutu";
	public static int speed = 50;
	public static bool cognitive = false;
	public static string stance = "Ayakta";
	public static int upLeft = 10;
	public static int up = 10;
	public static int upRight = 10;
	public static int midLeft = 10;
	public static int midRight = 10;
	public static int downLeft = 10;
	public static int down = 10;
	public static int downRight = 10;
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
	public static int getItemLength()
    {
        int total = 0;
        total += GameSettings.upLeft;
        total += GameSettings.up;
        total += GameSettings.upRight;
        total += GameSettings.midLeft;
        total += GameSettings.midRight;
        total += GameSettings.downLeft;
        total += GameSettings.down;
        total += GameSettings.downRight;
        return total;
    }
	public static string[] getGameSettings()
	{
		string[] settings = new string[16];

		settings[0] = GameSettings.id.ToString();
		settings[1] = GameSettings.handType.ToString();
		settings[2] = GameSettings.difficulty.ToString();
		settings[3] = GameSettings.handTracker.ToString();
		settings[4] = GameSettings.concept.ToString();
		settings[5] = GameSettings.speed.ToString();
		settings[6] = GameSettings.cognitive.ToString();
		settings[7] = GameSettings.stance.ToString();
		settings[8] = GameSettings.upLeft.ToString();
		settings[9] = GameSettings.up.ToString();
		settings[10] = GameSettings.upRight.ToString();
		settings[11] = GameSettings.midLeft.ToString();
		settings[12] = GameSettings.midRight.ToString();
		settings[13] = GameSettings.downLeft.ToString();
		settings[14] = GameSettings.down.ToString();
		settings[15] = GameSettings.downRight.ToString();

		return settings;
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

