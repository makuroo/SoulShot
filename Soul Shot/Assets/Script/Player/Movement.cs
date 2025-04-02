using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D playerRb;

    public Animator animator;

    [SerializeField] float speed = 20f;
    [Range(1, 20)]
    public float jumpVelocity;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public Health health;
    public Button button;
    [SerializeField] private IsGrounded state;
    [SerializeField] private AudioManager manager;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator.SetInteger("hp", 3);
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if(health.currentHp == 1)
        {
            animator.SetInteger("hp", 1);
        }

        if (playerRb.linearVelocity.y < 0)
        {
            playerRb.linearVelocity += (fallMultiplier - 1) * Physics2D.gravity.y * Time.deltaTime * Vector2.up;
        }
        else if (playerRb.linearVelocity.y > 0 && !Input.GetKey(KeyCode.W))
        {
            playerRb.linearVelocity += (lowJumpMultiplier - 1) * Physics2D.gravity.y * Time.deltaTime * Vector2.up;
        }
    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            playerRb.transform.Translate(Vector2.left * speed * Time.deltaTime);
            animator.SetFloat("speed", 1.0f);
            if (!manager.moveSound.isPlaying && state.isGrounded == false)
                manager.PlayMoveSound();
            if (gameObject.GetComponent<SpriteRenderer>().flipX == false)
            {
                transform.localScale = Vector2.one;
            }
            else
            {
                transform.localScale = new Vector2(-1, 1);
            }
            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerRb.transform.Translate(Vector2.right * speed * Time.deltaTime);
            animator.SetFloat("speed", 1.0f);
            if (!manager.moveSound.isPlaying && state.isGrounded == false)
                manager.PlayMoveSound();
            if (gameObject.GetComponent<SpriteRenderer>().flipX == false)
            {
                transform.localScale = new Vector2(-1, 1);
            }
            else
            {
                transform.localScale = Vector2.one;
            }
        }
        else
        {
            animator.SetFloat("speed", 0.0f);
        }
        
        if (Input.GetKeyDown(KeyCode.W) && !state.isGrounded)
        {
            playerRb.linearVelocity = Vector2.up * jumpVelocity;
            state.isGrounded = true;
        }
    }

    public bool CanAttack()
    {
        return (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) && (state.isGrounded == false && button.attack == true);
    }
}