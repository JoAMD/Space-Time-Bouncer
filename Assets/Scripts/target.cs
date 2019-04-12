using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public float health = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeHealth(float damage)
    {
        health--;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
