using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotatingCameraController : MonoBehaviour
{
    public Rigidbody rb;
    //public new ConstantForce constantForce;
    public Quaternion tangentialRotation;
    private float /*i = 0,*/ multiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(this.transform.position.z > -15)
        //{
        //    this.transform.position = new Vector3(0, 6, -9 + i);
        //    i -= 0.05f;
        //}
        //Vector3 radial = transform.up + transform.forward;//= new Vector3(0, transform.position.y, 0) - transform.position;
        //tangentialRotation = Quaternion.Euler(radial) * Quaternion.Euler(0, 90, 0);
        Vector3 tangentialVelocity = transform.right * 500f * multiplier;//tangentialRotation * radial;
        if(multiplier < 10)
        {
            multiplier /= 1.01f;
        }
        rb.velocity = tangentialVelocity;
        //Debug.Log(radial);

        //Vector3 centripetalForce = -radial * Mathf.Pow(tangentialVelocity.magnitude, 2) / 9.81f;
        //constantForce.force = centripetalForce;
       
    }
}
