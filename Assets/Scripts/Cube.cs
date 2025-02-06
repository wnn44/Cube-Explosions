using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public static event Action<Vector3, float> PositionCube;

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();

        _renderer.material.color = RandomColor();
    }

    private void OnMouseUpAsButton()
    {
        Vector3 cube = transform.position;
        PositionCube?.Invoke(cube, gameObject.transform.localScale.x);

        Destroy(gameObject);
    }

    private Color RandomColor()
    {
        Color randomColor = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), 1);

        return randomColor;
    }
}
