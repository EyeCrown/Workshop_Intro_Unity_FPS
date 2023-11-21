using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutterProjectile : CutterObject
{
    private float speed = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        //transform.Rotate(0, 0, speed);
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }
}
