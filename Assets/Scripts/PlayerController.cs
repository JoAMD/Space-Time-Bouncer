using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRigidbody;
    public float journeyLength = 0.1f;
    private int i = 0, n = 10, size;
    private Vector3[] positions = new Vector3[3000];
    public bool firstEntry = true;
    public float fraction;
    public int portal = 0;
    public GameObject pastPlayer;
    private PastPlayerController pastPlayerController;

    public AudioClip shotgun;
    public AudioSource source;

    private float firerate = 0.83f;
    private float nextTimeToShoot = 0f;

    public float health = 5f;

    public GameObject impact;
    private float yRotation, xRotation;
    private float currentXRotation;
    private float lookSensitivity = 5f;
    private float xRotationV;
    private float lookSmoothDamp = 0.1f;
    private float currentYRotation;
    private float yRotationV;

    private GunMechanics g;

    public float Xrotation { get; private set; }

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        pastPlayerController = pastPlayer.GetComponent<PastPlayerController>();
        g = new GunMechanics(transform, shotgun, source, firerate, impact);
    }

    // Update is called once per frame
    void Update()
    {

        //transform.rotation = Quaternion.identity;
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
            transform.position = Vector3.Lerp(transform.position, transform.position + (transform.forward * journeyLength)/*new Vector3(0, 0, journeyLength)*/, 50f * Time.deltaTime);
            
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //Debug.Log("S");
            //playerRigidbody.velocity = new Vector3(0, 0, -2.5f);
           
            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(transform.position, transform.position + (transform.forward * -journeyLength), 50f * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("A");
            //playerRigidbody.velocity = new Vector3(-2.5f, 0, 0);

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(transform.position, transform.position + (transform.right * -journeyLength), 50f * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("D");
            //playerRigidbody.velocity = new Vector3(2.5f, 0, 0);
            
            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(transform.position, transform.position + (transform.right * journeyLength), 50f * Time.deltaTime);
            
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //1. transform.position = Vector3.Slerp(transform.position, transform.)
            //2. transform.rotation = transform.rotation * Quaternion.AngleAxis(5, Vector3.up);//, Time.deltaTime);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //1. transform.rotation = Quaternion.Slerp(transform.rotation, transform.rotation * Quaternion.AngleAxis(-45, Vector3.up), Time.deltaTime * 20);
            //2. transform.rotation = transform.rotation * Quaternion.AngleAxis(-5, Vector3.up);
        }

        
        yRotation += Input.GetAxis("Mouse X") * lookSensitivity;
        xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;
        xRotation = Mathf.Clamp(Xrotation, -90, 90);
        currentXRotation = Mathf.SmoothDamp(currentXRotation, xRotation, ref xRotationV, lookSmoothDamp);
        currentYRotation = Mathf.SmoothDamp(currentYRotation, yRotation, ref yRotationV, lookSmoothDamp);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);


        //playerRigidbody.AddForceAtPosition(new Vector3(transform.position.x + (10 * Input.GetAxis("Mouse X")), transform.position.y, transform.position.z + (10 * Input.GetAxis("Mouse Y"))), new Vector3(transform.position.x, transform.position.y + 4, transform.position.z));



        if (Input.GetButton("Fire1") && Time.time > nextTimeToShoot)
        {
            g.shoot();
            nextTimeToShoot = Time.time + 1 / firerate;
        }
        //shoot();
    }

    public void shoot()
    {
        RaycastHit hit;
        source.PlayOneShot(shotgun, 0.5f);
        if (Physics.Raycast(transform.position + transform.forward / 10, transform.forward, out hit))
        {
            Rigidbody hitRb = hit.rigidbody;
            if(hitRb != null)
            {
                hitRb.AddForceAtPosition(-hit.normal * 200f, hit.point);
            }
            hit.collider.gameObject.GetComponent<target>().takeHealth(1f);
            GameObject impactGO = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2);
        }
    }

    
}
