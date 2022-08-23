using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    BoxCollider2D collider2D;

    [SerializeField]
    float moveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.localScale = new Vector3(-Mathf.Sign(rigidBody2D.velocity.x),
            transform.localScale.y, transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFacingRight())
        {
            rigidBody2D.velocity = new Vector2(moveSpeed, 0f);

        }
        else
        {
            rigidBody2D.velocity = new Vector2(-moveSpeed, 0f);

        }
    }
    private bool IsFacingRight()
    {
        bool isFacingRight = transform.localScale.x > Mathf.Epsilon;
        return isFacingRight;
    }
}
