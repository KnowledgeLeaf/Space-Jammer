using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstacles;
    [SerializeField] private List<GameObject> stations;
    [SerializeField] private GameObject shopUIRef;
    [SerializeField] private GameObject playerRef;
    private PoolingManager poolingManager;
    private Vector3 m_spawnRange;

    private void Start()
    {
        poolingManager = GetComponent<PoolingManager>();
        SpawnDestructible(22);
        SpawnStation(4);
    }
    public void SpawnDestructible(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Vector2 playerPos = new Vector2(playerRef.transform.position.x, playerRef.transform.position.y);
            var spawnrange = playerPos + Random.insideUnitCircle * 20;
            Instantiate(obstacles[Random.Range(0, obstacles.Count)], spawnrange, Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f)));
        }
    }
    public void SpawnStation(int number)
    {
        GameObject station;

        for (int i = 0; i < number; i++)
        {
            var spawnrange = Random.insideUnitCircle * 20;
            station = Instantiate(stations[Random.Range(0, stations.Count)], spawnrange, Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f)));
            station.GetComponent<StationScript>().ShopUI = shopUIRef;
        }
    }
}
