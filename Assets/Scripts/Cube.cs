using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _chanceSeparation;

    private int _multiple = 2;

    public float ChanceSeparation => _chanceSeparation;

    private void Awake()
    {
        Renderer renderer = GetComponent<Renderer>();

        renderer.material.color = GenerateRandomColor();

        _chanceSeparation /= _multiple;
    }

    private Color GenerateRandomColor()
    {
        return new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), 1);
    }
}
