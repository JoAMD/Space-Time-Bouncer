using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public PlayerController playerController;
    public PastPlayerController pastPlayerController;
    /*
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collide with Player!!");
        }
    }
    */
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
            playerController.portal++;
            pastPlayerController.portal++;
            Debug.Log("Collide with some Player!!");
        }
    }
}
