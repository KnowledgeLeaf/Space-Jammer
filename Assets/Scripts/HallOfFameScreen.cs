using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HallOfFameScreen : MonoBehaviour
{

    public HallOfFame HOF;
    [SerializeField] private TMPro.TextMeshProUGUI[] Names;
    [SerializeField] private TMPro.TextMeshProUGUI[] Scores;
    [SerializeField] private InputName Name;
    [SerializeField] private ScoreIndicator theScore;
    private int m_score;

    void Start()
    {
        m_score = theScore.ScoreUpdate;

        for(int i = 0; i < 10; i++)
        {
            if(m_score > HOF.Best_Time[i])
            {
                for(int f = 9; f > i; f--)
                {
                    HOF.Best_Time[f] = HOF.Best_Time[f-1];
                    HOF.Name[f] = HOF.Name[f-1];
                }

                HOF.Best_Time[i] = m_score;
                HOF.Name[i] = Name.m_nameinput;
                break;
            }
        }

        for(int i = 0; i < 10; i++)
        {
            Names[i].text = HOF.Name[i];
            Scores[i].text = HOF.Best_Time[i].ToString();
        }
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("TheGame");
        }
    }
}
