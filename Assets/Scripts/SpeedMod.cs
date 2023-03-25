using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedMod : MonoBehaviour
{
    [SerializeField] private float m_Speed = 3;
    [SerializeField] private float m_SpeedMultiplier = 2;
    private float m_maxSpeed;

    private void Start()
    {
        m_maxSpeed = m_Speed * m_SpeedMultiplier;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            m_maxSpeed *= m_SpeedMultiplier;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            m_maxSpeed /= m_SpeedMultiplier;
        }
    }

    public float Speed
    {
        get{ return m_Speed; }
        set { m_Speed = value; }
    }
    public float SpeedMultiplier
    {
        get { return m_SpeedMultiplier; }
        set { m_SpeedMultiplier = value; }
    }
    public float MaxSpeed
    {
        get { return m_maxSpeed; }
        set { m_maxSpeed = value; }
    }
}
