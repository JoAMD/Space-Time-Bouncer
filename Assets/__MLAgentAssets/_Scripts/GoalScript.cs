using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public PlayerAgent playerAgent;
    public Transform ground1;
    private bool rewardDone = false;
    private float prevDist = Mathf.Infinity;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerAgent.SetReward(+1.0f);
            rewardDone = true;
            playerAgent.Done();
        }
    }

    private void Update()
    {

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
