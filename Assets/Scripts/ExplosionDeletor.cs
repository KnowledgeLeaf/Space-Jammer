using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDeletor : MonoBehaviour
{
    private int m_lifetime;
    // Start is called before the first frame update
    void Start()
    {
        m_lifetime = 5;
        Invoke("DestroySelf", m_lifetime);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
