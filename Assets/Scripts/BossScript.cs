using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    [SerializeField] private GameObject player_Ref;
    [SerializeField] private GameObject backgroundMusicPlayer;
    [SerializeField] private AudioClip bossMusic;
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private bool m_inBossRadius;
    [SerializeField] private GameObject projectilePreFab;
    [SerializeField] private float m_shootCooldown = 3;
    private Vector3 pos;

    // Update is called once per frame
    void Update()
    {   
        if(Vector3.Distance(transform.position, player_Ref.transform.position) < 20)
        {
            m_inBossRadius = true;
        }
        else
        {
            m_inBossRadius = false;
        }

        m_shootCooldown -= 1 * Time.deltaTime;

        if(m_inBossRadius == true && m_shootCooldown < 0)
        {
            Shoot(3);
        }
    }

    public void Shoot(int value)
    {
        for(int i = value; i > 0; i--)
        {
            pos = transform.position;
            Instantiate(projectilePreFab, pos, transform.rotation);
        }
        m_shootCooldown = 5;
    }
}
