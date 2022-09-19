using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Coin : MonoBehaviour
{
    public static event Action<GameObject,int > onCoinCollect;
   
    int coinValue = 1;
    float destroyIn = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        onCoinCollect?.Invoke(other.gameObject ,coinValue );
        if (other.gameObject.CompareTag("Player")) Destroy(this.gameObject);
    }
    private void Update()
    {
        Destroy(this.gameObject, destroyIn);
    }
}
