using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;
using UnityEngine.SceneManagement;

public class PlayerAgent : Agent
{

    private Rigidbody playerRigidbody;
    private float journeyLength = 0.5f, speed = 10f;
    private int i = 0, n = 10, size;
    private Vector3[] positions = new Vector3[3000];
    public bool firstEntry = true;
    public float fraction;
    public int portal = 0;
    public GameObject pastPlayer;
    private PastPlayerController pastPlayerController;

    private bool redMode;

    public GameObject pressurePad, goal, bridge;

    public Transform ground, ground1;


    public override void InitializeAgent()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        pastPlayerController = pastPlayer.GetComponent<PastPlayerController>();
        redMode = SceneManager.GetActiveScene().name.Equals("Red Mode Level 1");
    }

    // Update is called once per frame
    void Update()
    {
        SetReward(-0.0001f); //existenstial penalty
        if(transform.position.y <= 0.9f)
        {
            SetReward(-0.1f);
            Done();
        }

        //transform.rotation = Quaternion.identity;
        playerRigidbody.velocity = new Vector3(0, playerRigidbody.velocity.y, 0);

        //playerRigidbody.velocity = Vector3.zero;

        if (portal == 1)
        {
            if (firstEntry)
            {
                firstEntry = false;
                if (i % n == 0)
                {
                    positions[i / n] = transform.position;
                    size = i / n;
                }
                else
                {
                    positions[(i / n) + 1] = transform.position;
                    size = (i / n) + 1;
                }
                pastPlayerController.positions = this.positions;
                pastPlayerController.size = this.size;
                pastPlayer.SetActive(true);
            }
        }
        else if (portal == 0 && i % n == 0)
        {
            positions[i / n] = transform.position;
        }
        i++;

    }


    public override void AgentAction(float[] vectorAction, string textAction)
    {
        float X = Mathf.Clamp(vectorAction[0], -1, 1);
        float Z = Mathf.Clamp(vectorAction[1], -1, 1);

        Vector3 axis = new Vector3(X, 0, Z);
        transform.position = Vector3.Lerp(transform.position, transform.position + axis * journeyLength, speed * Time.deltaTime);
    }

    public override void CollectObservations()
    {
        AddVectorObs((pressurePad.transform.position.x - transform.position.x) / 17f);// 16f);
        AddVectorObs((pressurePad.transform.position.z - transform.position.z) / 10f);// 9f);

        AddVectorObs((goal.transform.position.x - transform.position.x) / 19f);// 18f);
        AddVectorObs((goal.transform.position.z - transform.position.z) / 6f);// 5f);

        AddVectorObs((bridge.transform.position.x - transform.position.x) / 16.5f);// 15.5f);
        AddVectorObs((bridge.transform.position.z - transform.position.z) / 11f);// 10f);

        AddVectorObs(bridge.activeSelf);

        float[] a = { 4.5f - transform.position.z, transform.position.z + 4.5f, 4.5f - transform.position.x, transform.position.x + 17.5f }; 
        ArrayList distancesFromEdge = new ArrayList();
        distancesFromEdge.AddRange(a);
        distancesFromEdge.Sort();    

        AddVectorObs((float)(distancesFromEdge[0]));
        Debug.Log((float)(distancesFromEdge[0]));
    }

    public override void AgentReset()
    {
        //ResetParameters r = new ResetParameters(); //?????????
        bridge.SetActive(false);
        transform.position = ground.position + new Vector3(4, 1, 0);
        pressurePad.transform.position = ground.position + new Vector3(Random.Range(-4, 4), 0.6f, Random.Range(-4, 4));
        goal.transform.position = ground1.position + new Vector3(Random.Range(-4, 4), 0.6f, Random.Range(-4, 4));
    }

}