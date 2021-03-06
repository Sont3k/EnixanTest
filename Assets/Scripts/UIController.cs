﻿using UnityEngine;

public class UIController : MonoBehaviour
{
    private Cube[] cubes;
    public bool isGridVisible = true;

    private void Awake() {
        cubes = FindObjectsOfType<Cube>();
    }

    private void Start() {
        ToggleGridVisibility();
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