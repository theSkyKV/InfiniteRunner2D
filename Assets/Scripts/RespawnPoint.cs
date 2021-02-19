using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private List<Transform> _respawnPoints;
    [SerializeField] private Transform _poolContainer;
    [SerializeField] private float _spawnTime = 1;

    private void Start()
    {
        if (_spawnTime <= 0)
            _spawnTime = 1;

        Pool.Initialize(_poolContainer);
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        var spawnedObjectIndex = Random.Range(0, _enemies.Count);
        var respawnPointIndex = Random.Range(0, _respawnPoints.Count);

        Pool.GetFromPool(_enemies[spawnedObjectIndex].gameObject, _respawnPoints[respawnPointIndex].position);

        yield return new WaitForSeconds(_spawnTime);
        StartCoroutine(Spawner());
    }
}
