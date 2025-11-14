using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Code.Pool
{
    public class ObjectPoolsManager
    {
        private readonly Dictionary<string, List<GameObject>> _pools = new();
        private readonly Dictionary<string, GameObject> _poolRoots = new();
        private readonly int _poolSize;

        public ObjectPoolsManager(int poolSize)
        {
            _poolSize = poolSize;
        }

        public void RegisterPool(string key, GameObject prefab)
        {
            if (_pools.ContainsKey(key))
            {
                Debug.LogWarning($"[ObjectPoolsManager] Pool '{key}' already registered.");
                return;
            }

            var root = new GameObject(key + "Pool");
            _poolRoots[key] = root;

            var list = new List<GameObject>();

            for (var i = 0; i < _poolSize; i++)
            {
                var obj = Object.Instantiate(prefab, root.transform, true);
                obj.SetActive(false);
                list.Add(obj);
            }

            _pools[key] = list;
        }

        public GameObject GetObject(string key, GameObject prefab)
        {
            if (!_pools.TryGetValue(key, out var list))
            {
                throw new Exception($"[ObjectPoolsManager] Pool '{key}' not registered. Call RegisterPool first.");
            }

            foreach (var obj in list)
            {
                if (!obj.activeInHierarchy)
                {
                    obj.SetActive(true);
                    return obj;
                }
            }

            var newObj = Object.Instantiate(prefab);
            if (_poolRoots.TryGetValue(key, out var root))
            {
                newObj.transform.SetParent(root.transform);
            }

            list.Add(newObj);
            return newObj;
        }

        public void ReturnObject(GameObject obj)
        {
            obj.SetActive(false);
        }
    }
}