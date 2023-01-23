using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoviment : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;

    public GameObject pauseMenuScreen;

    [SerializeField] 
    private LayerMask jumpableGround;

    public bool invencible = false;
    public float moveSpeedInitial;
    private float dirX = 0f;

    [SerializeField]
    public float moveSpeed;

    [SerializeField] 
    private float jumpForce = 14f;

    public Vector3 respawnPoint;
    public GameObject fallDetector;

    private GameObject attackArea = default;
    private bool attacking = false;
    private float timeToAttack = 0.25f;
    private float timer = 0f;
    public bool movement;

    private enum MovementState {idle, running, jumping, falling};
    
    private void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        respawnPoint = transform.position;

        moveSpeedInitial = moveSpeed;

        attackArea = GameObject.Find("AttackArea");
        attackArea.SetActive(false);
    }
 
    private void Update()
    {
        UpdateAnimationUpdate();

        if (movement == true)
        {
            dirX = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }

            fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);

            if (dirX > 0)
            {
                attackArea.transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, 0);

                attackArea.transform.eulerAngles = new Vector3(0, 0, 0);
            }

            else if (dirX < 0)
            {
                attackArea.transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, 0);

                attackArea.transform.eulerAngles = new Vector3(0, 0, 180);
            }

            attackArea.transform.localScale = transform.localScale;


            if (Input.GetKeyDown(KeyCode.Z))
            {
                Attack();
            }

            if (attacking)
            {
                timer += Time.deltaTime;

                if (timer >= timeToAttack)
                {
                    timer = 0;
                    attacking = false;
                    attackArea.SetActive(attacking);
                }
            }
        }
    }

    private void UpdateAnimationUpdate()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }

        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }

        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }

        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetBool("attacking", attacking);

        anim.SetInteger("state", (int)state);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FallDetector")
        {
            AudioManager.instance.Play("Die");
            transform.position = respawnPoint;
        }
        else if (collision.tag == "Checkpoint")
        {
            AudioManager.instance.Play("Checkpoint");
            respawnPoint = transform.position;
        }

        if (collision.tag == "Enemys")
        {
            if (!invencible)
            {
                transform.position = respawnPoint;
                AudioManager.instance.Play("Die");
                GameObject.Find("Panel").GetComponent<ProgressBar>().BarraAtt(2f);
            }
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void SetPosition()
    {
        transform.position = new Vector3(-13, -1.6f, 0);
    }

    public void Attack()
    {
        attacking = true;

        attackArea.SetActive(attacking);

        timeToAttack = timer + 0.5f;
    }

    //public void RespawnPoint()
    //{
    //    respawnPoint = transform.position;
    //}
}
