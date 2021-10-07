using UnityEngine;

public class GrenadeStats : MonoBehaviour
{
    public static GrenadeStats instance;

    public float FireRate;
    public int damage;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
