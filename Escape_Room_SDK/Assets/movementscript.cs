using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class movementscript : MonoBehaviour
{
    NavMeshAgent agent;
    Coroutine _CheckForMovement;
    [SerializeField] GameObject activeObject;
    Vector3 sizeObject;

    int X = 1;
    Vector3 newpos;
    Vector3 oldpos;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        oldpos = this.gameObject.transform.position;
        _CheckForMovement = StartCoroutine(checkPosition());
        sizeObject = activeObject.GetComponent<BoxCollider>().size;

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    IEnumerator checkPosition()
    {
        while (true)
        {
            yield return new WaitForSeconds(X);
            newpos = this.gameObject.transform.position;
            //Debug.Log(newpos);

            if (oldpos == newpos)
            {
                Debug.Log("Player remained idle");
                activeObject.GetComponent<BoxCollider>().size = new Vector3(1,1,1);
            }
            else if (oldpos != newpos)
            {
                Debug.Log("Player moved");
                activeObject.GetComponent<BoxCollider>().size = sizeObject;

            }

            oldpos = newpos;
        }
    }
}
