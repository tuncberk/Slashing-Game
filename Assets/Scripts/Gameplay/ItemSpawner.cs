using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ItemSpawner : MonoBehaviour
{
    int itemLength;
    int currentItemid = 0;
    [SerializeField]
    private GameObject prefabReferance;
    [SerializeField]
    private float spawnInterval;
    //, up, down, left, right, upLeft, upRight, downLeft, downRight;
    //enum Direction { up, down, left, right, upLeft, upRight, downLeft, downRight };
    float[,] dir = new float[8, 2] { { 7.4f, 3 }, { 7.4f, 1 }, { 6.3f, 2 }, { 8.5f, 2 }, { 6.3f, 3 }, { 8.5f, 3 }, { 6.3f, 1 }, { 8.5f, 1 } };
    [SerializeField]
    private Material[] materials;
    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        itemLength = getItemLength();
        //delete
        itemLength = 5;
        OutputManager.writeGameSettings();
        InvokeRepeating("SpawnItem", this.spawnInterval, this.spawnInterval);

    }
    private void SpawnItem()
    {
        GameObject newObject = Instantiate(this.prefabReferance);
        int rand = Random.Range(0, 8);
        float x = dir[rand, 0];
        float y = dir[rand, 1];

        newObject.transform.position = new Vector3(x, y, 5);


        Material objectMaterial = materials[Random.Range(0, this.materials.Length)];
        newObject.GetComponent<MeshRenderer>().material = objectMaterial;

        checkItemEnd();

    }
    public int getItemLength()
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
    private void checkItemEnd()
    {
        //itemLength -= 1;
        currentItemid += 1;
        if (currentItemid == itemLength)
        {
            CancelInvoke();

            //OutputManager.writeJSON();
        }
    }
}