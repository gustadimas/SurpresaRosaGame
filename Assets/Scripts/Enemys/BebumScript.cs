using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BebumScript : MonoBehaviour
{

    [SerializeField]
    private GameObject garrafa;

    [SerializeField]
    private GameObject tiroOrigem;

    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("Atirar", 0.3f, 2f);
    }

    private void Update()
    {
        int direction = transform.position.x < GameObject.Find("Player").transform.position.x ? 1 : -1;

        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * direction, transform.localScale.y, 1);
    }

    private void Atirar()
    {
        if (Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 20)
        {
            GameObject garrafaSpawn = Instantiate(garrafa, new Vector2(tiroOrigem.transform.position.x, tiroOrigem.transform.position.y), Quaternion.identity);

            garrafaSpawn.GetComponent<EnemyShoot>().Setup((int)(Mathf.Abs(transform.localScale.x) / (transform.localScale.x)));
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<PlayerMoviment>() != null)
        {
            PlayerMoviment bebum = collider.gameObject.GetComponent<PlayerMoviment>();
            bebum.Attack();
            Destroy(gameObject);
        }
    }

    public void DestroyBebum()
    {
        Destroy(gameObject);
    }
}
