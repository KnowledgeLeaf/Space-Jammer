using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    private Vector3 pos;
    [SerializeField] private float m_shootCooldown = 3;
    [SerializeField] private GameObject projectilePreFab;
    private GameObject playerRef;
    private float m_speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        m_shootCooldown -= 1 * Time.deltaTime;

        if (m_shootCooldown < 0)
        {
            Shoot(1);
        }

        if (Vector3.Distance(transform.position, playerRef.transform.position) < 20)
        {
            transform.up = playerRef.transform.position - transform.position;
            transform.position = Vector3.MoveTowards(transform.position, playerRef.transform.position, m_speed * Time.deltaTime);
        }
    }

    public void Shoot(int value)
    {
        for (int i = value; i > 0; i--)
        {
            pos = transform.position;
            Instantiate(projectilePreFab, pos, transform.rotation);
        }
        m_shootCooldown = 5;
    }
}
