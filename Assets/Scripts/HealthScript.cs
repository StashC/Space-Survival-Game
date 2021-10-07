using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {
    public float health;

    public Transform moneyLoot;
    public bool detectPlayerRound;
    public bool detectPlayer;
    public bool detectEnemies;
    public bool detectEnemyRound;
    public Transform mainCam;
    public float camShakeAmt = 0.1f;
    public float camShakeLength = 0.1f;
   
    private void Start()
    {
               
    }

    public void Shake(float amt, float length)
    {
        camShakeAmt = amt;
        InvokeRepeating("DoShake", 0, 0.01f);
        Invoke("StopShake", length);
    }

    void DoShake()
    {
        if (camShakeAmt > 0)
        {
            Vector3 camPos = mainCam.transform.position;

            float offsetX = Random.value * camShakeAmt * 2 - camShakeAmt;
            float offsetY = Random.value * camShakeAmt * 2 - camShakeAmt;
            camPos.x += offsetX;
            camPos.y += offsetY;

            mainCam.transform.position = camPos;
        }
    }

    void StopShake()
    {
        CancelInvoke("DoShake");
        mainCam.transform.localPosition = Vector3.zero;
    }



private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlasmaRoundMedium" && detectPlayerRound)
        {
            health -= 20;
            Debug.Log(health + gameObject.name);
        }
        if (collision.gameObject.tag == "PlasmaRoundLarge" && detectPlayerRound)
        {
            health -= 150;
            Debug.Log(health + gameObject.name);
        }
        if (collision.gameObject.tag == "Player" && detectPlayer)
        {
            health -= 50;
            Debug.Log(health + gameObject.name);
        }
        if (collision.gameObject.tag == "enemyUFO" && detectEnemies)
        {
            health -= 50;
            Debug.Log(health + gameObject.name);
        }
        if (collision.gameObject.tag == "enemyMediumRound" && detectEnemyRound)
        {
            health -= 20;
            Debug.Log(health + gameObject.name);
        }
    }

    void die()
    {
        Instantiate(moneyLoot, transform.position, transform.rotation);
        GameObject.Destroy(gameObject);
    }

    void Update () {
        if (health <= 0)
        {
            die();
        }
    }
}
