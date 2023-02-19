using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private float m_turnMovement;
    private float m_forwardMovement;
    [SerializeField] private float m_acceleration;
    private static int m_DefaultSpeed = 3;
    private int maxSpeed = 6;
    private static int m_DefaultTurnSpeed = 1;
    private int m_turnSpeed;
    private Rigidbody2D m_rigidbody;
    private bool m_playerDead = false;
    [SerializeField] private GameObject booletPrefab;
    private float m_shotTimer;
    private float m_shotCooldown = 0.3f;
    public Animator animator;
    [SerializeField] private AudioSource m_soundModule;
    [SerializeField] private AudioClip[] pewSound;
    [SerializeField] private AudioClip[] playerBumpSound;
    [SerializeField] private bool m_shieldsUp = false;
    [SerializeField] private int m_cargo;
    private int m_damage = 1;
    private float m_boostMultiplier = 1.5f;
    [SerializeField] private GameObject inventory;
    private bool m_inventoryOpen = false;
    private bool m_atShop;
    private int m_spaceCredits = 100;

    void Awake()
    {
        m_turnSpeed = m_DefaultTurnSpeed;
    }
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        animator.SetFloat("Turning", Mathf.Abs(m_turnMovement));
        animator.SetFloat("Thrusting", Mathf.Abs(m_forwardMovement));
        
        if(Mathf.Abs(m_turnMovement) > 0.01f)
        {
            m_shieldsUp = true;
        }
        else
        {
            m_shieldsUp = false;
        }

        if(Input.GetKey(KeyCode.LeftShift)) {
            m_acceleration = m_DefaultSpeed * m_boostMultiplier;
        }
        else {
            m_acceleration = m_DefaultSpeed;
        }

        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(m_shieldsUp != true)
        {
            if(m_shotTimer <= 0)
            {
                if(Input.GetKey(KeyCode.Space))
                {
                    Instantiate(booletPrefab, transform.position, transform.rotation);
                    m_shotTimer = m_shotCooldown;
                    int a = Random.Range(0,3);
                    m_soundModule.clip = pewSound[Random.Range(0,pewSound.Length)];
                    m_soundModule.Play();
                }
            }
            else
            {
                m_shotTimer -= Time.deltaTime;
            }
        }
         if(Input.GetKeyDown(KeyCode.E))
         {
            if(Time.timeScale != 0f)
            {
                if(m_inventoryOpen == false)
                {
                    inventory.SetActive(true);
                    m_inventoryOpen = true;
                }
                else
                {
                    inventory.SetActive(false);
                    m_inventoryOpen = false;
                }
            }
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
           if(m_rigidbody.velocity.magnitude > maxSpeed && m_forwardMovement > 0.01)
           {
                m_rigidbody.velocity = m_rigidbody.velocity.normalized * maxSpeed;
           }
           else if(m_rigidbody.velocity.magnitude > (maxSpeed / 2) && m_forwardMovement < -0.01)
           {
                m_rigidbody.velocity = m_rigidbody.velocity.normalized * (maxSpeed / 2);
           }
        }
        Debug.Log(m_rigidbody.velocity.magnitude);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(m_shieldsUp == false)
        {
            if (m_rigidbody.velocity.magnitude >= maxSpeed/2)
            {
                m_soundModule.clip = playerBumpSound[Random.Range(0, playerBumpSound.Length)];
                m_soundModule.Play();
                GetComponent<LifeState>().TakeDamage(m_damage);
            }
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
    public int MaxSpeed
    {
        get { return maxSpeed;}
        set {maxSpeed = value;}
    }
    public float BoostMultiplier
    {
        get { return m_boostMultiplier;}
        set {m_boostMultiplier = value;}
    }
    public float ShotCooldown
    {
        get { return m_shotCooldown;}
        set { m_shotCooldown = value;}
    }
    public int TurnSpeed
    {
        get { return m_turnSpeed;}
        set { m_turnSpeed = value;}
    }
    public bool Shield
    {
        get { return m_shieldsUp;}
        set { m_shieldsUp = value;}
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
}
