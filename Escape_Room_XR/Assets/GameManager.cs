using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    private static GameManager Instance;
    private static object safetyLock = new object();

    private GameManager() { }

    public static GameManager GetInstance()
    {
        if (Instance == null)
        {
            lock (safetyLock)
            {
                if (Instance == null)
                {
                    Instance = new GameManager();
                }
            }
        }
        return Instance;
    }
    
    
    public void SavePlayerPosition()
    {
        SaveSystem.SavePlayer(player);
    }
    public void LoadPlayerPosition()
    {
        SceneManager.LoadScene(1);
        DataSaving data = SaveSystem.LoadPlayer();
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        player.transform.position = position;


    }

}
