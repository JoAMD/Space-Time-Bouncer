using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLerpController : MonoBehaviour
{

    public int T;
    public float dT;
    public Transform marker, marker1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(new Vector3(0, 1, 0), new Vector3(0, 1, 10), dT);
        dT += 0.0086f;

    }
}
