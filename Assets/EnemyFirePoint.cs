using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFirePoint : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Transform enemyBoss;
    [SerializeField]
    private Transform mainPlayer;
    private Vector3 difference;
    // Use this for initialization
    void Start()
    {
        mainPlayer = GameObject.Find("MainPlayerGame").transform;
        enemyBoss = GameObject.Find("EnemyBoss").transform;
        player = GameObject.FindGameObjectWithTag("MainPlayerGame");
    }

    // Update is called once per frame
    void Update()
    {  
        //Debug.LogError(enemyBoss.position);
        //Debug.LogError(player.transform.position);
        Vector3 difference = enemyBoss.position - player.transform.position;
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
    }
}

