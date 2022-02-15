using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    public Canvas HelpPanel;
    public Canvas MenuPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level 12");
    }

    public void Help()
    {
        MenuPanel.GetComponent<Canvas>().enabled = false;
        HelpPanel.GetComponent<Canvas>().enabled = true;
    }

    public void BackButton()
    {
        MenuPanel.GetComponent<Canvas>().enabled = true;
        HelpPanel.GetComponent<Canvas>().enabled = false;
    }

    public void Quit()
    {
        Application.Quit();
    }

    
}
