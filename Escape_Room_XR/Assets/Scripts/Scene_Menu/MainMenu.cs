using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject player;
    public void PlayGame()
    {
        DataSaving data = SaveSystem.LoadPlayer();
        Vector3 position;

        if (data == null)
        {
            SceneManager.LoadScene(1);


        }
        else
        {
            SceneManager.LoadScene(1);

            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];
            player.transform.position = position;
        }
        Debug.Log("Play");
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
