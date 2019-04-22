using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePadLiftController : MonoBehaviour
{
    public Transform lift;
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Past Player"))
        {
            lift.GetComponent<LiftController>().enabled = false;
            if(lift.localScale.y < 9)
            {
                lift.localScale += new Vector3(0, 0.1f, 0);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Past Player"))
        {
            lift.GetComponent<LiftController>().enabled = true;
        }
    }
}
