using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] List<GameObject> thingsToToggle;
    [SerializeField] private GameObject optionsMenu;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.0f;

        foreach (GameObject go in thingsToToggle)
        {
            go.SetActive(false);
        }
    }

    public void ToggleOptions()
    {
        if(optionsMenu!= null)
        {
            if(!optionsMenu.activeSelf)
            {
                optionsMenu.SetActive(true);
            }
            else
            {
                optionsMenu.SetActive(false);
            }
        }
    }

    public void QuitGame()
    {
        Debug.Log("Can't Quit In The Editor Silly");
        Application.Quit();
    }
    public void ToggleMainMenu()
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);

            Time.timeScale = 0.0f;

            foreach (GameObject go in thingsToToggle)
            {
                go.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject go in thingsToToggle)
            {
                go.SetActive(true);
            }
            gameObject.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
}
