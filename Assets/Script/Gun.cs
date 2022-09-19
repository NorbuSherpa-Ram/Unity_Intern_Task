using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{


    public GameObject bullet;
    public GameObject muzzleFlashEffect;
    public GameObject muzzleFlashPoint;
    public Transform[]  firePoint ;
    private void Update()
    {
        GunLookAtDirection();

        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

       FlipGunDirection();
    }

    void GunLookAtDirection()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
    }
    void Shoot()
    {
        // Instantiate(bullet, firePoint.position, firePoint.rotation );
        AudioManager.instance.PlaySound("gun");

        Instantiate(bullet, firePoint[0].position, firePoint[0].rotation );
        Instantiate(bullet, firePoint[1].position, firePoint[1].rotation );
        Instantiate(bullet, firePoint[2].position, firePoint[2].rotation );

        MuzzleFlash();
    }
    void MuzzleFlash()
    {
        GameObject muzzel = Instantiate(muzzleFlashEffect, muzzleFlashPoint.transform .position, muzzleFlashPoint.transform.rotation);
        muzzel.transform.parent= muzzleFlashPoint.transform ;
    }
    void FlipGunDirection()
    {
        Vector3 charecterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            charecterScale.x = -1;
            charecterScale.y = -1;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            charecterScale.x = 1;
            charecterScale.y= 1;
        }
        transform.localScale = charecterScale;
    }
}
