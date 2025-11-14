using System;
using UnityEngine;
using Zenject;

namespace Code.AttackedObject.Elasticity
{
    public class ElasticityObjectControl : ITickable, IDisposable
    {
        private float _bounceSpeed;
        private float _stiffness;
        private MeshFilter _meshFilter;
        private Mesh _mesh;
        private Vector3[] _initialVertices;
        private Vector3[] _currentVertices;
        private Vector3[] _vertexVelocities;
        private Transform _targetTransform;
        private ElasticityObject _elasticityObject;

        private ElasticityObjectControl(ElasticityObject elasticityObject, ElasticityObjectControlSettings settings)
        {
            _elasticityObject = elasticityObject;
            _targetTransform = elasticityObject.transform;
            _meshFilter = elasticityObject.MeshFilter;
            _bounceSpeed = settings.BounceSpeed;
            _stiffness = settings.Stiffness;

            _mesh = _meshFilter.mesh;
            _initialVertices = _mesh.vertices;
            _currentVertices = new Vector3[_initialVertices.Length];
            _vertexVelocities = new Vector3[_initialVertices.Length];

            for (var i = 0; i < _initialVertices.Length; i++)
            {
                _currentVertices[i] = _initialVertices[i];
            }

            _elasticityObject.AffectInvoked += ApplyPressureToPoint;
        }

        public void Dispose()
        {
            _elasticityObject.AffectInvoked -= ApplyPressureToPoint;
        }

        private void ApplyPressureToPoint(Vector3 point, float pressure)
        {
            for (var i = 0; i < _currentVertices.Length; i++)
            {
                ApplyPressureToVertex(i, point, pressure);
            }
        }

        private void ApplyPressureToVertex(int index, Vector3 position, float pressure)
        {
            var distanceVerticePoint = _currentVertices[index] - _targetTransform.InverseTransformPoint(position);
            var adaptedPressure = pressure / (1f + distanceVerticePoint.sqrMagnitude);
            var velocity = adaptedPressure * Time.deltaTime;
            _vertexVelocities[index] += distanceVerticePoint.normalized * velocity;
        }

        public void Tick()
        {
            UpdateVertices();
        }

        private void UpdateVertices()
        {
            for (int i = 0; i < _currentVertices.Length; i++)
            {
                var currentDisplacement = _currentVertices[i] - _initialVertices[i];
                _vertexVelocities[i] -= currentDisplacement * _bounceSpeed * Time.deltaTime;
                _vertexVelocities[i] *= 1f - _stiffness * Time.deltaTime;
                _currentVertices[i] += _vertexVelocities[i] * Time.deltaTime;
            }

            _mesh.vertices = _currentVertices;
            _mesh.RecalculateBounds();
            _mesh.RecalculateNormals();
            _mesh.RecalculateTangents();
        }
    }
}