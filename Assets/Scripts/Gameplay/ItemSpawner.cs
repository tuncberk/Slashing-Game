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
    [SerializeField]
    private Material[] materials;
    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        itemLength = GameSettings.getItemLength();

        //OutputManager.writeGameSettings();
        InvokeRepeating("SpawnItem", this.spawnInterval, this.spawnInterval);
    }
    private void SpawnItem()
    {
        GameObject newObject = Instantiate(this.prefabReferance);

        Area area = GetComponent<Area>();
        Vector3 vec3 = area.getRandomArea();
        newObject.transform.position = vec3;

        Material objectMaterial = materials[Random.Range(0, this.materials.Length)];
        newObject.GetComponent<MeshRenderer>().material = objectMaterial;

        Vector3 scaleFactor = new Vector3((3 - GameSettings.difficulty)/5f, (3 - GameSettings.difficulty)/5f, (3 - GameSettings.difficulty)/5f);
        newObject.transform.localScale += scaleFactor;
        checkItemEnd();

    }
    private void checkItemEnd()
    {
        //itemLength -= 1;
        currentItemid += 1;
        if (currentItemid == itemLength)
        {
            CancelInvoke();
        }
    }
}