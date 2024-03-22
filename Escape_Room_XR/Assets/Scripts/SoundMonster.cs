using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

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
    [SerializeField] bool drawGizmo = false;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        _Agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(walkPointSet + " " + triggersFound);
        if (!walkPointSet && !triggersFound)
        {
            SearchForDest();
        }
        else
        {
            if (_Agent.pathStatus == NavMeshPathStatus.PathInvalid || _Agent.pathStatus == NavMeshPathStatus.PathPartial)
            {
                SearchForDest();
            }
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
            SceneManager.LoadScene(1);
            DataSaving data = SaveSystem.LoadPlayer();
            Vector3 position;
            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];
            triggers.transform.position = position;

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

    private void OnDrawGizmos()
    {
        if (drawGizmo)
        {
            Gizmos.DrawSphere(gameObject.transform.position, walkRange);

        }
    }
}
