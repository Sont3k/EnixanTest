using System.Collections.Generic;
using UnityEngine;

//TODO make placing for building with different sizes

public class Placer : MonoBehaviour
{
    private UIController uiController;

    private Dictionary<string, EnvironmentItem> buildings = new Dictionary<string, EnvironmentItem>();
    private EnvironmentItem selectedBuilding;
    public float heightAboveBlock;
    Transform buildingPos;

    [Header("Buildings prefabs")]
    public EnvironmentItem stone;
    public EnvironmentItem tree;

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
                InstantiateBuilding(cube);

                selectedBuilding = null;
                cube.isPlaceable = false;
                uiController.ToggleGridVisibility();
            }
            else
            {
                print("Can't place here, cube is not placeable or grid is not visible.");
            }
        }

    }

    private void InstantiateBuilding(Cube cube)
    {
        buildingPos = cube.transform;
        buildingPos.position = new Vector3(cube.transform.position.x, cube.transform.position.y + heightAboveBlock, cube.transform.position.z);

        var instantiatedBuilding = Instantiate(selectedBuilding, cube.transform.position, cube.transform.rotation);
        instantiatedBuilding.attachedCube = cube;
        instantiatedBuilding.name = selectedBuilding.gameObject.name;
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
