using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]private List<GameObject> Obstacles;
    [SerializeField]private float m_spawnCountdown = 10;
    [SerializeField]private GameObject playerRef;
    private Vector3 m_spawnRange;

    private void Start()
    {
        SpawnObjective(20);
    }
    private void Update()
    {
        m_spawnCountdown -= 1 * Time.deltaTime;
        if(m_spawnCountdown <= 0)
        {
            SpawnObjective(1);
            m_spawnCountdown = 10;
        }
    }
    private void SpawnObjective(int number)
    {
        for (int i = 0; i < number; i++)
        {
            m_spawnRange = new Vector3(Random.Range(-26,17), Random.Range(-12,9));
            Instantiate(Obstacles[Random.Range(0,Obstacles.Count)], m_spawnRange, Quaternion.identity);
        }
    }
}
