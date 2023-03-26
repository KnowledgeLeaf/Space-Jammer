using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GiveModule : MonoBehaviour
{
    [SerializeField] private GameObject modulePrefab;
    private PlayerController playerRef;

    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void GiveTheModule()
    {
        if (playerRef.Money >= 100)
        {
            playerRef.Money -= 100;

            switch (modulePrefab.tag)
            {
                case "WeaponModule":
                    for (int i = 0; i < playerRef.WeaponModule.transform.childCount; i++)
                    {
                        Destroy(playerRef.WeaponModule.transform.GetChild(i).gameObject);
                    }
                    Instantiate(modulePrefab, playerRef.WeaponModule.transform);
                    break;

                case "PickupModule":
                    for (int i = 0; i < playerRef.PickupModule.transform.childCount; i++)
                    {
                        Destroy(playerRef.PickupModule.transform.GetChild(i).gameObject);
                    }
                    Instantiate(modulePrefab, playerRef.PickupModule.transform);
                    break;

                case "ShieldModule":
                    for (int i = 0; i < playerRef.ShieldModule.transform.childCount; i++)
                    {
                        Destroy(playerRef.ShieldModule.transform.GetChild(i).gameObject);
                    }
                    Instantiate(modulePrefab, playerRef.ShieldModule.transform);
                    break;

                case "HullModule":
                    for (int i = 0; i < playerRef.HullModule.transform.childCount; i++)
                    {
                        Destroy(playerRef.HullModule.transform.GetChild(i).gameObject);
                    }
                    Instantiate(modulePrefab, playerRef.HullModule.transform);
                    break;

                case "ThrusterModule":
                    for (int i = 0; i < playerRef.ThrusterModule.transform.childCount; i++)
                    {
                        Destroy(playerRef.ThrusterModule.transform.GetChild(i).gameObject);
                    }
                    Instantiate(modulePrefab, playerRef.ThrusterModule.transform);
                    break;

                default:
                    break;
            }
        }
    }

    public GameObject ChangeModule
    {
        get { return modulePrefab; }
        set { modulePrefab = value; }
    }
}
