using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _prefabCube;
    [SerializeField] private Main _main;

    private List<Cube> _allCubes;
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

    private void PreparingNewState(Transform cube)
    {
        _positionCube = cube.position;
        _scale = cube.localScale.x / _multiple;
        _chance = cube.GetComponent<Cube>().ChanceSeparation;

        Destroy(cube.gameObject);

        Spawn();
    }

    private bool CalculatesChance()
    {
        return Random.Range(1, _maxChance) <= _chance;
    }

    private void Spawn()
    {
        _allCubes = new List<Cube>();

        if (CalculatesChance())
        {
            _prefabCube.transform.localScale = new Vector3(_scale, _scale, _scale);

            int numberÑubes = Random.Range(1, _maxNewCubes);

            while (numberÑubes-- > 0)
            {
                Cube newCube = Instantiate(_prefabCube, _positionCube, transform.rotation);

                _allCubes.Add(newCube);

                newCube.GetComponent<Cube>().TakeChanceSeparation(_chance / _multiple);
            }
        }

        Barrel barrel = GetComponent<Barrel>();
        barrel.Explode(_allCubes);
    }
}
