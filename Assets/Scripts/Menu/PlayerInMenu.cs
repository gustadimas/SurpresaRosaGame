using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInMenu : MonoBehaviour
{
    private Rigidbody2D rbMenu;
    private BoxCollider2D collMenu;
    private Animator animMenu;

    [SerializeField] private LayerMask jumpableGroundMenu;

    public float moveSpeedInitialMenu;
    //private float dirX = 0f;
    public float moveSpeedMenu;

    [SerializeField]
    private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling };

    private void Start()
    {
        rbMenu = GetComponent<Rigidbody2D>();
        collMenu = GetComponent<BoxCollider2D>();
        animMenu = GetComponent<Animator>();

        moveSpeedInitialMenu = moveSpeedMenu;

        //Invoke("Jump", 1.4f);
    }
    private void Update()
    {
        //dirX = Input.GetAxisRaw("Horizontal");
        //rbMenu.velocity = new Vector2(dirX * moveSpeedMenu, rbMenu.velocity.y);

        rbMenu.velocity = new Vector2(5, rbMenu.velocity.y);

        UpdateAnimationUpdate();

        if (transform.position.x > 12)
        {
            transform.position = new Vector3(-13, -1.6f, 0);
        }

        //GetComponent<SpriteRenderer>().gameObject.SetActive(GameObject.Find("MainMenu").activeSelf);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(collMenu.bounds.center, collMenu.bounds.size, 0f, Vector2.down, .1f, jumpableGroundMenu);
    }

    private void UpdateAnimationUpdate()
    {
        MovementState state;

        state = rbMenu.velocity.x > 0f ? MovementState.running : MovementState.idle;
       
        if (rbMenu.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }

        else if (rbMenu.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        animMenu.SetInteger("state", (int)state);
    }

    private void Jump()
    {
        rbMenu.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        //Invoke("Jump", 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rbMenu.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    public void SetPosition()
    {
        transform.position = new Vector3(-13, -1.6f, 0);
    }
    public void GoToMenu()
    {
        PlayerPrefs.SetInt("estatisticsFrutas", 0);
        PlayerPrefs.SetInt("estatisticsLaços", 0);
        PlayerPrefs.SetInt("estatisticsSodas", 0);
        PlayerPrefs.SetInt("estatisticsCandys", 0);

        SceneManager.LoadScene("MenuScene");

    }
}
