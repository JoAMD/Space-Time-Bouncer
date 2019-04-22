using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.position = Vector3.Slerp(transform.position, transform.)
            //transform.rotation = transform.rotation * Quaternion.AngleAxis(45, Vector3.up);//, Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //transform.rotation = Quaternion.Slerp(transform.rotation, transform.rotation * Quaternion.AngleAxis(-45, Vector3.up), Time.deltaTime * 20);
        }
    }
}
