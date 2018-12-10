using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabReferance;
    [SerializeField]
    private float spawnInterval, up, down, left, right, upLeft, upRight, downLeft, downRight;
    enum Direction{up, down, left, right, upLeft, upRight, downLeft, downRight};
    float[,] dir = new float[8,2] {{7.4f, 3},{7.4f, 1},{6.3f, 2},{8.5f, 2},{6.3f, 3},{8.5f, 3},{6.3f, 1},{8.5f, 1} };
	[SerializeField]
	private Material[] materials;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("SpawnItem", this.spawnInterval, this.spawnInterval);
    }

    // Update is called once per frame
    private void SpawnItem()
    {
        GameObject newObject = Instantiate(this.prefabReferance);
        int rand = Random.Range(0, 8);
        newObject.transform.position = new Vector3(dir[rand,0],dir[rand,1], 5);

        Material objectMaterial = materials[Random.Range(0, this.materials.Length)];
        newObject.GetComponent<MeshRenderer>().material = objectMaterial;
    }
}
