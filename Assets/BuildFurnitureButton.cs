using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildFurnitureButton : MonoBehaviour
{

    public FurnitureType furniture;
    Manager manager;
    void Start()
    {
        manager = GameObject.FindObjectOfType<Manager>();
    }

    // Update is called once per frame
    void OnClick()
    {
        manager.BuildFurnitureButtonClicked(furniture);
    }
}
