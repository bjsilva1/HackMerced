using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemySpeed = 5;
    Transform player;
    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction = (new Vector3(direction.x, 0, direction.z)).normalized;
        rb.velocity = direction * enemySpeed + new Vector3(0, rb.velocity.y, 0);
    }
}
