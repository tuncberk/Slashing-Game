using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldSelectionGUI : MonoBehaviour
{
    [SerializeField]
    private GameObject panelImage;
    InputField field;

    void Start()
    {
        field = GetComponent<InputField>();
    }
    void Update()
    {
        if (field.isFocused)
        {
            field.GetComponent<Image>().color = Color.green;
            panelImage.SetActive(true);
        }
        else
        {
            field.GetComponent<Image>().color = Color.white;
            panelImage.SetActive(false);
        }
    }
}
