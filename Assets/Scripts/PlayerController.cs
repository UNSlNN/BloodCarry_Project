using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] public Rigidbody2D rigid;
    [SerializeField] Animator anim;
    [SerializeField] SpriteRenderer sprite;
    [Header("MovementStats")]
    [SerializeField] private BoxCollider2D coll2D;
    [SerializeField] private LayerMask isGround;
    [SerializeField] float movement = 15f;
    [SerializeField] float jump = 10f;
    float timer = 0f;
    float keyHorizontal;
    float isMoving = 0.41f;
    bool isFacingRight;
    bool keyJump;
    //Knockback
    [SerializeField] private float knockbackVelocity = 8f;
    [SerializeField] private bool knockbacked;
    [SerializeField] private float knockbackedTime = 0.4f;
    private enum State { Idel, Walk, Jumping, Falling, Dead } // Animation
    private State state;
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll2D = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        isFacingRight = true; // Flipping Face after moving
    }
    void Update()
    {
        // set state animation
        anim.SetInteger("state", (int)state);

        PlayerDirectionInput();
        MovementState();
        JumpState();
        AnimationState();
        StopPlayerMove();
    }
    public void PlayerDirectionInput()
    {
        keyHorizontal = Input.GetAxis("Horizontal"); // PlayerMoveInput
        keyJump = Input.GetKeyDown(KeyCode.Space);   // PlayerJumpingInput
    }
    void MovementState()
    {
        if(!knockbacked)
        {
            // Function "Run"
            rigid.velocity = new Vector2(keyHorizontal * movement, rigid.velocity.y);
        }
    }
    void JumpState()
    {
        // Function "Jump"
        if (keyJump && IsGrounded())
        {
            keyJump = true;
            rigid.velocity = new Vector2(rigid.velocity.x, jump);
            // play sound
            FindObjectOfType<AudioManager>().PlaySound("Jump2");
        }
    }
    private bool IsGrounded() // check player is touching ground
    {
        return Physics2D.BoxCast(coll2D.bounds.center, coll2D.bounds.size, 0f, Vector2.down, .1f, isGround);
    }
    void AnimationState()
    {
        // Play animation "Walking"
        if (keyHorizontal < 0)
        {
            // facing left while moving Left - flip
            if (isFacingRight)
            {
                FlipState();
            }
            state = State.Walk;
            FootStepSound();
        }
        else if (keyHorizontal > 0)
        {
            // facing left while moving right - flip
            if (!isFacingRight)
            {
                FlipState();
            }
            state = State.Walk;
            FootStepSound();
        }
        else
        {
            state = State.Idel;
        }
        // Play animation "Jumping"
        if (rigid.velocity.y > 0f && !IsGrounded())
        {
            state = State.Jumping;
        }
        else if (rigid.velocity.y < 0f && !IsGrounded())
        {
            state = State.Falling;
        }
    }
    void FlipState()
    {
        // invert facing direction and rotate object 180 degrees on y axis
        if (isFacingRight && keyHorizontal < 0f || !isFacingRight && keyHorizontal > 0f)
        {
            if(!HealthState.gameOver && !UIState.iswinner)
            {
                isFacingRight = !isFacingRight;
                transform.Rotate(0f, -180f, 0f);
            }
        }
    }
    void FootStepSound()
    {
        if (IsGrounded())
        {
            if(keyHorizontal != 0)
            {
                timer += Time.deltaTime;
                if (timer > isMoving)
                {
                    FindObjectOfType<AudioManager>().PlaySound("Walk");
                    timer = 0;
                }
            }
        }
    }
    public void StopPlayerMove()
    {
        // When Player can't moved, Do something.
        if (HealthState.gameOver || UIState.iswinner)
        {
            // Set Animation
            if(HealthState.gameOver)
            {
                state = State.Dead;
            }
            else
            {
                state = State.Idel;
            }
            // Player can't move
            movement = 0;
            jump = 0;
            // Stop play SFX
            FindObjectOfType<AudioManager>().StopPlay("Jump2");
            FindObjectOfType<AudioManager>().StopPlay("Walk");
            FindObjectOfType<AudioManager>().StopPlay("Hurt1");
        }
    }
    public void Knockback(Transform t)
    {
        // Impact when player take damaged
        var dir = transform.position - t.position;
        knockbacked = true;
        rigid.velocity = dir.normalized * knockbackVelocity;
        sprite.color = Color.red;
        // play sound
        FindObjectOfType<AudioManager>().PlaySound("Hurt1");
        StartCoroutine(UnKnockback());
        StartCoroutine(ReturnKnockEffect());
    }
    private IEnumerator UnKnockback() // time to knocked
    {
        yield return new WaitForSeconds(knockbackedTime);
        knockbacked = false;
    }
    private IEnumerator ReturnKnockEffect() // return color after take damaged
    {
        while(sprite.color != Color.white)
        {
            yield return new WaitForSeconds(0.2f);
            sprite.color = Color.white;
        }
    }
}
