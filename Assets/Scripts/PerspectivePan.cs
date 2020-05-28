using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO clamp camera to not going from map borders

public class PerspectivePan : MonoBehaviour
{
    private Vector3 touchStart;
    public Camera cam;
    public float groundZ = 0f;

    private void Start() {
        
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0))
        {
            // touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchStart = GetWorldPosition();
        }

        if(Input.GetMouseButton(0))
        {
            // Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = touchStart - GetWorldPosition();
            Camera.main.transform.position += direction;
        }
    }

    private Vector3 GetWorldPosition()
    {
        Ray mousePos = cam.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.forward, new Vector3(0, 0, groundZ));

        float distance;
        ground.Raycast(mousePos, out distance);

        return mousePos.GetPoint(distance);
    }
}
