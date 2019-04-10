using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControllerNavMeshAgent : MonoBehaviour
{

    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
//            Debug.Log("Space");
//            agent.GetComponent<Rigidbody>().AddExplosion
        }
        if (Input.GetKey(KeyCode.W))
        {
            //Debug.Log("W");
            agent.SetDestination(new Vector3(agent.transform.position.x, agent.transform.position.y, agent.transform.position.z + agent.radius));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //Debug.Log("S");
            agent.SetDestination(new Vector3(agent.transform.position.x, agent.transform.position.y, agent.transform.position.z - agent.radius));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("A");
            agent.SetDestination(new Vector3(agent.transform.position.x - agent.radius, agent.transform.position.y, agent.transform.position.z));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("D");
            agent.SetDestination(new Vector3(agent.transform.position.x + agent.radius, agent.transform.position.y, agent.transform.position.z));
        }
    }
}
