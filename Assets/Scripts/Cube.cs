using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _chanceSeparation;

    private Renderer _renderer;

    public float GetingChances => _chanceSeparation;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();

        _renderer.material.color = GenerateRandomColor();
    }

    public void SaveChances(float takeValue)
    {
        _chanceSeparation = takeValue;
    }

    private Color GenerateRandomColor()
    {
        return new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), 1);
    }
}
