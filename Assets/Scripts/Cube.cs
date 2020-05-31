using UnityEngine;

public class Cube : MonoBehaviour
{
    private Placer placer;

    private Vector2Int gridPos;
    const int gridSize = 20;
    public bool isPlaceable = true;

    private void Awake()
    {
        placer = FindObjectOfType<Placer>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            placer.AddBuildingOnMap(this);
        }
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }
}
