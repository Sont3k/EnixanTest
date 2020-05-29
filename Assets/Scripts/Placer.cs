using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO make placing for building with different sizes

public class Placer : MonoBehaviour
{
    UIController uIController;

    public GameObject buildingPrefab;
    public float heightAboveBlock;
    Transform buildingPos;

    private void Awake() {
        uIController = FindObjectOfType<UIController>();
    }

    public void AddBuildingOnMap(Cube cube)
    {
        if (cube.isPlaceable && uIController.isGridVisible)
        {
            buildingPos = cube.transform;
            buildingPos.position = new Vector3(cube.transform.position.x, cube.transform.position.y + heightAboveBlock, cube.transform.position.z);

            Instantiate(buildingPrefab, cube.transform.position, cube.transform.rotation);
        }
        else
        {
            print("Can't place here, cube is not placeable or grid is not visible.");
        }
    }
}
