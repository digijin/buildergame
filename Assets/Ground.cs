using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{


    public int x;
    public int y;
    // Use this for initialization

    Manager manager;
    void Start()
    {
        manager = GameObject.FindObjectOfType<Manager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseUp()
    {
        manager.GroundClick(this);


    }
}
