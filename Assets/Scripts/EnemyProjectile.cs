using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    [SerializeField] private float m_speed;
    [SerializeField] private float m_lifeTime;
    private GameObject playerRef;
    private Vector2 playerPos;
    private int m_damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        m_lifeTime = 4f;
        Invoke("DestroyProjectile", m_lifeTime);
        playerRef = GameObject.Find("Space Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerRef != null)
        {
            playerPos = new Vector2(playerRef.transform.position.x, playerRef.transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, playerPos, m_speed * Time.deltaTime);

            Vector3 diff = playerRef.transform.position - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Destructable" || other.tag == "Player")
        {
            if(other.transform.root.GetComponent<LifeState>() != null)
            {
                other.transform.root.GetComponent<LifeState>().TakeDamage(m_damage);
            }
            else
            {
                Debug.Log("What did that even hit just now???");
            }

            DestroyProjectile();
        }
    }

    public int Damage
    {
        get { return m_damage; }
    }
}
