using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeState : MonoBehaviour
{
    [SerializeField]private int m_health;
    private int m_DefaultHealth = 1;
    private int m_playerHealthMod = 10;
    private int m_bossHealthMod = 30;
    [SerializeField] private GameObject m_loot;
    [SerializeField] private GameObject m_explosion;
    [SerializeField] private GameManager gm;
    [SerializeField] private GameObject explosionSound;
    [SerializeField] private GameObject damageCanvas;

    void Awake()
    {
        if(tag == "Player")
        {
            m_health = m_DefaultHealth * m_playerHealthMod;
        }
        else if(tag == "Boss")
        {
            m_health = m_DefaultHealth * m_bossHealthMod;
        }
        else
        {
            m_health = m_DefaultHealth;
        }
    }

    public void TakeDamage(int value)
    {
        m_health -= value;

        if(tag == "Player")
        {
            damageCanvas.SetActive(true);
            Invoke("DamageOff", 1);
        }

        if(m_health <= 0)
        {
            var lootNum = Random.Range(1, 5);

            Instantiate(explosionSound);

            for (var i = 0; i < lootNum; i++)
            {
                var position = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
                Instantiate(m_loot, transform.position + position, new Quaternion(0,0,Random.Range(0, 360),0));
                Instantiate(m_explosion, transform.position + position, new Quaternion(0,0,Random.Range(0, 360),0));
            }

            if(gameObject.tag != "Player")
            {
                if(gameObject.tag == "Boss")
                {
                    gm.GetComponent<GameManager>().BossDead = true;
                }
                Destroy(gameObject);
            }
            else
            {
                GetComponent<PlayerController>().PlayerDead = true;
                gameObject.SetActive(false);
                gm.DisplayHallOfFame();
            }
        }
    }

    public void DamageOff()
    {
        damageCanvas.SetActive(false);
    }


    public int Health
    {
        get{ return m_health;}
        set{m_health = value;}
    }
    public int DefaultHealth
    {
        get{ return m_DefaultHealth;}
        set{m_DefaultHealth = value;}
    }
    public int PlayerHealthMod
    {
        get{ return m_playerHealthMod;}
        set{m_playerHealthMod = value;}
    }
}
