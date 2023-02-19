using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject playerRef;
    private PlayerController playerConRef;
    private LifeState playerLifeRef;
    [SerializeField] private TMPro.TextMeshProUGUI[] Stats;
    [SerializeField] private TMPro.TextMeshProUGUI[] Cargo;
    private int m_cargoValue = 10;
    
    private void Start()
    {
        playerConRef = playerRef.GetComponent<PlayerController>();
        playerLifeRef = playerRef.GetComponent<LifeState>();
    }
    void Update()
    {
        Stats[0].text = "Max Health: " + playerLifeRef.DefaultHealth * playerLifeRef.PlayerHealthMod;
        Stats[1].text = "Current Health: " + playerLifeRef.Health;
        Stats[2].text = "Damage: " + playerConRef.Damage;
        Stats[3].text = "Max Speed: " + playerConRef.MaxSpeed;
        Stats[4].text = "Boost Multiplier: " + playerConRef.BoostMultiplier;
        Stats[5].text = "Shot Cooldown: " + playerConRef.ShotCooldown;
        Stats[6].text = "Turn Speed: " + playerConRef.TurnSpeed;

        Cargo[0].text = "Misc Loot: " + playerConRef.CargoHold;
        Cargo[1].text = "Space Credits: " + playerConRef.Money;
    }

    public void EmptyCargoHold()
    {
        playerConRef.CargoHold = 0;
    }

    public void SellCargoHold()
    {
        playerConRef.Money += (playerConRef.CargoHold * m_cargoValue);
        playerConRef.CargoHold = 0;
    }
}
