using System;
using UnityEngine;

public class Main : MonoBehaviour
{
    public event Action<Transform> ObjectClicked;

    public new Camera camera;

    void LookingCube()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;

            if (objectHit.TryGetComponent<Cube>(out Cube cube))
            {
                ObjectClicked?.Invoke(objectHit);
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            LookingCube();
    }
}
