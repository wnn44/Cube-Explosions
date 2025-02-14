using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int _multipleScale = 2;
    private int _minNewCubes = 2;
    private int _maxNewCubes = 6;
    private int _namber = 1;

    public List<Rigidbody> Spawn(Cube cube)
    {
        int numberOfSpawnCubes = Random.Range(_minNewCubes, _maxNewCubes);

        Vector3 positionCube = cube.transform.position;

        float scale = cube.transform.localScale.x / _multipleScale;

        List<Rigidbody> newCubes = new List<Rigidbody>();

        cube.transform.localScale = new Vector3(scale, scale, scale);

        for (int i = 0; numberOfSpawnCubes > i; i++)
        {
            Cube newCube = Instantiate(cube, positionCube, transform.rotation);
            
            newCube.name = "cube" + _namber;
            _namber++;

            if (newCube.TryGetComponent(out Rigidbody rigidbodyb))
            {
                newCubes.Add(rigidbodyb);
            }
        }

        return newCubes;
    }
}
