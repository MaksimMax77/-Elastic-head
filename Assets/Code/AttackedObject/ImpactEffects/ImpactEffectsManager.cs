using System;
using System.Collections.Generic;
using Code.Pool;
using UnityEngine;
using Zenject;

namespace Code.AttackedObject.ImpactEffects
{
    public class ImpactEffectsManager : IDisposable, ITickable
    {
        private ObjectPoolsManager _objectPoolsManager;
        private ImpactEffectSource _impactEffectSource;
        private float _destroyTime;
        private GameObject _impactEffectPrefab;
        private List<TimedEffect> _spawnedEffects = new();

        public ImpactEffectsManager(ObjectPoolsManager objectPoolsManager,
            ImpactEffectsManagerSettings impactEffectsManagerSettings,
            ImpactEffectSource impactEffectSource)
        {
            _objectPoolsManager = objectPoolsManager;
            _impactEffectSource = impactEffectSource;
            _impactEffectPrefab = impactEffectsManagerSettings.EffectPrefab;
            _destroyTime = impactEffectsManagerSettings.DestroyTime;
            _impactEffectSource.OnImpact += OnImpact;

            _objectPoolsManager.RegisterPool(_impactEffectPrefab.name, _impactEffectPrefab);
        }

        public void Dispose()
        {
            _impactEffectSource.OnImpact -= OnImpact;
        }

        private void OnImpact(Vector3 point)
        {
            var effect = _objectPoolsManager.GetObject(_impactEffectPrefab.name, _impactEffectPrefab);
            effect.transform.position = point;
            _spawnedEffects.Add(new TimedEffect { Effect = effect, TimeLeft = _destroyTime });
        }

        public void Tick()
        {
            for (var i = _spawnedEffects.Count - 1; i >= 0; i--)
            {
                _spawnedEffects[i].TimeLeft -= Time.deltaTime;
                if (_spawnedEffects[i].TimeLeft <= 0f)
                {
                    _objectPoolsManager.ReturnObject(_spawnedEffects[i].Effect);
                    _spawnedEffects.RemoveAt(i);
                }
            }
        }

        private class TimedEffect
        {
            public GameObject Effect;
            public float TimeLeft;
        }
    }
}