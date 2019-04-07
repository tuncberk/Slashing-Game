using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sword : MonoBehaviour
{
    [SerializeField]
    private float swordDistance;

    // Update is called once per frame
    void Update()
    {
        if (GameSettings.handTracker && Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 temp = Input.mousePosition;
            temp.z = swordDistance; // Set this to be the distance you want the object to be placed in front of the camera.
            this.transform.position = Camera.main.ScreenToWorldPoint(temp);
        }
        else if(!GameSettings.handTracker)
        {
            Vector3 temp = Input.mousePosition;
            temp.z = swordDistance; // Set this to be the distance you want the object to be placed in front of the camera.
            this.transform.position = Camera.main.ScreenToWorldPoint(temp);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        SFXManager.instance.PlaySFX(Clip.Cut);

        float x_coord = other.gameObject.transform.position.x;
        float y_coord = other.gameObject.transform.position.y;
        // float x_coord = this.transform.position.x;
        // float y_coord = this.transform.position.y;
        string clr = other.gameObject.GetComponent<MeshRenderer>().material.name.Split('_')[1];
        clr = clr.Split(' ')[0];

        OutputManager.writePlay(x_coord, y_coord, true, clr);
        Destroy(other.gameObject);

        GUIManager.instance.upgradeScore(10);
        Game.itemCounter -= 1;
        Game.destroyedItemCounter += 1;
    }
}
