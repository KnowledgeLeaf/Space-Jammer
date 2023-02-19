using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationScript : MonoBehaviour
{
    [SerializeField] private GameObject shopUI;
    [SerializeField] private PlayerController playerConRef;

    void Start()
    {
        playerConRef = GameObject.Find("Space Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            shopUI.SetActive(true);
            playerConRef.AtShop = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player")
        {
            shopUI.SetActive(false);
            playerConRef.AtShop = false;
        }
    }
}
