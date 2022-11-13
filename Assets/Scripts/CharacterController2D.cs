using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{

    Rigidbody2D rigidbody2d;
    Animator animator;
    SpriteRenderer spriteRenderer;

    [SerializeField] float speed;
    

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void FixedUpdate()
    {
        Move();
    }

    private void Move(){
        
        if ((Input.GetKey("d") || Input.GetKey("right")))
        {
                //check if player grounded functionality?
                rigidbody2d.velocity = new Vector2(5.0f, rigidbody2d.velocity.y);
                animator.Play("PlayerWalk");
                spriteRenderer.flipX = false;
        }
        else if ((Input.GetKey("a") || Input.GetKey("left")))
        {
                rigidbody2d.velocity = new Vector2(-5.0f, rigidbody2d.velocity.y);
                animator.Play("PlayerWalk");
                spriteRenderer.flipX = true;
        }
        else
        {
                //eliminate sliding
                rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
        }
    }
}
