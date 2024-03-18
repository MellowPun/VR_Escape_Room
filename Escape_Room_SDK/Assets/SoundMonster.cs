using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SoundMonster : MonoBehaviour
{
    NavMeshAgent _Agent;
    [SerializeField] GameObject _Player;
    [SerializeField] LayerMask _GroundLayer, _PlayerLayer;
    [SerializeField] float walkRange = 100;
    [SerializeField] float destinationRange = 2;
    private Vector3 destPoint;
    private bool walkPointSet = false;
    private bool triggersFound = false;
    GameObject triggers;
    Vector3 triggersDest;

    // Start is called before the first frame update
    void Start()
    {
        _Agent = GetComponent<NavMeshAgent>();


    }

    // Update is called once per frame
    void Update()
    {
        if (!walkPointSet && !triggersFound)
        {
            SearchForDest();
        }
        else
        {

            if (walkPointSet && !triggersFound)
            {
                _Agent.SetDestination(destPoint);
                if (Vector3.Distance(transform.position, destPoint) < destinationRange)
                {
                    walkPointSet = false;
                }

            }
            else
            {
                if (walkPointSet && triggersFound)
                {
                    _Agent.SetDestination(triggersDest);
                }
            }
        }




    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("LightColliding");

        triggers = other.gameObject;


        if (triggers.CompareTag("SoundRange"))
        {
            Debug.Log("Sound");
            triggersFound = true;
            triggersDest = triggers.transform.parent.position;

        }
        if (triggers.CompareTag("Player"))
        {
            Debug.Log("You lose");
            triggersDest = triggers.transform.position;

            triggersFound = true;

        }
        

    }


    private void OnTriggerExit(Collider other)
    {
        triggersFound = false;
        walkPointSet = false;

    }
    
    void SearchForDest()
    {
        float z = Random.Range(-walkRange, walkRange);
        float x = Random.Range(-walkRange, walkRange);
        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if (Physics.Raycast(destPoint, Vector3.down, _GroundLayer))
        {
            walkPointSet = true;
        }
    }
}
