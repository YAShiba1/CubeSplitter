using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private ParticleSystem _explosionEffect;

    public void SelfDestroy(Transform explodePoint)
    {
        Destroy(gameObject);

        Instantiate(_explosionEffect, explodePoint.transform.position, explodePoint.transform.rotation);
    }

    public void Explode()
    {
        foreach(Rigidbody explodebleObject in GetExplodibleObjects())
        {
            explodebleObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    private List<Rigidbody> GetExplodibleObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> cubes = new();

        foreach(Collider hit in hits)
        {
            if(hit.attachedRigidbody != null) 
            {
                cubes.Add(hit.attachedRigidbody);
            }
        }

        return cubes;
    }
}
