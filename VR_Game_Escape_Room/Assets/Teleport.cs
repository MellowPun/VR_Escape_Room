using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public GameObject player;
    
    public void TeleportPlayer(GameObject target)
    {
        

        player.transform.position = new Vector3(target.transform.position.x,target.transform.position.y+1f,target.transform.position.z) ;

    }
}
