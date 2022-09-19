using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public Image[] heart;

    public GameObject deathEffect;
    public Vector3 offset = new Vector2(.5f, 0);
    // total number of unlocked heart that mean if this value is 1 then only one heart will visibe on the screen 
    public int numOfHearts = 3;

    //Currently how much heart you have 
    public int health = 3;

    public Sprite fullHear, emptyHeart;


    public float timeToRegen =2f;
    public float resetTime;


    private void Start()
    {
        resetTime = timeToRegen;
        health = numOfHearts;
    }
    // Update is called once per frame
    void Update()
    {

        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < heart.Length; i++)
        {
            if (i < health)
            {
                heart[i].sprite = fullHear;
            }
            else
            {
                heart[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                heart[i].enabled = true;
            }
            else
            {
                heart[i].enabled = false;
            }
        }
        AutoGenerateHealth();
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            GameController.isOver = true;
            Instantiate(deathEffect, transform.position + offset, Quaternion.identity);
            AudioManager.instance.PlaySound("death");
            Destroy(gameObject, 0.01f);
        }
    }
    void AutoGenerateHealth()
    {
        if (health < numOfHearts)
        {
            if (timeToRegen  > 0)
            {
                timeToRegen  -= Time.deltaTime;
            }
            else
            {
                timeToRegen = resetTime;
                health += 1;
            }
        }

    }
}
