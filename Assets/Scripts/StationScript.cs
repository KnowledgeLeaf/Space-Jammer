using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class StationScript : MonoBehaviour
{
    [SerializeField] private GameObject shopUI;
    [SerializeField] private PlayerController playerConRef;
    private IObjectPool<StationScript> _pool;

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

    public GameObject ShopUI
    {
        set { shopUI = value; }
    }

    public void SetPool(IObjectPool<StationScript> pool) => _pool = pool;

    public void PoolRelease()
    {
        if(_pool!= null)
        {
            _pool.Release(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void InitializeStation()
    {

    }
}
