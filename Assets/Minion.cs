using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{

    public Ground target;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            transform.LookAt(target.transform);
        }
        transform.Translate(new Vector3(0, 0, Time.deltaTime));
    }
}
