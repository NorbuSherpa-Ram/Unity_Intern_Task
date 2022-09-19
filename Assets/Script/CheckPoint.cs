using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckPoint : MonoBehaviour
{
    public static event Action<Vector3 > onCheckPointTrigger;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject .CompareTag("Player"))
        {
            onCheckPointTrigger?.Invoke(this.transform.position);
        }
     }
}
