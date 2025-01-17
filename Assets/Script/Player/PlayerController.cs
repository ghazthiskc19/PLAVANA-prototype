using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int extraJumpValue;
    Animator animator;
    Vector3 topRight;
    Vector3 bottomLeft;
    AudioManager audioManager;
    private float moveInput;
    private bool facingRight = true;
    private bool moveRight = false;
    private bool moveLeft = false;
    private bool isJumping = false;
    private bool isGrounded;
    private int extraJumps;
    private float minX, maxX;
    private bool isGameStarted = false;
    private float stepDelay = 0.1f;
    private float stepTimer = 0f; 
    public void PointerDownLeft(){
        moveLeft = true;
    }
    public void PointerUpLeft(){
        moveLeft = false;
    }
    public void PointerDownRight(){
        moveRight = true;
    }
    public void PointerUpRight(){
        moveRight = false;
    }

    public void jumpingButton(){
        isJumping = true;
    }

    public void setGameStarted(){
        isGameStarted = true;
    }
    // Start is called before the first frame update
    
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        moveRight = false;
        moveLeft = false;

        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane));

        minX = bottomLeft.x + 0.25f;
        maxX = topRight.x - 0.25f;
    }
    void Update()
    {   
        movePlayer();
        if((isJumping || Input.GetKeyDown(KeyCode.Space)) && extraJumps > 0){
            rb.velocity = Vector3.up * jumpForce;
            extraJumps--;
            audioManager.PlaySFX(audioManager.Jump);
        }
        if(isGrounded){
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", false);
            isJumping = false;
            extraJumps = extraJumpValue;
        }


        if(!isGrounded){
            if(rb.velocity.y < 0){
                animator.SetBool("IsFalling", true);
                animator.SetBool("IsJumping", false);
            }else if(rb.velocity.y > 0 ){
                animator.SetBool("IsJumping", true);
                animator.SetBool("IsFalling", false);
            }
        }
    }

    void movePlayer(){
        if(isGameStarted){
        float inputKeyboard = Input.GetAxis("Horizontal");
            if(moveLeft || inputKeyboard < 0){
                animator.SetBool("IsRunning", true);
                animator.SetBool("IsIdle", false);
                moveInput = -speed;
            }else if(moveRight || inputKeyboard > 0){
                animator.SetBool("IsRunning", true);
                animator.SetBool("IsIdle", false);
                moveInput = speed;
            }else{
                animator.SetBool("IsIdle", true);
                animator.SetBool("IsRunning", false);
                moveInput = 0;
            }
        }
    }
    void FixedUpdate(){
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        rb.velocity = new Vector2(moveInput, rb.velocity.y);
        if(facingRight == false && moveInput > 0){
            Flip();
        }else if(facingRight == true && moveInput < 0){
            Flip();
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, bottomLeft.y, topRight.y - 0.25f), transform.position.z);
    }

    void Flip(){
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
