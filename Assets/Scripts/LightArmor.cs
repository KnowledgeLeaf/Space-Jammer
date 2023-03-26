using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightArmor : MonoBehaviour
{
    private LifeState life;
    private SpeedMod speed;
    public string m_name = "Light Armor";

    private int m_lifeMod = 5;
    private int m_speedMod = 6;

    // Start is called before the first frame update
    void Start()
    {
        life = transform.root.GetComponent<LifeState>();
        speed = transform.root.GetComponent<SpeedMod>();

        life.PlayerHealthMod = m_lifeMod;
        life.Health = life.PlayerHealthMod;
        speed.Speed = m_speedMod;
    }
}
