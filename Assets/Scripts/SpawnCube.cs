using UnityEngine;

public class SpawnCube : MonoBehaviour        
{
    [SerializeField] private Cube _prefabCube;

    private Vector3 positionCube;

    private void OnEnable()
    {
        Cube.PositionCube += GetCube;
    }

    private void OnDisable()
    {
        Cube.PositionCube -= GetCube;
    }

    private void GetCube(Vector3 cube)
    {
        positionCube = cube;

        Spawn();  
    }

    private void Spawn()
    {
        Instantiate(_prefabCube, positionCube, transform.rotation);
        Instantiate(_prefabCube, positionCube, transform.rotation);
        Instantiate(_prefabCube, positionCube, transform.rotation);
        Instantiate(_prefabCube, positionCube, transform.rotation);
    }
}
