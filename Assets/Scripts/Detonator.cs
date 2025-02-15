using System.Collections.Generic;
using UnityEngine;

public class Detonator : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _upwardModifier;

    public void Explode(List<Rigidbody> getExplodableObjects, Cube cube, float ratio)
    {
        foreach (Rigidbody explodubleObject in getExplodableObjects)
        {
            explodubleObject.AddExplosionForce(_explosionForce / ratio, cube.transform.position, _explosionRadius, _upwardModifier);
        }
    }
}
