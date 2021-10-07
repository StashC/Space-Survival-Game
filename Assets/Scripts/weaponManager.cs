using UnityEngine;
using System.Collections;

public class weaponManager : MonoBehaviour
{
    //putting all the weapons into an array
    public GameObject[] weapons;

    //which gun is default (arrays in coding start with 0)
    public int selectedWeapon = 0;

    private int numberOfWeapons;

    void Start()
    { 

        numberOfWeapons = weapons.Length;

        SwitchWeapon(selectedWeapon); // Set default gun

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
    }
    void Update()
    {
       
        for (int i = 1; i <= numberOfWeapons; i++)
        {
            if (Input.GetKeyDown("" + i))
            {
                //because arrays start at 0 this makes the 1 key switch to the first (0) weapon and 2 key to the second (1) weapon
                selectedWeapon = i - 1;
                //switches weapon
                SwitchWeapon(selectedWeapon);

            }
        }

    }

    void SwitchWeapon(int index)
    {

        for (int i = 0; i < numberOfWeapons; i++)
        {
            if (i == index)
            {
                weapons[i].gameObject.SetActive(true);
            }
            else
            {
                weapons[i].gameObject.SetActive(false);
            }
        }
    }

}