using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    private float up = 3.0f;
    private float h_mid = 2.0f;
    private float down = 1.0f;
    private float left = 6.3f;
    private float v_mid = 7.4f;
    private float right = 8.5f;
    private float z = 5;

    List<int> areas = new List<int>();
    //List<Vector3> directions = new List<Vector3>();
    void Awake()
    {
        initializeAreas();
    }
    public Vector3 getRandomArea()
    {
        int rand;
        do
        {
            rand = Random.Range(0, 8);
        }
        while (areas[rand] == 0);
        areas[rand] -= 1;

        if (rand == 0)
            return new Vector3(left, up, z);
        else if (rand == 1)
            return new Vector3(v_mid, up, z);
        else if (rand == 2)
            return new Vector3(right, up, z);
        else if (rand == 3)
            return new Vector3(left, h_mid, z);
        else if (rand == 4)
            return new Vector3(right, h_mid, z);
        else if (rand == 5)
            return new Vector3(left, down, z);
        else if (rand == 6)
            return new Vector3(v_mid, down, z);
        else
            return new Vector3(right, down, z);


    }
    private void initializeAreas()
    {
        areas.Add(GameSettings.upLeft);
        areas.Add(GameSettings.up);
        areas.Add(GameSettings.upRight);
        areas.Add(GameSettings.midLeft);
        areas.Add(GameSettings.midRight);
        areas.Add(GameSettings.downLeft);
        areas.Add(GameSettings.down);
        areas.Add(GameSettings.downRight);
    }
}
