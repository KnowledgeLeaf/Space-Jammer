using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] private GameObject booletPrefab;
    private float m_shotTimer;
    private float m_shotCooldown = 0.3f;

    // Update is called once per frame
    void Update()
    {
        m_shotTimer -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && m_shotTimer <= 0)
        {
            Instantiate(booletPrefab, transform.position, transform.rotation);
            m_shotTimer = m_shotCooldown;
        }
    }

    public float ShotCooldown
    {
        get { return m_shotCooldown; }
        set { m_shotCooldown = value; }
    }
}
