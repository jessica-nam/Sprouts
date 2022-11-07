using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{

    Rigidbody2D rigidbody2d;
    Animator animator;
    SpriteRenderer spriteRenderer;
    Vector2 motionVector;

    [SerializeField] float speed = 5f;
    

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        motionVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move(){
        rigidbody2d.velocity = motionVector * speed;
        
        if ((Input.GetKey("d") || Input.GetKey("right")))
        {
                //check if player grounded functionality?
                rigidbody2d.velocity = new Vector2(1.5f, rigidbody2d.velocity.y);
                animator.Play("PlayerWalk");
                spriteRenderer.flipX = false;
        }
        else if ((Input.GetKey("a") || Input.GetKey("left")))
        {
                rigidbody2d.velocity = new Vector2(-1.5f, rigidbody2d.velocity.y);
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
