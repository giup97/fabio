using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float Vertical_Speed;
    public float fall_gravity=2.5f;
    [SerializeField]bool is_grounded = false;
    bool is_sliding = false;
    [SerializeField]bool allowjump = false;
    bool slide = false;
    float slide_time = 0.5f;
    float temp;
    Animator animator;
    BoxCollider2D RegularColl;
    [SerializeField] private GameObject SlidingColl;
    bool hoeseguito = false;
    
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        RegularColl = GetComponent<BoxCollider2D>();
        SlidingColl.GetComponent<BoxCollider2D>().enabled = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!slide)
            {
                allowjump = true;
            }

        }
        if (Input.GetButton("Down"))
        {
            if (!allowjump)
            {
                slide = true;
                animator.SetBool("IsSliding", true);
                temp = Time.time + slide_time;
            }
        }
        else slide = false;

        if (is_grounded)
        {
            animator.SetBool("IsJumping", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground" && !is_grounded)
        {
            is_grounded = true;
            
        }
    }

    void FixedUpdate()
    {
        Player_move();
        if (allowjump && is_grounded)
        {
            Jump();
            allowjump= false;
            is_grounded = false;
        }

        if (rb.velocity.y < 0)
        {
            is_grounded = false;
            animator.SetBool("IsFalling", true);
            rb.gravityScale = fall_gravity;
            animator.SetBool("IsJumping", false);
        }
        else
        { 
            rb.gravityScale = 4f;
            animator.SetBool("IsFalling", false);
        }
        if (slide && is_grounded && !hoeseguito)
        {
            RegularColl.enabled = false;
            SlidingColl.GetComponent<BoxCollider2D>().enabled = true;
            hoeseguito = true;
        }
        if (Time.time > temp && hoeseguito )
        {
            RegularColl.enabled = true;
            SlidingColl.GetComponent<BoxCollider2D>().enabled = false;
            slide = false;
            animator.SetBool("IsSliding", false);
            hoeseguito = false;
        }
    }

    private void Player_move()
    {
        // transform.position += Vector3.right * speed * Time.deltaTime;
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    

    private void Jump()
    {    
       rb.AddForce(Vector2.up * Vertical_Speed, ForceMode2D.Impulse);
        animator.SetBool("IsJumping", true);
    }

    
}
