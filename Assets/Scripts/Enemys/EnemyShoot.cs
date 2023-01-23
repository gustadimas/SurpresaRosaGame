using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyShoot : MonoBehaviour
{
    private Vector2 direction;

    [SerializeField]
    private string targetTag;

    // Start is called before the first frame update
    private void Start()
    {
        Invoke("DestroyBullet", Random.Range(4f, 6f));
    }

    private void Update()
    {
        transform.Rotate(0, 0, 5); 
    }

    public void Setup(int direction)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(4 * direction, 0);
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DestroyBullet();
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    PlayerTrap player = collision.gameObject.GetComponent<PlayerTrap>();

    //    if (player && !collision.gameObject.GetComponent<PlayerMoviment>().invencible)
    //    {
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //    }
    //}
}
