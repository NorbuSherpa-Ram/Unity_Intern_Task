using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    public float delay = 0.3f;

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, delay);
    }
}
