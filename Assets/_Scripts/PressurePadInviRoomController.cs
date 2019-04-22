using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePadInviRoomController : MonoBehaviour
{
    public GameObject bridge, inviRoom;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Past Player"))
        {
            bridge.SetActive(true);
            inviRoom.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Past Player"))
        {
            bridge.SetActive(false);
            inviRoom.SetActive(false);
        }
    }
}
