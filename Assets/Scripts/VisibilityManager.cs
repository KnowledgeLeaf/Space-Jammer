using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityManager : MonoBehaviour
{
    private List<GameObject> offObjects;
    private List<GameObject> onObjects;
    private GameObject player;
    private int range = 20;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        foreach (GameObject gameobject in offObjects)
        {
            if (Vector3.Distance(player.transform.position, gameobject.transform.position) <= range)
            {
                gameobject.SetActive(true);
                onObjects.Add(gameobject);
            }
        }

        foreach (GameObject gameobject in onObjects)
        {
            if (Vector3.Distance(player.transform.position, gameobject.transform.position) >= range)
            {
                gameobject.SetActive(false);
                offObjects.Add(gameobject);
            }
        }
    }

    private void AddObjectToList(GameObject gameobject)
    {
        if (Vector3.Distance(player.transform.position, gameobject.transform.position) >= range)
        {
            gameobject.SetActive(false);
            offObjects.Add(gameobject);
        }
        else
        {
            gameobject.SetActive(true);
            onObjects.Add(gameobject);
        }
    }
}
