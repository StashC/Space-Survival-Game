using UnityEngine;

public class GrenadeLauncherStats : MonoBehaviour
{
    public static GrenadeLauncherStats instance;

    public float GLFireRate;
    public int damage;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
