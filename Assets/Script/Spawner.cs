using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _spawnObject;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private int _spawnedCyclesValue;
    [SerializeField] private Transform[] _spawnCoordinates;

    private WaitForSeconds _waitForSeconds;
    private System.Random _random;

    private void Start()
    {
        _random = new System.Random();
        _waitForSeconds = new WaitForSeconds(_spawnDelay);
        StartCoroutine(SpawnWithDelay());
    }

    private IEnumerator SpawnWithDelay()
    {
        for (int i = 0; i < _spawnedCyclesValue; i++)
        {
            Instantiate(_spawnObject,
                _spawnCoordinates[_random.Next(_spawnCoordinates.Length)].position,
                Quaternion.identity);
            yield return _waitForSeconds;
        }
    }
}
