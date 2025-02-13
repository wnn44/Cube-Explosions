using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Spawner _spawner;
    [SerializeField] Detonator _blasting;

    private readonly int _leftKeyMouse = 0;
    private Camera _camera;
    private List<Rigidbody> newCubes;
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

    private void SelectCubeInScene()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;

            objectHit.TryGetComponent<Cube>(out _cube);
        }
    }
}
