using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{
    private GrenadeStats gStats;
    public float delay = 3f;
    public bool hasExploded = false;
    public GameObject explosionEffect;
    float countdown;
    public float blastRadius = 20f;
    public float explosionForce = 700f;
    public int Damage;
    private float damageMultiplier;
    private float proximity;
    private GameObject explodeEffect;

    public string explodeSound = "DefaultExplosion";
    AudioManager audioManager;


    void Awake()
    {
        gStats = GameObject.FindObjectOfType<GrenadeStats>();
    } 
    // Use this for initialization
    void Start()
    {
        audioManager = AudioManager.instance;
        countdown = delay;
        gStats = GrenadeStats.instance;
        Damage = gStats.damage;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }

        
    }
   
    void Explode()
    {
        Debug.LogError("Exploded");
        explodeEffect = Instantiate(explosionEffect, transform.position, transform.rotation);
        GameObject.Destroy(explodeEffect, 2f);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, blastRadius);

        foreach (Collider2D nearbyObject in colliders)
        {
            Rigidbody2D rb = nearbyObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, blastRadius);
            }
            Enemy enemy = nearbyObject.GetComponent<Enemy>();
            if(enemy != null)
            {
                Debug.LogError("enemynearbygrenade");
                float proximity = (transform.position - enemy.transform.position).magnitude;
                float damageMultiplier = 1 - (proximity / blastRadius);
                enemy.DamageEnemy(Mathf.RoundToInt(Damage * -damageMultiplier));
                Debug.LogError("Damaged with " + Damage * damageMultiplier);
            }
            audioManager.PlaySound(explodeSound);
            Destroy(gameObject);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.LogError("Grenade hit something");
        if (collision.gameObject.layer != 12)
        {
            Explode();
        }
    }
}
