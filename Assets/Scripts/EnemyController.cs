using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemySpeed = 5;
    public float enemyHealth = 1;

    float currentHealth;
    Transform player;
    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        currentHealth = enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction = (new Vector3(direction.x, 0, direction.z)).normalized;
        rb.velocity = direction * enemySpeed + new Vector3(0, rb.velocity.y, 0);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject == player.gameObject)
        {
            currentHealth--;
        }

        if (currentHealth < 0)
        {
            Destroy(gameObject);
        }
    }
}
