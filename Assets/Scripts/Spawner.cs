using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _countSpawns;

    private GameObject[] _spawnPlaces;
    private GameObject _place;

    private void Start()
    {
        _spawnPlaces = GameObject.FindGameObjectsWithTag("Respawn");
        var startSpawn = StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var waitSeconds = new WaitForSeconds(2f);

        for (int i = 0; i < _countSpawns; i++)
        {
            _place = _spawnPlaces[Random.Range(0, _spawnPlaces.Length)];
            Instantiate(_prefab, _place.gameObject.transform);
            yield return waitSeconds;
        }
    }
}
