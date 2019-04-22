using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private GameObject player;

    public AudioClip shotgun;
    public AudioSource source;

    private float firerate = 0.83f;
    private float nextTimeToShoot = 0f;

    public float health = 5f;

    public GameObject impact;

    private NavMeshAgent navMeshAgent;

    private GunMechanics g;

    public int i = 0, n = 10;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        g = new GunMechanics(transform, shotgun, source, firerate, impact);
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(i % n == 0)
        //{
        //transform.LookAt(player.transform.position + new Vector3(Random.Range(-1, 1), player.transform.position.y, Random.Range(-1, 1)), Vector3.up);
        //}
        //++i;


        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10f * Time.deltaTime);

        if (i % 10 == 0 && Vector3.Distance(transform.position,player.transform.position) > 3f)
        {
            float offset = Random.Range(3f, 4f);
            navMeshAgent.SetDestination(player.transform.position + new Vector3(offset, 0, offset));
        }
        ++i;

        if (Time.time > nextTimeToShoot)
        {
            g.shoot();
            nextTimeToShoot = Time.time + 1 / firerate + Random.Range(0f, 1f);
        }
    }
}
