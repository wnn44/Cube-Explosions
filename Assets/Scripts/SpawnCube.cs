using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    [SerializeField] private Cube _prefabCube;

    private Vector3 positionCube;
    private float _scale;
    private float _chance;
    private int _maxNewCubes = 6;
    private int _multiple = 2;

    private void OnEnable()
    {
        SelectCube.PositionCube += GetCube;
    }

    private void OnDisable()
    {
        SelectCube.PositionCube -= GetCube;
    }

    private void GetCube(Vector3 cube, float scale, float chanceSeparation)
    {
        positionCube = cube;

        _scale = scale / _multiple;
        _chance = chanceSeparation;

        Spawn();
    }

    private bool —alculates—hance()
    {
        int droppedValue = Random.Range(1, 100);

        if (droppedValue <= _chance)
            return true;
        else
            return false;
    }

    private void Spawn()
    {
        if (—alculates—hance())
        {
            _prefabCube.transform.localScale = new Vector3(_scale, _scale, _scale);

            int number—ubes = Random.Range(1, _maxNewCubes);

            while (number—ubes-- > 0)
            {
                Cube newCube = Instantiate(_prefabCube, positionCube, transform.rotation);

                newCube.GetComponent<Cube>().ChanceSeparation = _chance / _multiple;
            }
        }
    }
}
