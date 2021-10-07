using UnityEngine;

public class AKStats : MonoBehaviour
{
    public static AKStats instance;

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
