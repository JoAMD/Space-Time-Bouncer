using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleHingeJointController : MonoBehaviour
{
    private float i = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(0, i, 0);
        i += 0.05f;
        //gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 20, 0);
        //GetComponent<Rigidbody>().AddForce(0, 500f * Time.deltaTime, 0);
    }
}
