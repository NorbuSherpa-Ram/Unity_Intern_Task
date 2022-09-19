using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patoralling_Enemy : Enemy_Health 
{
    public float speed=5f;
    public int  ccurrentPosIndex=0;

    public Transform [] patorallingPoints ;

    void Start()
    {
        transform.position = patorallingPoints[ccurrentPosIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
         Vector2 moveDirection = Vector2.MoveTowards(transform.position, patorallingPoints[ccurrentPosIndex].position , speed * Time.deltaTime);
        transform.position = moveDirection;
        if (transform.position ==patorallingPoints[ccurrentPosIndex].position)
        {
            if (ccurrentPosIndex + 1 < patorallingPoints.Length)
            {
                ccurrentPosIndex++;
            }
            else
            {
                ccurrentPosIndex = 0;
            }
        }
    }
}
