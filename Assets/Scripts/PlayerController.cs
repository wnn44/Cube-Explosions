using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action<Transform, float> ObjectClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            LookingCube();
    }

    private void LookingCube()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;

            if (objectHit.TryGetComponent<Cube>(out Cube cube))
            {
                ObjectClicked?.Invoke(objectHit, cube.GetingChances);
            }
        }
    }
}
