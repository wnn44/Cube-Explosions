using System.Collections.Generic;
using UnityEngine;

public class Detonator : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _upwardModifier;

    public void Explode(List<Rigidbody> allCubes)
    {
        foreach (Rigidbody explodubleObject in allCubes)
        {
            explodubleObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius, _upwardModifier);
        }
    }
}
