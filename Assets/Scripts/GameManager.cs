using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ScoreIndicator theScore;
    private bool m_bossDead = false;

    private void Update()
    {
        
    }

    public GameObject HOFPanel;
    public void DisplayHallOfFame()
    {
        HOFPanel.SetActive(true);
    }

    public bool BossDead
    {
        get{return m_bossDead;}
        set{m_bossDead = value;}
    }
}
