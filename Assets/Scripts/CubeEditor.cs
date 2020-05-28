using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]

public class CubeEditor : MonoBehaviour
{
    Cube cube;
    TextMesh textMesh;

    private void Awake()
    {
        cube = GetComponent<Cube>();
        textMesh = GetComponentInChildren<TextMesh>();
    }

    private void Update()
    {
        SnapToGrid();
        
        if (textMesh)
        {
            UpdateLabel();
        }
    }

    private void UpdateLabel()
    {
        Vector2 gridPos = cube.GetGridPos();


        string labelText = (gridPos.x) + "," + (gridPos.y);
        textMesh.text = labelText;
        gameObject.name = labelText;
    }

    private void SnapToGrid()
    {
        int gridSize = cube.GetGridSize();
        Vector2 gridPos = cube.GetGridPos() * gridSize;

        transform.position = new Vector3(
            gridPos.x,
            20f,
            gridPos.y
        );
    }
}