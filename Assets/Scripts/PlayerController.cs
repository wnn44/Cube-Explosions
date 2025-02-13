using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Spawner _spawner;
    [SerializeField] Detonator _blasting;

    private Camera _camera;
    private List<Rigidbody> newCubes;
    private readonly int _leftKeyMouse = 0;
    private Cube _cube;


    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(_leftKeyMouse))
        {
            SelectCubeInScene();

            if (_cube != null)
            {
                newCubes = _spawner.Spawn(_cube);

                _blasting.Explode(newCubes);

                Destroy(_cube.gameObject);
            }
        }
    }

    private Cube SelectCubeInScene()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            
            if (objectHit.TryGetComponent<Cube>(out _cube))
            {
                return _cube;
            }
            return null;
        }
        return null;
    }
}
