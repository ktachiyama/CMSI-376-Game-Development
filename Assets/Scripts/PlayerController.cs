using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : Actor
{
    public int bunnySpeed = 10;
    public float bunnyJumpPower = 35;

    public Transform shootingPoint;
    public GameObject shootingPrefab;

    private Rigidbody2D rb;
    private float moveX;
    private bool facingRight = true;
    private bool isJumping = false;
    public bool isGrounded;

    private float jumpTimeCounter;
    private float maxJumpTime = 0.35f;

    void Start()
    {
        GameManager.Instance.init();
        //shootingPoint = gameObject.Find("ShootingPoint").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Player movement
        PlayerMove();

        //Player attack
        if (Input.GetButtonDown("PewPew"))
        {
            shoot();
        }

        if (gameObject.transform.position.y < GameManager.DEATH_HEIGHT)
        {
            Debug.Log("i fell");
            GameManager.Instance.AhhhIFell();
        }
    }

    void PlayerMove()
    {
        //Horizonal Movement
        moveX = Input.GetAxis("Horizontal");

        //Jumping
        if (isGrounded == true && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            isGrounded = false;
            jumpTimeCounter = maxJumpTime;
            rb.velocity = Vector2.up * bunnyJumpPower;
        }
        if (Input.GetButton("Jump") && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * (bunnyJumpPower * 0.5f);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }

        //Animation to be done later

        //Bunny Direction
        if (moveX > 0.0f && !facingRight)
        {
            FlipPlayer();
        }
        else if(moveX < 0.0f && facingRight)
        {
            FlipPlayer();
        }

        //Physics
        rb.velocity = new Vector2(moveX * bunnySpeed, rb.velocity.y);
    }

    void shoot()
    {
        Instantiate(shootingPrefab, shootingPoint.position, shootingPoint.rotation);
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground" || other.gameObject.tag == "block")
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground" || other.gameObject.tag == "block")
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("easterEgg"))
        {
            GameManager.Instance.loadNextLevel();
        }
    }
}
