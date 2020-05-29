using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placer : MonoBehaviour
{
    public GameObject buildingPrefab;
    public float heightAboveBlock;
    Transform buildingPos;

    public void AddBuildingOnMap(Cube cube)
    {
        if (cube.isPlaceable)
        {
            buildingPos = cube.transform;
            buildingPos.position = new Vector3(cube.transform.position.x, cube.transform.position.y + heightAboveBlock, cube.transform.position.z);

            Instantiate(buildingPrefab, cube.transform.position, cube.transform.rotation);
        }
        else
        {
            print("Can't place here, cube is not placeable.");
        }
    }
}
