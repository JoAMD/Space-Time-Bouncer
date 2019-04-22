using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePadMLController : MonoBehaviour
{
    public GameObject bridge;
    public PlayerAgent playerAgent;
    private bool rewardDone = false;
    public Transform ground;
    private float prevDist = Mathf.Infinity;

    public GameObject game;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Past Player"))
        {
            bridge.SetActive(true);
            
            playerAgent.SetReward(+0.17f);
            rewardDone = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Past Player"))
        {
            bridge.SetActive(false);
            Instantiate(bridge, game.transform.position, Quaternion.identity, game.transform);
        }
    }

    private void Update()
    {
        /*
        if(first && Vector3.Distance(transform.position, playerAgent.transform.position) < 2f)
        {
            playerAgent.SetReward(+0.03f);
            first = false;
        }
        */
        if (!rewardDone)
        {
            if (Vector3.Distance(transform.position, playerAgent.transform.position) < prevDist)
            {
                playerAgent.SetReward(+0.004f);
                prevDist = Vector3.Distance(transform.position, playerAgent.transform.position);
            }
            else
            {
                playerAgent.SetReward(-0.008f); //decrease...
                prevDist = Vector3.Distance(transform.position, playerAgent.transform.position);
            }
        }  
    }

}
