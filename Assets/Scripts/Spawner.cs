using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstacles;
    [SerializeField] private List<GameObject> stations;
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private GameObject shopUIRef;
    [SerializeField] private GameObject playerRef;
    private PoolingManager poolingManager;
    private Vector3 m_spawnRange;
    [SerializeField] private float m_spawnTime;

    private void Start()
    {
        poolingManager = GetComponent<PoolingManager>();
        playerRef = GameObject.FindGameObjectWithTag("Player");
        SpawnDestructible(10);
        SpawnStation(1);
    }

    private void Update()
    {
        m_spawnTime -= Time.deltaTime;

        if (m_spawnTime <= 0 && !playerRef.GetComponent<PlayerController>().inStationRadius)
        {
            int randomNum;
            randomNum = Random.Range(0, 10);

            if (randomNum == 1)
            {
                SpawnStation(randomNum);
            }
            else
            {
                SpawnEnemy(1);
                SpawnDestructible(2);
            }

            m_spawnTime = 10;
        }
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
            Vector2 playerPos = new Vector2(playerRef.transform.position.x, playerRef.transform.position.y);
            var spawnrange = playerPos + Random.insideUnitCircle * 20;
            station = Instantiate(stations[Random.Range(0, stations.Count)], spawnrange, Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f)));
            station.GetComponent<StationScript>().ShopUI = shopUIRef;
        }
    }

    public void SpawnEnemy(int number)
    {
        for (int i = 0; i < number; ++i)
        {
            Vector2 playerPos = new Vector2(playerRef.transform.position.x, playerRef.transform.position.y);
            var spawnrange = playerPos + Random.insideUnitCircle * 20;
            Instantiate(enemies[Random.Range(0, enemies.Count)], spawnrange, Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f)));
        }
    }
}
