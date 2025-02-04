using UnityEngine;

public class Cube : MonoBehaviour
{
    public Color ColorNewCube { get; private set; }

    private void Start()
    {
        ColorNewCube = RandomColor();
    }

    private Color RandomColor()
    {
        Color randomColor = new Color(Random.Range(0f, 1f),Random.Range(0f, 1f),Random.Range(0f, 1f),1);

        return randomColor;
    }
}
