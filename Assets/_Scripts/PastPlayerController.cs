using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastPlayerController : MonoBehaviour
{
    public Vector3[] positions = new Vector3[3000];
    private int j = 0;
    public float fraction;
    public int portal = 0, size;
    public Transform player;
    private bool firstTimeinIfStmt = true;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (portal == 1)
        {
            if (firstTimeinIfStmt)
            {
                firstTimeinIfStmt = false;
                //GameObject.Find("Directional Light").GetComponent<Light>().color = Color.cyan;
            }
            transform.position = Vector3.Lerp(positions[j], positions[j + 1], fraction);
            fraction += 0.086f;
            if (fraction >= 1)
            {
                fraction = 0;
                j++;
                if (j >= size - 1)
                {
                    portal++;
                    Destroy(gameObject);
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Animation (Particle system Explosion)
            GameObject explosionGameObject = Instantiate(explosion, player.position, Quaternion.identity);
            Destroy(explosionGameObject, 2);

            //Rewind
            j = 0;
            player.position = positions[size];
        }
    }
}
