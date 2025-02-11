using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _chanceSeparation;

    private Renderer _renderer;

    public float ChanceSeparation => _chanceSeparation;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();

        _renderer.material.color = GenerateRandomColor();
    }

    public void TakeChanceSeparation(float takeValue)
    {
        _chanceSeparation = takeValue;
    }

    private Color GenerateRandomColor()
    {
        return new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), 1);
    }
}
