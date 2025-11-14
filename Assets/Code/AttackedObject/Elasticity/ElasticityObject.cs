using System;
using UnityEngine;

namespace Code.AttackedObject.Elasticity
{
    public class ElasticityObject : MonoBehaviour
    {
        public event Action<Vector3, float> AffectInvoked;
        [SerializeField] private MeshFilter _meshFilter;

        public MeshFilter MeshFilter => _meshFilter;

        public void Affect(Vector3 point, float pressure)
        {
            AffectInvoked?.Invoke(point, pressure);
        }
    }
}