using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    public float jumpForce;
    private Animator animator;
    public new Rigidbody2D rigidbody2D;
    public GameManager gameManager;
    public AudioSource music;
    public AudioSource death;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && !IsTouchingFloor() && !gameManager.gameOver)
        {
            Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Land();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }

    private bool IsTouchingFloor()
    {
        var touching = Physics2D.Raycast(transform.position + Vector3.down * 2, Vector2.down, 0.2f).collider;
        return touching != null;
    }

    private void Jump()
    {
        animator.SetBool("isJumping", true);
        rigidbody2D.AddForce(Vector2.up * jumpForce);
    }

    private void Land()
    {
        animator.SetBool("isJumping", false);
    }

    private void GameOver()
    {
        music.Stop();
        death.Play();
        gameManager.gameOver = true;
        animator.enabled = false;
    }
}