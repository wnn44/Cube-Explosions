using UnityEngine;

public class SpawnCube : MonoBehaviour        
{
    [SerializeField] private Cube _prefabCube;

    private Vector3 positionCube;
    private float _scale;

    private void OnEnable()
    {
        Cube.PositionCube += GetCube;
    }

    private void OnDisable()
    {
        Cube.PositionCube -= GetCube;
    }

    private void GetCube(Vector3 cube, float scale)
    {
        positionCube = cube;

        _scale = scale/2;

        Spawn();  
    }

    private void Spawn()
    {
        _prefabCube.transform.localScale = new Vector3(1f* _scale, 1f* _scale, 1f * _scale);

        int numberÑubes = Random.Range(1, 6);

        while (numberÑubes-- > 0)
        {
            Instantiate(_prefabCube, positionCube, transform.rotation);
        }        
    }
}
