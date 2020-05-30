using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO make placing for building with different sizes

public class Placer : MonoBehaviour
{
    UIController uiController;

    public Dictionary<string, GameObject> buildings = new Dictionary<string, GameObject>();
    private GameObject selectedBuilding;
    public float heightAboveBlock;
    Transform buildingPos;

    [Header("Buildings prefabs")]
    public GameObject stone;
    public GameObject tree;

    private void Awake()
    {
        uiController = FindObjectOfType<UIController>();
    }

    private void Start()
    {
        InitBuildingPrefabs();
    }

    private void InitBuildingPrefabs()
    {
        buildings.Add("Stone", stone);
        buildings.Add("Tree", tree);
    }

    public void AddBuildingOnMap(Cube cube)
    {
        if (selectedBuilding)
        {
            if (cube.isPlaceable && uiController.isGridVisible)
            {
                buildingPos = cube.transform;
                buildingPos.position = new Vector3(cube.transform.position.x, cube.transform.position.y + heightAboveBlock, cube.transform.position.z);

                Instantiate(selectedBuilding, cube.transform.position, cube.transform.rotation);
                selectedBuilding = null;
                uiController.ToggleGridVisibility();
            }
            else
            {
                print("Can't place here, cube is not placeable or grid is not visible.");
            }
        }

    }

    public void AssignBuilding(string buildingName)
    {
        if (buildings.ContainsKey(buildingName))
        {
            if (!uiController.isGridVisible) { uiController.ToggleGridVisibility(); }

            selectedBuilding = buildings[buildingName];
        }
    }
}
