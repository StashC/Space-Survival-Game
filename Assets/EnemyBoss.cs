using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour {
    float timeToSpawnEffect = 0f;
    public GameObject player;
    private Rigidbody2D rb;
    public float bossFireRate = 2f;
    private Transform boss;
    private Transform firePoint;   
    private Transform playerPos;
    private float timeToFire;
    public GameObject EnemyToSpawn;
    [SerializeField]
    private Transform muzzleFlashPrefab;

    // Use this for initialization
    [SerializeField]
    private int moveSpeed = 100;
	void Start () {
        boss = gameObject.transform;
        rb = GetComponent<Rigidbody2D>();
        timeToFire = bossFireRate;
      }
	
	// Update is called once per frame
	void Update () {
        player = GameObject.FindGameObjectWithTag("MainPlayerGame");
        if (player != null)
        {
            if (player.transform.position.x < boss.transform.position.x)
            {
                rb.velocity += new Vector2(-moveSpeed * Time.deltaTime, 0);
            }
            if (player.transform.position.x > boss.transform.position.x)
            {
                rb.velocity += new Vector2(moveSpeed * Time.deltaTime, 0);
            }
        }
        if(transform.position.y > 11)
        {
            rb.velocity = new Vector2(rb.velocity.x, -10);
        }
        if(transform.position.y <= 10.5)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
        if(timeToFire < Time.time)
        {
            Instantiate(EnemyToSpawn, transform.position, transform.rotation);
            timeToFire = Time.time + bossFireRate;
        }
    }    
}
