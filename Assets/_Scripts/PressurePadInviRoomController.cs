using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePadInviRoomController : MonoBehaviour
{
    public GameObject inviRoom;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Past Player"))
        {
            inviRoom.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Past Player"))
        {
            inviRoom.SetActive(false);
        }
    }
}
