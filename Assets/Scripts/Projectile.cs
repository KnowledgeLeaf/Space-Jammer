using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float m_speed;
    [SerializeField] private float m_lifeTime;
    private PlayerController playerConRef;
    // Start is called before the first frame update
    void Start()
    {
        m_lifeTime = 0.7f;
        Invoke("DestroyProjectile", m_lifeTime);
        playerConRef = GameObject.Find("Space Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * m_speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Destructable" || other.tag == "Boss")
        {
            if(other.GetComponent<LifeState>() != null)
            {
                other.GetComponent<LifeState>().TakeDamage(playerConRef.Damage);
            }
            DestroyProjectile();
        }
    }
}
