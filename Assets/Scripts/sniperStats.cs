using UnityEngine;

public class sniperStats : MonoBehaviour
{
    public static sniperStats instance;

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
