using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class SpaceTimeAcademy : Academy
{
    public GameObject game;
    private int config = 0; // wide bridge

    public override void AcademyReset()
    {
        if(config == 1)     //narrow bridge
        {
            GameObject[] bridges = GameObject.FindGameObjectsWithTag("Bridge");
            foreach (var bridge in bridges)
            {
                bridge.transform.localScale = new Vector3(3, 1, 1);
            }
            //add modified component too
        }
        else if(config == 2)    //pressure pad
        {

        }
        else if(config == 3)    //finale
        {

        }
    }

}
