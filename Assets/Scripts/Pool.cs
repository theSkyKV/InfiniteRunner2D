using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    private static Dictionary<string, LinkedList<GameObject>> _pool;
    private static Transform _poolContainer;

    public static void Initialize(Transform poolContainer)
    {
        _pool = new Dictionary<string, LinkedList<GameObject>>();
        _poolContainer = poolContainer;
    }

    public static void PutToPool(GameObject gameObject)
    {
        _pool[gameObject.name].AddFirst(gameObject);
        gameObject.transform.parent = _poolContainer;
        gameObject.SetActive(false);
    }

    public static GameObject GetFromPool(GameObject prefab, Vector3 position)
    {
        if (_pool.ContainsKey(prefab.name) == false)
            _pool[prefab.name] = new LinkedList<GameObject>();

        GameObject result;

        if (_pool[prefab.name].Count > 0)
        {
            result = _pool[prefab.name].First.Value;
            _pool[prefab.name].RemoveFirst();
            result.SetActive(true);
            result.transform.position = position;

            return result;
        }

        result = Object.Instantiate(prefab);
        result.name = prefab.name;
        result.transform.position = position;

        return result;
    }
}
