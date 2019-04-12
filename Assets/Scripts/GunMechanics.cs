using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMechanics : MonoBehaviour
{
    public AudioClip shotgun;
    public AudioSource source;

    private float firerate = 0.83f;

    public GameObject impact;

    public new Transform transform;

    /*
    public GunMechanics(AudioClip shotgun, AudioSource source, float firerate, float nextTimeToShoot, GameObject impact) : this(shotgun, source)
    {
        this.firerate = firerate;
        this.nextTimeToShoot = nextTimeToShoot;
        this.impact = impact;
    }
    */
    public GunMechanics(Transform transform, AudioClip shotgun, AudioSource source, float firerate, GameObject impact) 
    {
        this.transform = transform;
        this.shotgun = shotgun;
        this.source = source;
        this.firerate = firerate;
        this.impact = impact;
    }
    public void shoot()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position + transform.forward / 10, transform.forward, out hit))
        {
            source.PlayOneShot(shotgun, 0.5f);
            hit.collider.GetComponent<Renderer>().material.color = Color.white;
            Rigidbody hitRb = hit.rigidbody;
            if (hitRb != null)
            {
                hitRb.AddForceAtPosition(-hit.normal * 200f, hit.point);
            }

            target target = hit.collider.gameObject.GetComponent<target>();
            Debug.Log(hit.collider.name);
            if (target != null)
            {
                target.takeHealth(1f);
            }
            
            GameObject impactGO = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2);
        }
    }

}
