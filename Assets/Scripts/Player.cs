using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

   	public int fallBoundary = -20;
    
    [SerializeField]
    private StatusIndicator statusIndicator;

    public PlayerStats stats;
    
    void Start()
    {
        stats = GameObject.FindObjectOfType<PlayerStats>();
        stats.curHealth = stats.maxHealth;
        stats = PlayerStats.instance;
        if (statusIndicator == null)
        {
            Debug.LogError("no status indicator referenced on player.");
        }
        else
        {
            statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
        }

        InvokeRepeating("regenHealth", 5, stats.healthRegenInterval);
        Debug.LogError("Max Health" + stats.maxHealth);
        Debug.LogError("Cur Health" + stats.curHealth);
       }

    void regenHealth()
    {
        stats.curHealth += stats.healthRegenAmt;
    }

    void Update () {
      if (transform.position.y <= fallBoundary)
			DamagePlayer (9999999);
        statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
        }

	public void DamagePlayer (int damage) {
		stats.curHealth -= damage;
		if (stats.curHealth <= 0) {
			GameMaster.KillPlayer(this);
		}
       
    }

}
