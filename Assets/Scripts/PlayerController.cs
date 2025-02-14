using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Detonator _detonator;
    [SerializeField] private float _explosionRadius;

    private readonly int _leftKeyMouse = 0;
    private int _maxChance = 100;
    private int _minChance = 1;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(_leftKeyMouse))
        {
            Cube cube = SelectCubeInScene();

            if (cube != null)
            {
                if (Random.Range(_minChance, _maxChance) <= cube.ChanceSeparation)
                {
                    _detonator.Explode(_spawner.Spawn(cube), cube);
                }
                else
                {
                    _detonator.Explode(GetExplodableObjects(cube), cube);
                }

                Destroy(cube.gameObject);
            }
        }
    }

    private Cube SelectCubeInScene()
    {
        Cube cube = null;

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Transform objectHit = hit.transform;

            objectHit.TryGetComponent<Cube>(out cube);
        }

        return cube;
    }

    private List<Rigidbody> GetExplodableObjects(Cube cube)
    {
        Collider[] hits = Physics.OverlapSphere(cube.transform.position, _explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {

                Debug.Log(hit.attachedRigidbody.name);
                cubes.Add(hit.attachedRigidbody);
            }
        }

        return cubes;
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = new Color(1f, 0f, 0f, 0.1f);
    //    Gizmos.DrawSphere(transform.position, _explosionRadius);
    //}
}
