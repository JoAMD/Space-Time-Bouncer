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

    public PlayerController playerController;

    public EnemyController enemyController;

    /*
    public GunMechanics(AudioClip shotgun, AudioSource source, float firerate, float nextTimeToShoot, GameObject impact) : this(shotgun, source)
    {
        this.firerate = firerate;
        this.nextTimeToShoot = nextTimeToShoot;
        this.impact = impact;
    }
    */
    public GunMechanics(Transform transform, AudioClip shotgun, AudioSource source, float firerate, GameObject impact, PlayerController playerController)
    {
        this.transform = transform;
        this.shotgun = shotgun;
        this.source = source;
        this.firerate = firerate;
        this.impact = impact;
        this.playerController = playerController;
    }
    public GunMechanics(Transform transform, AudioClip shotgun, AudioSource source, float firerate, GameObject impact, EnemyController enemyController)
    {
        this.transform = transform;
        this.shotgun = shotgun;
        this.source = source;
        this.firerate = firerate;
        this.impact = impact;
        this.enemyController = enemyController;
    }
    public void shoot(bool isPlayer)
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position + transform.forward / 10, transform.forward, out hit))
        {
            source.PlayOneShot(shotgun, 0.5f);
            //hit.collider.GetComponent<Renderer>().material.color = Color.white;
            Rigidbody hitRb = hit.rigidbody;
            if (hitRb != null)
            {
                hitRb.AddForceAtPosition( (isPlayer? playerController.transform.forward : enemyController.transform.forward) * 200f, hit.point);
            }

            target target = hit.collider.gameObject.GetComponent<target>();
            Debug.Log(hit.collider.name);
            if (target != null)
            {
                target.takeHealth(1f);
            }
            
            GameObject impactGO = Instantiate(impact, hit.point, (isPlayer ? playerController.transform.rotation * Quaternion.Euler(0, 180, 0) : enemyController.transform.rotation * Quaternion.Euler(0, 180, 0)));
            Destroy(impactGO, 2);
        }
    }

}
