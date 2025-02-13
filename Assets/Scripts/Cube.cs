using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _chanceSeparation;
    [SerializeField] private int _numberOfSpawnCubes;

    private int _minNewCubes = 2;
    private int _maxNewCubes = 6;
    private int _maxChance = 100;
    private int _multiple = 2;
    private float _chance;
    private Renderer _renderer;

    public int NumberOfSpawnCubes => _numberOfSpawnCubes;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();

        _renderer.material.color = GenerateRandomColor();

        _numberOfSpawnCubes = Random.Range(0, _maxNewCubes);

        if (Random.Range(1, _maxChance) >= _chanceSeparation)
        {
            if (_numberOfSpawnCubes < _minNewCubes)
            {
                _numberOfSpawnCubes = 0;
            }
        }

        _chanceSeparation /= _multiple;
    }

    private Color GenerateRandomColor()
    {
        return new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), 1);
    }
}
