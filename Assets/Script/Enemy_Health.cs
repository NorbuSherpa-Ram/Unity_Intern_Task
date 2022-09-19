using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy_Health : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public GameObject deathEffect;
    public List<GameObject > itemsToSpown;
     int itemIndex;
    Vector3 offSets;

    private void OnEnable()
    {
        Bullet.onBulletHit  += TakeDamage;
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(GameObject collidedObj,int damage )
    {
        if (collidedObj != this.gameObject)
            return;

        currentHealth -= damage;
        if(currentHealth<=0)
        {
            SpawnItems();
            AudioManager.instance.PlaySound("death");
            Destroy(this.gameObject );
        }
    }
    void SpawnItems()
    {
        itemIndex = UnityEngine.Random.Range(0, itemsToSpown.Count);
        offSets = transform.position + new Vector3(UnityEngine.Random.Range(0, 1), UnityEngine.Random.Range(0, 1), 0);
        Instantiate(itemsToSpown[itemIndex], offSets, Quaternion.identity);
        Instantiate(deathEffect , offSets, Quaternion.identity);
    }
    private void OnDisable()
    {
        Bullet.onBulletHit -= TakeDamage;
    }
}
