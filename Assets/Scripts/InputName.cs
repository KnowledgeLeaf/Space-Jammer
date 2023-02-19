using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputName : MonoBehaviour
{

    public string m_nameinput;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    public void Input()
    {
        if(GetComponent<TMP_InputField>().text.Length < 4)
        {
            m_nameinput = GetComponent<TMP_InputField>().text;
            Time.timeScale = 1f;
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Name Input Not Valid");
        }
    }

}
