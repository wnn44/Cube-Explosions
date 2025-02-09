using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _chanceSeparation;

    public float ChanceSeparation => _chanceSeparation;

    public static event Action<Vector3, float, float> PositionCube;

    private Renderer _renderer;

    public void TakeChanceSeparation(float takeValue)
    {
        _chanceSeparation = takeValue;
    }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();

        _renderer.material.color = ChoosingColor();
    }

    private void OnMouseUpAsButton()
    {
        Vector3 cube = transform.position;

        float chanceSeparation = gameObject.GetComponent<Cube>().ChanceSeparation;

        Destroy(gameObject);

        PositionCube?.Invoke(cube, gameObject.transform.localScale.x, chanceSeparation);
    }

    private Color ChoosingColor()
    {
        Color randomColor = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), 1);

        return randomColor;
    }
}
