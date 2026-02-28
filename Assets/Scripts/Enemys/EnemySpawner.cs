using Sirenix.OdinInspector;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform earth;
    public float spawnRadius = 40f;

    [Button]
    public void SpawnEnemy()
    {
        Vector3 spawnPos = earth.position + Random.onUnitSphere * spawnRadius;

        GameObject enemy = PoolManager.Instance.Spawn(
            enemyPrefab,
            spawnPos,
            Quaternion.identity);

        enemy.GetComponent<EnemyController>().Init(earth);
    }
}