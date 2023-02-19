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
    [SerializeField] private float m_shootCooldown = 0;
    private Vector3 pos;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        if(m_inBossRadius == false)
        {
            if(Vector3.Distance(transform.position, player_Ref.transform.position) < 20)
            {
                backgroundMusicPlayer.GetComponent<AudioSource>().clip = bossMusic;
                backgroundMusicPlayer.GetComponent<AudioSource>().Play();
                m_inBossRadius = true;
            }
        }
        

        if(m_inBossRadius == true)
        {
            if(Vector3.Distance(transform.position, player_Ref.transform.position) > 20)
            {
                backgroundMusicPlayer.GetComponent<AudioSource>().clip = backgroundMusic;
                backgroundMusicPlayer.GetComponent<AudioSource>().Play();
                m_inBossRadius = false;
            }
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
            pos = new Vector3 (Random.Range(-1.0f, 1.0f), transform.position.y, transform.position.z);
            Instantiate(projectilePreFab, pos, transform.rotation);
        }
        m_shootCooldown = 5;
    }
}
