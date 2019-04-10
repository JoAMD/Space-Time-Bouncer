using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRigidbody;
    public float speed = 0.01f;
    public float journeyLength = 0.1f;
    private int i = 0, n = 10, size;
    private Vector3[] positions = new Vector3[3000];
    public bool firstEntry = true;
    public float fraction;
    public int portal = 0;
    public GameObject pastPlayer;
    private PastPlayerController pastPlayerController;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        pastPlayerController = pastPlayer.GetComponent<PastPlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.rotation = Quaternion.identity;
        playerRigidbody.velocity = new Vector3(0, playerRigidbody.velocity.y, 0);

        //playerRigidbody.velocity = Vector3.zero;

        if (portal == 1)
        {
            if (firstEntry)
            {
                firstEntry = false;
                if(i % n == 0)
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


        //transform.rotation = Quaternion.identity;

        /*
        if (Input.GetKeyUp(KeyCode.W))// || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            startTime = Mathf.Infinity;
            now = 'N';
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            now = 'W';
            startTime = Time.time;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            now = 'S';
            startTime = Time.time;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            now = 'A';
            startTime = Time.time;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            now = 'D';
            startTime = Time.time;
        }
        */

        if (Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("Space");
            Vector3 explosionPos = transform.position;
            explosionPos.y -= 1f;
            playerRigidbody.AddExplosionForce(100f, explosionPos, 1f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            //Debug.Log("W");
            //playerRigidbody.velocity = new Vector3(0, 0, 2.5f);

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0, 0, journeyLength), 50f * Time.deltaTime);
            
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //Debug.Log("S");
            //playerRigidbody.velocity = new Vector3(0, 0, -2.5f);
           
            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0, 0, -journeyLength), 50f * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("A");
            //playerRigidbody.velocity = new Vector3(-2.5f, 0, 0);

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(-journeyLength, 0, 0), 50f * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("D");
            //playerRigidbody.velocity = new Vector3(2.5f, 0, 0);
            
            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(journeyLength, 0, 0), 50f * Time.deltaTime);
            
        }
    }
}
