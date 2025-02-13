using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Detonator))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private PlayerController _main;

    private List<Rigidbody> _newCubes;
    private float _chance;
    private int _minNewCubes = 2;
    private int _maxNewCubes = 6;
    private int _multiple = 2;
    private int _maxChance = 100;

    public List<Rigidbody> Spawn(Cube cube)
    {
        Vector3 positionCube = cube.transform.position;
        float scale = cube.transform.localScale.x / _multiple;

        _newCubes = new List<Rigidbody>();

        _chance = cube.ÑhanceSeparation;

        if (CalculatesChance())
        {
            cube.transform.localScale = new Vector3(scale, scale, scale);

            int numberÑubes = Random.Range(_minNewCubes, _maxNewCubes);

            while (numberÑubes-- > 0)
            {
                Cube newCube = Instantiate(cube, positionCube, transform.rotation);

                if (newCube.TryGetComponent(out Rigidbody rigidbodyb))
                {
                    _newCubes.Add(rigidbodyb);
                }
                newCube.SaveChances(_chance / _multiple);
            }
        }
        return _newCubes;
    }

    private bool CalculatesChance()
    {
        return Random.Range(1, _maxChance) <= _chance;
    }
}
