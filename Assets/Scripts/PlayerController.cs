using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float m_turnMovement;
    private float m_forwardMovement;
    private float m_acceleration;
    private static int m_DefaultTurnSpeed = 1;
    private int m_turnSpeed;
    private Rigidbody2D m_rigidbody;
    private bool m_playerDead = false;
    public Animator animator;
    [SerializeField] private AudioClip[] playerBumpSound;
    private bool m_turning = false;
    private int m_cargo;
    private int m_damage = 1;
    [SerializeField] private GameObject inventoryUI;
    private bool m_inventoryOpen = false;
    private bool m_atShop;
    private int m_spaceCredits = 100;
    [SerializeField] private AudioSource m_soundModule;
    [SerializeField] private GameObject pickupModule;
    [SerializeField] private GameObject shieldModule;
    [SerializeField] private GameObject weaponModule;
    [SerializeField] private GameObject hullModule;
    [SerializeField] private GameObject thrusterModule;
    private SpeedMod speedStats;
    public bool inStationRadius = true;

    void Awake()
    {
        m_turnSpeed = m_DefaultTurnSpeed;
    }
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        speedStats = GetComponent<SpeedMod>();
    }
    void Update()
    {
        animator.SetFloat("Turning", Mathf.Abs(m_turnMovement));
        animator.SetFloat("Thrusting", Mathf.Abs(m_forwardMovement));
        
        if(Mathf.Abs(m_turnMovement) > 0.01f)
        {
            m_turning = true;
        }
        else
        {
            m_turning = false;
        }

        if(Input.GetKey(KeyCode.LeftShift)) {
            m_acceleration = speedStats.Speed * speedStats.SpeedMultiplier;
        }
        else {
            m_acceleration = speedStats.Speed;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(Time.timeScale != 0f)
            {
                if(m_inventoryOpen == false)
                {
                    inventoryUI.SetActive(true);
                    m_inventoryOpen = true;
                }
                else
                {
                    inventoryUI.SetActive(false);
                    m_inventoryOpen = false;
                }
            }
        }
        if(Input.GetKey(KeyCode.C))
        {
            m_rigidbody.AddForce(-m_rigidbody.velocity / (m_acceleration * 2));
        }
        if(Input.GetKeyDown(KeyCode.M))
        {
            Money += 100000;
        }
        if(Input.GetKeyDown(KeyCode.N))
        {
            GetComponent<LifeState>().Health = 100000;
        }
        if(Input.GetKeyDown(KeyCode.J))
        {
            GetComponent<LifeState>().Health = 1;
            GetComponent<LifeState>().TakeDamage(1);
        }
    }
    void FixedUpdate() 
    {
        if(!m_playerDead)
        {
            m_forwardMovement = Input.GetAxisRaw("Vertical");
            m_turnMovement = Input.GetAxisRaw("Horizontal");

            if(m_forwardMovement > 0.01)
            {
                m_rigidbody.AddForce(transform.up * m_acceleration);
            }
            else if(m_forwardMovement < -0.01)
            {
                m_rigidbody.AddForce(-transform.up * m_acceleration);
            }
            if(Mathf.Abs(m_turnMovement) > 0.01)
            {
                m_rigidbody.AddTorque(-m_turnMovement * m_turnSpeed);
            }
           if(m_rigidbody.velocity.magnitude > speedStats.MaxSpeed && m_forwardMovement > 0.01)
           {
                m_rigidbody.velocity = m_rigidbody.velocity.normalized * speedStats.MaxSpeed;
           }
           else if(m_rigidbody.velocity.magnitude > (speedStats.MaxSpeed / 2) && m_forwardMovement < -0.01)
           {
                m_rigidbody.velocity = m_rigidbody.velocity.normalized * (speedStats.MaxSpeed / 2);
           }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
            if (m_rigidbody.velocity.magnitude >= speedStats.MaxSpeed / 1.2f)
            {
                m_soundModule.clip = playerBumpSound[Random.Range(0, playerBumpSound.Length)];
                m_soundModule.Play();
                GetComponent<LifeState>().TakeDamage(m_damage);
            }
    }

    public bool PlayerDead
    {
        get { return m_playerDead;}
        set {m_playerDead = value;}
    }
    public int CargoHold
    {
        get { return m_cargo;}
        set {m_cargo = value;}
    }
    public int Damage
    {
        get { return m_damage;}
        set {m_damage = value;}
    }
    public int TurnSpeed
    {
        get { return m_turnSpeed;}
        set { m_turnSpeed = value;}
    }
    public bool AtShop
    {
        get { return m_atShop;}
        set { m_atShop = value;}
    }
    public int Money
    {
        get { return m_spaceCredits;}
        set { m_spaceCredits = value;}
    }
    public float AccelerationRate
    {
        get { return m_acceleration;}
        set  {m_acceleration = value;}
    }
    public bool Turning
    {
        get { return m_turning; }
        set { m_turning = value;}
    }
    public GameObject PickupModule
    {
        get { return pickupModule; }
        set { pickupModule = value;}
    }
    public GameObject ShieldModule
    {
        get { return shieldModule; }
        set { shieldModule = value;}
    }
    public GameObject WeaponModule
    {
        get { return weaponModule; }
        set { weaponModule = value;}
    }
    public GameObject HullModule
    {
        get { return hullModule; }
        set { hullModule = value; }
    }
    public GameObject ThrusterModule
    {
        get { return thrusterModule; }
        set { thrusterModule = value; }
    }
}
