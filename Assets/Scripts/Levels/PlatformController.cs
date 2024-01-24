using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Transform platformA;
    public Transform platformB;
    public float speed = 2f;
    public float maxHeight = 12f;
    public float minHeight = -8f; 

    void Update()
    {
        platformA.Translate(Vector3.right * (speed * Time.deltaTime));
        platformB.Translate(Vector3.left * (speed * Time.deltaTime));

        if (platformA.position.y > maxHeight || platformB.position.y < minHeight)
        {
            speed = -speed;
        }
        else if (platformA.position.y < minHeight || platformB.position.y > maxHeight)
        {
            speed = -speed;
        }
    }
}