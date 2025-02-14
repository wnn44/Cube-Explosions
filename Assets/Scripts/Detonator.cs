using System.Collections.Generic;
using UnityEngine;

public class Detonator : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _upwardModifier;
    [SerializeField] private ParticleSystem _effect;

    public void Explode(List<Rigidbody> getExplodableObjects, Cube cube)
    {
        foreach (Rigidbody explodubleObject in getExplodableObjects)
        {
            explodubleObject.AddExplosionForce(_explosionForce, cube.transform.position, _explosionRadius, _upwardModifier) ; 
        }

        //Instantiate(_effect, transform.position, transform.rotation);
    }

}
