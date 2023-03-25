
// NOT CURRENTLY IN USE
//Funny script that doesn't work the way I want but is now a proof of concept I'm proud I made work.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> offObjects;
    [SerializeField] private List<GameObject> onObjects;
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
            if (Vector2.Distance(player.transform.position, gameobject.transform.position) <= range)
            {
                gameobject.SetActive(true);
                onObjects.Add(gameobject);
                offObjects.Remove(gameobject);
            }
        }

        foreach (GameObject gameobject in onObjects)
        {
            if (Vector2.Distance(player.transform.position, gameobject.transform.position) >= range)
            {
                gameobject.SetActive(false);
                offObjects.Add(gameobject);
                onObjects.Remove(gameobject);
            }
        }
    }

    public void AddObjectToList(GameObject gameobject)
    {
        if (Vector2.Distance(player.transform.position, gameobject.transform.position) >= range)
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
    public void RemoveObjectsFromList(GameObject gameobject)
    {
        if(onObjects.Contains(gameobject))
        {
            onObjects.Remove(gameobject);
        }
        else if (offObjects.Contains(gameobject))
        {
            offObjects.Remove(gameobject);
        }
        else
        {
            Debug.Log("This Object is not in a list");
        }
    }
}
