using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Animator animator;

    public float range = 40f;
    public float impactForce = 150f;
    public int damageAmount = 20;

    public Transform FPS;

    public float FireRate = 10f;
    private float NextTimeToFire = 0;

    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    private bool isShooting = false;



    private void Start()
    {
        muzzleFlash.Stop();
    }
    private void Update()
    {
        animator.SetBool("isShooting", isShooting);
        if (Input.GetKeyDown(KeyCode.Q) && !isShooting && Time.time >= NextTimeToFire)
        {
            isShooting = true;
            NextTimeToFire = Time.time + 1f / FireRate;
            Shoot();
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            StopShooting();
        }

    }

    private void Shoot()
    {
        AudioManager.instance.Play("Shoot");

        RaycastHit hit;
        muzzleFlash.Play();
        if (Physics.Raycast(FPS.transform.position, FPS.transform.forward, out hit, range))
        {
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            Enemy e = hit.transform.GetComponent<Enemy>();
            if(e!= null)
            {
                e.TakeDamage(damageAmount);
                return;
            }

            Quaternion impactRotation = Quaternion.LookRotation(hit.normal);
            GameObject impact =  Instantiate(impactEffect, hit.point, impactRotation);
            impact.transform.parent = hit.transform;
            Destroy(impact, 5);
        }
        Invoke("Shoot", 1f / FireRate);
    }

    private void StopShooting()
    {
        isShooting = false;
        muzzleFlash.Stop();
        CancelInvoke("Shoot");
    }

}
