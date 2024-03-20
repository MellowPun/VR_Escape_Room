using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Filtering;

public class DoorButton : MonoBehaviour
{
    public GameObject door;
    bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x=> OpenDoor());
    }

    
    public void OpenDoor()
    {
        isOpen= !isOpen;
        if(isOpen)
        {
            door.transform.position = new Vector3(door.transform.position.x, door.transform.position.y + 2f, door.transform.position.z);
        }
        if(!isOpen)
        {
            door.transform.position = new Vector3(door.transform.position.x, door.transform.position.y - 2f, door.transform.position.z);

        }
    }
}
