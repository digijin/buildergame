using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{

    public Ground target;
    static System.Random random = new System.Random();

    public GameObject innerGameObject;
    public Material material;
    public Material selectedMaterial;

    Manager manager;
    Renderer rend;

    void Start()
    {
        rend = innerGameObject.GetComponent<Renderer>();
        manager = GameObject.FindObjectOfType<Manager>();
        Deselect();
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            transform.LookAt(target.transform);
            Vector3 diff = transform.position - target.transform.position;
            if (diff.magnitude < .1)
            {

                if (random.Next(100) == 1)
                {
                    List<Ground> options = manager.GetAdjacentGround(target);
                    target = options[random.Next(options.Count)];
                }
                //wander
            }
            else
            {
                //generic move forward
                transform.Translate(new Vector3(0, 0, Time.deltaTime));

            }
        }
    }

    void OnMouseUp()
    {
        manager.MinionClicked(this);
    }

    internal void Select()
    {
        rend.sharedMaterial = selectedMaterial;
    }
    internal void Deselect()
    {
        rend.sharedMaterial = material;
    }
}
