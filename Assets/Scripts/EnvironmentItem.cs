using UnityEngine;

public class EnvironmentItem : MonoBehaviour
{
    [HideInInspector] public Cube attachedCube;
    private int id;
    
    // Occupied place on grid
    private int x, z;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        x = attachedCube.GetGridPos().x;
        z = attachedCube.GetGridPos().y;

        id = x + z;
        // name = //TODO implement name
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print($"| ID: {id} | Name: {name} | (x, z): ({x}, {z}) |");
        }
    }
}
