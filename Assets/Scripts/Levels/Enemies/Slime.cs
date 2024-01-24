using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public float speed;
    public float width;

    private Vector3 startPos;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float newX = Mathf.PingPong(Time.time * speed, width * 2) - width;
        transform.position = new Vector3(startPos.x + newX, startPos.y, startPos.z);
        if (newX > 0.1)
        {
            spriteRenderer.flipX = false;
        }
        else if (newX < -0.1)
        {
            spriteRenderer.flipX = true;
        }
    }
}
