using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Detonator))]
[RequireComponent(typeof(CubeExplosion))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _prefabCube;
    [SerializeField] private PlayerController _main;

    private List<Rigidbody> _newCubes;

    private float _chance;
    private int _minNewCubes = 2;
    private int _maxNewCubes = 6;
    private int _multiple = 2;
    private int _maxChance = 100;

    private Detonator _blasting;
    private CubeExplosion _cubeExplosion;

    private void OnEnable()
    {
        _main.ObjectClicked += Spawn;
    }

    private void OnDisable()
    {
        _main.ObjectClicked -= Spawn;
    }

    private void Awake()
    {
        _blasting = GetComponent<Detonator>();
        _cubeExplosion = GetComponent<CubeExplosion>();
    }

    private bool CalculatesChance()
    {
        return Random.Range(1, _maxChance) <= _chance;
    }

    private void Spawn(Cube cube)
    {
        Vector3 positionCube = cube.transform.position;
        float scale = cube.transform.localScale.x / _multiple;

        _newCubes = new List<Rigidbody>();

        _chance = cube.ÑhanceSeparation;

        //Destroy(cube.gameObject);
        _cubeExplosion.DestroyMy(cube);


        if (CalculatesChance())
        {
            _prefabCube.transform.localScale = new Vector3(scale, scale, scale);

            int numberÑubes = Random.Range(_minNewCubes, _maxNewCubes);

            while (numberÑubes-- > 0)
            {
                Cube newCube = Instantiate(_prefabCube, positionCube, transform.rotation);

                if (newCube.TryGetComponent(out Rigidbody rigidbodyb))
                {
                    _newCubes.Add(rigidbodyb);
                }

                newCube.SaveChances(_chance / _multiple);
            }
        }

        _blasting.Explode(_newCubes);
    }
}
