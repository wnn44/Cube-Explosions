using System.Collections.Generic;
using UnityEngine;

public class Detonator : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _upwardModifier;

    public void Explode(List<Rigidbody> newCubes)
    {
        foreach (Rigidbody explodubleObject in newCubes)
        {
            explodubleObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius, _upwardModifier);
        }
    }
}
