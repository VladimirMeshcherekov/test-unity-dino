using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _timeBetweemSpawn;
    private float _timer = 0;

    private void Start()
    {
        Initialize(_prefabs);
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _timeBetweemSpawn)
        {
            if (TryGetObject(out GameObject enemy))
            {
                _timer = 0;
                SetEnemy(enemy);
            }
        }
    }

    void SetEnemy(GameObject enemy)
    {
        enemy.SetActive(true);
        enemy.transform.position = _spawnPoint.position;
    }
}
