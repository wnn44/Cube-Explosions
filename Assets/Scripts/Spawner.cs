using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Detonator))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private PlayerController _main;

    private List<Rigidbody> _newCubes;
    private int _multipleScale = 2;
    private int _numberOfSpawnCubes;

    public List<Rigidbody> Spawn(Cube cube)
    {
        Vector3 positionCube = cube.transform.position;

        float scale = cube.transform.localScale.x / _multipleScale;

        _newCubes = new List<Rigidbody>();

        _numberOfSpawnCubes = cube.NumberOfSpawnCubes;

        cube.transform.localScale = new Vector3(scale, scale, scale);

        while (_numberOfSpawnCubes-- > 0)
        {
            Cube newCube = Instantiate(cube, positionCube, transform.rotation);

            if (newCube.TryGetComponent(out Rigidbody rigidbodyb))
            {
                _newCubes.Add(rigidbodyb);
            }
        }

        return _newCubes;
    }
}
