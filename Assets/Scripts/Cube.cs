using UnityEngine;

public class Cube : MonoBehaviour
{
    public float ChanceSeparation;

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();

        _renderer.material.color = RandomColor();
    }

    private Color RandomColor()
    {
        Color randomColor = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), 1);

        return randomColor;
    }
}
