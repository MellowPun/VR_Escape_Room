using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void Main()
    {
        SceneManager.LoadScene(0);
        Debug.Log("MainMenu");
    }
    public void Save()
    {
        Debug.Log("Save");


    }

    public void OnApplicationQuit()
    {
        Application.Quit();
        Debug.Log("Quit");

    }

}
