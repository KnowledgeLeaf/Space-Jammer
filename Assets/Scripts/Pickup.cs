using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private int m_pointValue;
    private GameObject playerRef;
    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.Find("Space Player");
        Invoke("DestroyObject", 20);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            playerRef.GetComponent<PlayerController>().CargoHold += 1;
            Destroy(gameObject);
        }
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
