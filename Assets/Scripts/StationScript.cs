using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class StationScript : MonoBehaviour
{
    [SerializeField] private ShopManager shopManager;
    [SerializeField] private GameObject shopUI;
    [SerializeField] private PlayerController playerConRef;
    private IObjectPool<StationScript> _pool;

    void Start()
    {
        shopManager = GameObject.FindGameObjectWithTag("Manager").transform.GetChild(2).gameObject.GetComponent<ShopManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            playerConRef = other.gameObject.GetComponent<PlayerController>();

            playerConRef.inStationRadius = true;
            shopUI.SetActive(true);
            playerConRef.AtShop = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player")
        {
            playerConRef = other.gameObject.GetComponent<PlayerController>();

            playerConRef.inStationRadius = false;
            shopUI.SetActive(false);
            playerConRef.AtShop = false;
        }
    }

    public GameObject ShopUI
    {
        set { shopUI = value; }
        get { return shopUI; }
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
