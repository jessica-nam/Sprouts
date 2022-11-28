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

    public AudioSource playerSounds;
    public AudioClip[] footsteps;

    public float lastTime = 0;
    public float duration = 0.2f;
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
            if (Time.time - lastTime >= duration)
            {
                int randomIndex = Random.Range(0, footsteps.Length);
                AudioClip randomClip = footsteps[randomIndex];
                lastTime = Time.time;
                playerSounds.clip = randomClip;
                playerSounds.Play();

            }


        }
        else if ((Input.GetKey("a") || Input.GetKey("left")))
        {
                rigidbody2d.velocity = new Vector2(-5.0f, rigidbody2d.velocity.y);
                animator.Play("PlayerWalk");
                spriteRenderer.flipX = true;
            if (Time.time - lastTime >= duration)
            {
                int randomIndex = Random.Range(0, footsteps.Length);
                AudioClip randomClip = footsteps[randomIndex];
                lastTime = Time.time;
                playerSounds.clip = randomClip;
                playerSounds.Play();

            }
        }
        else
        {
                //eliminate sliding
                rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
        }
    }
}
