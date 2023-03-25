using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ScoreIndicator theScore;
    private bool m_bossDead = false;
    [SerializeField] private MainMenu mainMenu;

    private void Start()
    {
        mainMenu = GameObject.Find("UI").transform.GetChild(0).gameObject.GetComponent<MainMenu>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mainMenu.ToggleMainMenu();
        }
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
