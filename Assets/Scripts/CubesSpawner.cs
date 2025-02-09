using System.Collections.Generic;
using UnityEngine;

public class CubesSpawner : MonoBehaviour
{
    [SerializeField] private Cube _prefabCube;

    private List<Cube> _allCubes;
    private Vector3 positionCube;
    private float _scale;
    private float _chance;
    private int _maxNewCubes = 6;
    private int _multiple = 2;
    private int _maxChance = 100;

    private void OnEnable()
    {
        Cube.PositionCube += SettingNewParameters;
    }

    private void OnDisable()
    {
        Cube.PositionCube -= SettingNewParameters;
    }

    private void SettingNewParameters(Vector3 cube, float scale, float chanceSeparation)
    {
        positionCube = cube;

        _scale = scale / _multiple;
        _chance = chanceSeparation; 
        
        Spawn();
    }

    private bool CalculatesChance()
    {
        int droppedValue = Random.Range(1, _maxChance);

        if (droppedValue <= _chance)
            return true;
        else
            return false;
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
                Cube newCube = Instantiate(_prefabCube, positionCube, transform.rotation);

                _allCubes.Add(newCube);

                newCube.GetComponent<Cube>().TakeChanceSeparation(_chance / _multiple);
            }
        }

        Barrel barrel = GetComponent<Barrel>();
        barrel.ReceiveList(_allCubes);
    }
}
