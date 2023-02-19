using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreIndicator : MonoBehaviour
{
    private int m_score = 0;
    private TMPro.TextMeshProUGUI TextBox;

    void Start()
    {
        TextBox = GetComponent<TMPro.TextMeshProUGUI>();
    }

    void Update()
    {
        TextBox.text = "Score: " + m_score;
    }

    public int ScoreUpdate
    {
        get{return m_score;}
        set{m_score = value;}
    }
}
