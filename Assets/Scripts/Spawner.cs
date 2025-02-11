using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _prefabCube;
    [SerializeField] private PlayerController _main;

    private List<Rigidbody> _rbAllCubes;
    private Vector3 _positionCube;
    private float _scale;
    private float _chance;
    private int _maxNewCubes = 6;
    private int _multiple = 2;
    private int _maxChance = 100;

    private void OnEnable()
    {
        _main.ObjectClicked += PreparingNewState;
    }

    private void OnDisable()
    {
        _main.ObjectClicked -= PreparingNewState;
    }

    private void PreparingNewState(Transform cube, float chance)
    {
        _positionCube = cube.position;
        _scale = cube.localScale.x / _multiple;
        _chance = chance;

        Destroy(cube.gameObject);

        Spawn();
    }

    private bool CalculatesChance()
    {
        return Random.Range(1, _maxChance) <= _chance;
    }

    private void Spawn()
    {
       _rbAllCubes = new List<Rigidbody>();

        if (CalculatesChance())
        {
            _prefabCube.transform.localScale = new Vector3(_scale, _scale, _scale);

            int numberÑubes = Random.Range(1, _maxNewCubes);

            while (numberÑubes-- > 0)
            {
                Cube cube = Instantiate(_prefabCube, _positionCube, transform.rotation);

                if (cube.TryGetComponent(out Rigidbody rigidbodyb))
                {
                    _rbAllCubes.Add(rigidbodyb);
                }

                cube.GetComponent<Cube>().SaveChances(_chance / _multiple);
            }
        }

        Detonator blasting = GetComponent<Detonator>();
        blasting.Explode(_rbAllCubes);
    }
}
