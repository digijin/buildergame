using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Furniture", menuName = "Furniture")]
public class FurnitureType : ScriptableObject
{
    public new string name;
    public string description;
    public GameObject prefab;

    public GameObject ghost;



}
