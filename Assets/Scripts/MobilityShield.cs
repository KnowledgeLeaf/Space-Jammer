using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilityShield : MonoBehaviour
{
    private PlayerController playerScript;
    private bool m_shieldsUp = false;
    [SerializeField] private float m_shieldStrength;
    private float m_shieldMax = 8;
    [SerializeField] private AudioClip m_shieldSound;
    private AudioManager theAudioManager;
    public string m_name = "Mobility Shield";

    private void Start()
    {
        playerScript = transform.root.GetComponent<PlayerController>();
        theAudioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
    }

    private void Update()
    {
        if(playerScript.Turning == true)
        {
            m_shieldsUp = true;
            if(m_shieldStrength < m_shieldMax)
            m_shieldStrength += Time.deltaTime;
            playerScript.WeaponModule.SetActive(false);
            playerScript.ThrusterModule.SetActive(false);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            m_shieldsUp = false;
            playerScript.WeaponModule.SetActive(true);
            playerScript.ThrusterModule.SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<EnemyProjectile>() != null)
        {
            EnemyProjectile projectile = collision.GetComponent<EnemyProjectile>();

            if (m_shieldsUp == true && m_shieldStrength >= projectile.Damage)
            {
                m_shieldStrength -= projectile.Damage;
                collision.gameObject.SetActive(false);
                theAudioManager.SoundFXPlay(m_shieldSound);
            }
        }
    }

    public void MaxOutShields()
    {
        m_shieldStrength = m_shieldMax;
    }

    public float ShieldMax
    {
        get { return m_shieldMax;}
        set { m_shieldMax = value;}
    }
    public float ShieldStrength
    {
        get { return m_shieldStrength;}
        set { m_shieldStrength = value;}
    }
}