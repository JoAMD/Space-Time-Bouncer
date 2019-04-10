using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if( Vector3.Distance(transform.position,player.transform.position) > 3f)
        {
            GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
        }
        
    }
}
