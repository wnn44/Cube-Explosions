using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Detonator _blasting;

    private readonly int _leftKeyMouse = 0;
    private int _maxChance = 100;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        List<Rigidbody> newCubes;

        if (Input.GetMouseButtonDown(_leftKeyMouse))
        {
            Cube cube = SelectCubeInScene();

            if (cube != null)
            {
                if (Random.Range(1, _maxChance) <= cube.ChanceSeparation)
                {
                    newCubes = _spawner.Spawn(cube);

                    _blasting.Explode(newCubes);
                }

                Destroy(cube.gameObject);
            }
        }
    }

    private Cube SelectCubeInScene()
    {
        Cube cube = null;

        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;

            objectHit.TryGetComponent<Cube>(out cube);
        }

        return cube;
    }
}
