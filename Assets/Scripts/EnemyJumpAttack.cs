using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumpAttack : MonoBehaviour
{
    [SerializeField] Transform groundCheck;
    private Transform player;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] Vector2 size;
    [SerializeField] Vector2 line;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jumpHeight;
    [SerializeField] float inArea;
    [SerializeField] float timer;
    [SerializeField] float timerCount = 2f;
    private bool isGrounded;
    private bool facingRight;
    private bool findPlayer;
    private Animator anim;

    private enum State { Idel, Jumping, Falling }
    private State state;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        timer += Time.deltaTime; // cooldown time attack
        anim.SetInteger("state", (int)state);
        isGrounded = Physics2D.OverlapBox(groundCheck.position, size, 0, groundLayer);
        findPlayer = Physics2D.OverlapBox(transform.position, line, 0, playerLayer);// Check player
        if(!findPlayer && HealthState.gameOver && UIState.iswinner && isGrounded)
        {
            StandBy();
        }
        else if(findPlayer && !HealthState.gameOver)
        {
            Animation();
            JumpAttack();

        }
        FlipToward();
    }
    void JumpAttack()
    {
        float playerDistance = player.position.x - transform.position.x; // player point
        if(playerDistance < inArea && timer > timerCount)
        {
            rb.AddForce(new Vector2(playerDistance, jumpHeight), ForceMode2D.Impulse);
            FindObjectOfType<AudioManager>().PlaySound("Cat");
            timer = 0;
        }
    }
    void StandBy()
    {
        rb.velocity = new Vector2(0, 0);
    }
    void Animation()
    {
        if(rb.velocity.y > 0f && isGrounded)
        {
            state = State.Jumping;
        }
        else if(rb.velocity.y < 0f)
        {
            state = State.Falling;
        }
        else
        {
            state = State.Idel;
        }
    }
    void FlipToward()
    {
        float playerPosition = player.position.x - transform.position.x; // player point
        if(playerPosition < 0 && facingRight)
        {
            if (transform.localScale.x == -1)
            {
                facingRight = !facingRight;
                transform.localScale = new Vector2(1, 1);
            }
        }
        else if (playerPosition > 0 && !facingRight)
        {
            if (transform.localScale.x == 1)
            {
                facingRight = !facingRight;
                transform.localScale = new Vector2(-1, 1);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(groundCheck.position, size); // check ground
        Gizmos.DrawWireSphere(transform.position, inArea); // check player in area
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, line); // Attack
    }

}
