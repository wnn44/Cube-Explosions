using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Spawner _spawner;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            SelectCubeInScene();
    }

    private void SelectCubeInScene()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            
            if (objectHit.TryGetComponent<Cube>(out Cube cube))
            {
                _spawner.Spawn(cube);

            }
        }
    }
}
