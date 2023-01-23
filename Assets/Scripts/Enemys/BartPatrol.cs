using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BartPatrol : MonoBehaviour
{
    public float walkspeed;

    public bool bart_patrol;
    public bool bart_turn;

    public Rigidbody2D rb;

    public Transform groundCheckPos;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        bart_patrol = true;   
    }

    // Update is called once per frame
    void Update()
    {
        if (bart_patrol)
        {
            Patrol();
        }
    }

    private void FixedUpdate()
    {
        if (bart_patrol)
        {
            bart_turn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }

    private void Patrol()
    {
        if (bart_turn)
        {
            Flip();
        }

        rb.velocity = new Vector2 (walkspeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    private void Flip()
    {
        bart_patrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkspeed *= -1;
        bart_patrol = true;
    }
    public void DestroyBart()
    {
        Destroy(gameObject);
    }
}
