using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO add icon changing for GridVisibility button

public class UIController : MonoBehaviour
{
    Cube[] cubes;
    public bool isGridVisible = true;

    private void Awake() {
        cubes = FindObjectsOfType<Cube>();
    }

    public void ToggleGridVisibility()
    {
        isGridVisible = !isGridVisible;

        foreach (Cube cube in cubes)
        {
            var cubeEditor = cube.GetComponentInChildren<CubeEditor>();
            cubeEditor.textMesh.gameObject.SetActive(isGridVisible);
        }
    }
}
