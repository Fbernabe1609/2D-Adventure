using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PlayerManager : MonoBehaviour
{
    public int velocity, jumpForce;
    public int score = 0;
    public int coins = 0;
    
    private float entradaX = 0f;
    public bool vulnerable, dead, shoot, win;
    public Rigidbody2D physic;
    private SpriteRenderer sprite;
    private Animator anim;
    public AudioSource audio;
    public bool pause;
    private Vector3 raycastOffset = new Vector3(0, -1f, 0);
    private Vector2 direction = Vector2.down;
    private float distance = 0.2f;
    public LevelsManager levelsManager;
    public GameObject winMenu, pauseMenu;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinsText;

    // Start is called before the first frame update
    void Start()
    {
        velocity = 10;
        jumpForce = 10;
        score = 0;
        physic = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        vulnerable = true;
        dead = false;
        pause = false;
        win = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead && !pause && !win)
        {
            anim.enabled = true;
            entradaX = Input.GetAxis("Horizontal");

            Jump();

            Flip();

            AnimatePlayer();
        }
        else
        {
            anim.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        physic.velocity = new Vector2(entradaX * velocity, physic.velocity.y);
    }

    void Flip()
    {
        if (physic.velocity.x > 0.1)
        {
        //     Quaternion newRotation = Quaternion.identity;
        //     firePoint.rotation = newRotation;
        //     firePoint.position = new Vector3(playerTransform.position.x + 1, playerTransform.position.y, 0);
            sprite.flipX = false;
        }
        else if (physic.velocity.x < -0.1)
        {
        //     Quaternion newRotation = Quaternion.Euler(0, 180, 0);
        //     firePoint.rotation = newRotation;
        //     firePoint.position = new Vector3(playerTransform.position.x - 1, playerTransform.position.y, 0);
            sprite.flipX = true;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && TouchingFloor())
        {
            audio.Play();
            physic.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void AnimatePlayer()
    {
        anim.SetFloat("speedX", Mathf.Abs(physic.velocity.x));
        anim.SetFloat("speedY", physic.velocity.y);
    }

    public bool TouchingFloor()
    {
        RaycastHit2D touch = Physics2D.Raycast(transform.position + raycastOffset, direction, distance);
        return touch.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            EndGame();
        }
        else if (other.gameObject.CompareTag("Finish"))
        {
            pauseMenu.SetActive(false);
            WinGame();
        }
    }

    private void WinGame()
    {
        winMenu.SetActive(true);
        physic.simulated = false;
        scoreText.text = "Puntos: " + score;
        coinsText.text = "Monedas: " + coins;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject != null && other.gameObject.CompareTag("Coin"))
        {
            score += 100;
            coins += 1;
            levelsManager.UpdateCoins(coins);
            levelsManager.UpdateScore(score);
            Destroy(other.gameObject);
        }
    }

    public void EndGame()
    {
        physic.simulated = false;
        anim.Play("hurt");
        float duration = anim.GetCurrentAnimatorStateInfo(0).length;
        Invoke("Restart", duration);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}