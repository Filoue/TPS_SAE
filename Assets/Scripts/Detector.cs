using System;
using System.Collections.Generic;
using UnityEngine;


public class Detector : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layerMask;

    private readonly Collider[] _hits = new Collider[10];
    
    public bool Detected = false;
    

    private void Update()
    {
        int hitCount = Physics.OverlapSphereNonAlloc(transform.position, _radius, _hits, _layerMask);
        Detected = hitCount > 0;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Detected ? Color.green : Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
