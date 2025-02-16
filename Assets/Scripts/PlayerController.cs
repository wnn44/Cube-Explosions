using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Detonator _detonator;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private ParticleSystem _effect;

    private readonly int _leftKeyMouse = 0;
    private int _maxChance = 100;
    private int _minChance = 1;
    private float _powerFactor = 3;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        float ratio;

        if (Input.GetMouseButtonDown(_leftKeyMouse))
        {
            Cube cube = SelectCubeInScene();

            if (cube != null)
            {
                if (Random.Range(_minChance, _maxChance) <= cube.ChanceSeparation)
                {
                    ratio = _powerFactor;
                    _detonator.Explode(_spawner.Spawn(cube), cube, ratio);
                }
                else
                {
                    ratio = cube.transform.localScale.x;
                    _detonator.Explode(GetExplodableObjects(cube), cube, ratio);
                    
                    Instantiate(_effect, cube.transform.position, transform.rotation);
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
                cubes.Add(hit.attachedRigidbody);
            }
        }

        return cubes;
    }
}
