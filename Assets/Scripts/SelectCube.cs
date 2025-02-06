using System;
using UnityEngine;

public class SelectCube : MonoBehaviour
{
    public static event Action<Vector3, float,float> PositionCube;

    private void OnMouseUpAsButton()
    {
        Vector3 cube = transform.position;

        float chanceSeparation = gameObject.GetComponent<Cube>().ChanceSeparation;
        Debug.Log(chanceSeparation+"--------");
        

        PositionCube?.Invoke(cube, gameObject.transform.localScale.x, chanceSeparation);

        Destroy(gameObject);
    }
}
