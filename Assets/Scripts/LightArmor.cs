using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightArmor : MonoBehaviour
{
    private LifeState life;
    private SpeedMod speed;

    private int m_lifeMod = 5;
    private int m_speedMod = 2;

    // Start is called before the first frame update
    void Start()
    {
        life = transform.root.GetComponent<LifeState>();
        speed = transform.root.GetComponent<SpeedMod>();

        life.PlayerHealthMod = life.PlayerHealthMod - m_lifeMod;
        speed.Speed = speed.Speed * m_speedMod;
    }
}
