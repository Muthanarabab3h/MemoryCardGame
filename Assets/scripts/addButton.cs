using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addButton : MonoBehaviour
{
    [SerializeField]
    private Transform Grid;

    [SerializeField]
    private int num;

    [SerializeField]
    private GameObject Button;
    private void Awake()
    {
        for (int i = 0; i < num; i++)
        {
            GameObject NewButton = Instantiate(Button);
            NewButton.name = (i).ToString();
            NewButton.transform.SetParent(Grid, false);
        }
    }
}