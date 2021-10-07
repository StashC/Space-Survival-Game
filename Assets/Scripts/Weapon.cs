using UnityEngine;
using System.Collections;

public class myWeapon : MonoBehaviour {
        
	public float fireRate = 0;
	public float Damage = 10;
	public LayerMask whatToHit;
	
	public Transform mediumPlasmaRound;
    Vector3 mousePosition;
    float timeToSpawnEffect = 0;
	public float effectSpawnRate = 5;
    public int magSize;
    public int ammoInMag;
    public float reloadTime;
    private bool isReloading = false;

    
	float timeToFire = 0;
	Transform firePoint;
    Transform w_transform;
    void Start()
    {
        ammoInMag = magSize;

    }
    void Awake()
    {
        
        firePoint = transform.Find("firePoint");
        if (firePoint == null)
        {
            Debug.LogError("No firePoint? WHAT?!");
        }
        w_transform = gameObject.GetComponent<Transform>();
    }
    void shoot()
    {
        Instantiate(mediumPlasmaRound, firePoint.position, firePoint.rotation);
        ammoInMag -= 1;
        //Debug.LogError(ammoInMag);
    }
    // Update is called once per frame
    void Update () {
        if (ammoInMag == 0)
        {
            StartCoroutine("CoroutineReloading", ammoInMag == 0 && !isReloading);
        }
        if (Input.GetButton ("Fire1") && Time.time > timeToFire && ammoInMag > 0 && !isReloading) {
				timeToFire = Time.time + 1/fireRate;
				shoot();
            }
        }
    IEnumerator CoroutineReloading()
    {
        ammoInMag = -1;
        isReloading = true;
        //Debug.LogError("CoroutineReloading started");
        yield return new WaitForSeconds(reloadTime);
        //Debug.LogError("CoroutineReloadin ended");
        isReloading = false;
        ammoInMag = magSize;
    }
    
}



