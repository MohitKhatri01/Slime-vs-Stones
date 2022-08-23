using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField]
    InventoryManager inventoryManager;
    [SerializeField]
    GameObject stone;
    [SerializeField]
    Transform dropStonePosition;
    [SerializeField]
    GameObject Menu;

    Rigidbody2D rigidBody2d;
    Animator animator;
    CapsuleCollider2D cc2d;

    private float runSpeed = 1.5f;
    private float jumpSpeed = 3f;

    bool playerDead = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2d = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        cc2d = GetComponent<CapsuleCollider2D>();
    }

    #region PlayerMovement
    private void PlayerRun()
    {
        var horizontalInputValue = Input.GetAxis("Horizontal");
        Vector2 runVelocity = new Vector2(
            horizontalInputValue * runSpeed, 
            rigidBody2d.velocity.y);
        rigidBody2d.velocity = runVelocity;

        bool isRunningHorizontally = Mathf.Abs(rigidBody2d.velocity.x) > Mathf.Epsilon;

        animator.SetBool("isRunningHorizontally", isRunningHorizontally);

    }
    private void FlipSprite()
    {
        bool isRunninghorizontal = Mathf.Abs(rigidBody2d.velocity.x) > Mathf.Epsilon;
        if (isRunninghorizontal)
        {
            transform.localScale = new Vector3(Mathf.Sign(rigidBody2d.velocity.x), transform.localScale.y,
                transform.localScale.z);
        }

    }
    public void PlayerJump()
    {
        bool isTouchingGround =cc2d.IsTouchingLayers(LayerMask.GetMask("Ground"));
        if (isTouchingGround)
        {
           
            if (Input.GetButtonDown("Jump"))
            {

                Vector2 jumpVelocity = new Vector2(rigidBody2d.velocity.x, jumpSpeed);
                rigidBody2d.velocity += jumpVelocity;

            }
        }

    }
    #endregion

    public void DropStone()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (inventoryManager.stonesList.Count > 0)
            {
                inventoryManager.RemoveFromList();

                GameObject stoneInstance = Instantiate<GameObject>(stone
                    , dropStonePosition.position,
                    Quaternion.identity);

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!playerDead)
        {
            PlayerRun();
            FlipSprite();
            PlayerJump();
            DropStone();
        }
       
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Slime>())
        {
            if (!playerDead)
            {
                animator.SetTrigger("Dead");
                playerDead = true;
                Menu.SetActive(true);
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Slime>())
        {
            if (!playerDead)
            {
                animator.SetTrigger("Dead");
                playerDead = true;
                Menu.SetActive(true);
            }
        }
    }
}
