using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _chanceSeparation;
    
    public float ChanceSeparation => _chanceSeparation;

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();

        _renderer.material.color = ChoosingColor();        
    }

    public void TakeChanceSeparation(float takeValue)
    {
        _chanceSeparation = takeValue;
    }

    private Color ChoosingColor()
    {
        Color randomColor = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), 1);

        return randomColor;
    }
}
