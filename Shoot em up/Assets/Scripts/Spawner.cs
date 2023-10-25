using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Test region
    public float GetSpawnSpeedInfo()
    {
        return spawnSpeed;
    }
    #endregion

    [SerializeField]
    private GameObject[] Prefabs;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float spawnSpeed = 0f;

    private float realSpawnSpeed = 0f;

    private void Start()
    {
        realSpawnSpeed = spawnSpeed;
    }
    private void Update()
    {
        realSpawnSpeed -= Time.deltaTime;
        if (realSpawnSpeed <= 0)
        {
            SpawnPrefab();
            realSpawnSpeed = spawnSpeed;
        }
    }
    private void SpawnPrefab()
    {
        int randomIndex = Random.Range(0, Prefabs.Length);
        GameObject prefab = Prefabs[randomIndex];
        Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }
}
