using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullet : MonoBehaviour
{
    public static event Action<GameObject, int> onBulletHit;


    public Rigidbody2D bulletRb;
    public int damage = 1;
    public float speed=10f;
    public float delayToDestroy =2f;

    public GameObject bulletDeathEffect;


    void Start()
    {
        bulletRb.velocity = transform.right * speed;
    }

    private void Update()
    {
        Destroy(this.gameObject, delayToDestroy);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        onBulletHit?.Invoke(other.gameObject,damage );
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Bullet"))
        {
            Physics2D.IgnoreCollision(this.gameObject.GetComponent<BoxCollider2D>(), other.gameObject.GetComponent<BoxCollider2D>());
        }
        else
        {
            Instantiate(bulletDeathEffect, this.transform.position , Quaternion.identity);
            Destroy(this.gameObject);
        }

    }

}
