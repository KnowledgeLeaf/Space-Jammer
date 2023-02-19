using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject playerRef;
    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.Find("Space Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerRef.transform.position.x, playerRef.transform.position.y, transform.position.z);
        
    }
}
