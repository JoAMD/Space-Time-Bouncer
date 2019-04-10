using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.y > 0.1f)
        {
            transform.localScale -= new Vector3(0, 0.1f, 0);
        }
    }
}
