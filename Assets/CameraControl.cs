using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    private float speed = 10;

    private bool dragging = false;

    Camera cam;

    Vector3 lastMousePosition = new Vector3();

    public GameObject testStart;
    public GameObject testEnd;

    // Use this for initialization
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            // Debug.Log("down");
            dragging = true;
            lastMousePosition = GetMousePosition();
        }
        if (Input.GetButtonUp("Fire3"))
        {
            // Debug.Log("up");
            dragging = false;
        }

        if (dragging)
        {

            Vector3 newMousePosition = GetMousePosition();

            Vector3 diff = lastMousePosition - newMousePosition;
            transform.Translate(diff, Space.World);
            // transform.position = transform.position + diff;

            // Debug.Log(diff);

            testStart.transform.position = lastMousePosition;
            testEnd.transform.position = newMousePosition;

            // lastMousePosition = newMousePosition;
            lastMousePosition = GetMousePosition();
        }
        else
        {

            transform.Translate(
                new Vector3(
                    Input.GetAxis("Horizontal"),
                    0,
                    Input.GetAxis("Vertical")
                ) * Time.deltaTime * speed
                + new Vector3(0, Input.GetAxis("Mouse ScrollWheel") * -10, 0)
                ,
                Space.World);
        }


    }

    private Vector3 GetMousePosition()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Plane hPlane = new Plane(Vector3.up, Vector3.zero);
        float distance = 0;
        if (hPlane.Raycast(ray, out distance))
        {
            // transform.position = ray.GetPoint(distance);
            // Debug.Log(ray.GetPoint(distance));
            return ray.GetPoint(distance);
        }
        else
        {
            return lastMousePosition; //dirty hack
        }
    }
}
