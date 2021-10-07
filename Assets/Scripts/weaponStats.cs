using UnityEngine;

public class weaponStats : MonoBehaviour
{
    public static weaponStats instance;
        
    public float fireRate;
    public int damage;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
