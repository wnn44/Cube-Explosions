using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    private List<Cube> _allCubes;

    public void ReceiveList(List<Cube> allCubes)
    {
        _allCubes = allCubes;
        
        Explode();
    }

    public void Explode()
    {
        if (_allCubes != null)
        {
            foreach (Cube explodubleObject in _allCubes)
            {
                Rigidbody rigidbody = explodubleObject.GetComponent<Rigidbody>();

                if (rigidbody != null)
                {
                    rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
                }
            }
        }

    }
}
