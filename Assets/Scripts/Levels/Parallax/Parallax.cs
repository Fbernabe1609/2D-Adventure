using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Parallax : MonoBehaviour
{
    public float parallaxEffect;
    private Transform cam;
    private Vector3 lastCamPos;
    public bool enableAxisY;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        lastCamPos = cam.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 backgroundMovement = cam.position - lastCamPos;
        float yMovement = enableAxisY ? backgroundMovement.y : 0;
        transform.position += new Vector3(backgroundMovement.x * parallaxEffect, yMovement, 0);
        lastCamPos = cam.position;
    }
}