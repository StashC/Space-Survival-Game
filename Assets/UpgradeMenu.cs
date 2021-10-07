using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour {

    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Text speedText;

    //Weapon texts. One = G36C, Two = sniper, three = ak, 4 = GL.
    [SerializeField]
    private Text weaponOneDamageText;
    [SerializeField]
    private Text weaponOneFirerateText;
    [SerializeField]
    private Text weaponTwoDamageText;
    [SerializeField]
    private Text weaponTwoFirerateText;
    [SerializeField]
    private Text weaponThreeDamageText;
    [SerializeField]
    private Text weaponThreeFirerateText;
    [SerializeField]
    private Text weaponFourDamageText;
    [SerializeField]
    private Text weaponFourFirerateText;

    [SerializeField]
    private int movespeedIncreaseAmt; 

    [SerializeField]
    private float healthMultiplier;
    private PlayerStats stats;

    private sniperStats sniperStats;
    private weaponStats weaponOneStats;
    private AKStats akStats;

    private GrenadeLauncherStats GLstats;
    private GrenadeStats GrenadeStats;



  [SerializeField]
    private GameObject weaponDisplayOne;
    [SerializeField]
    private GameObject weaponDisplayTwo;
    [SerializeField]
    private GameObject weaponDisplayThree;
    [SerializeField]
    private GameObject weaponDisplayFour;
    [SerializeField]
    private GameObject playerUpgrades;
  
    void Start()
    {
        stats = PlayerStats.instance;
        weaponOneStats = weaponStats.instance;
        sniperStats = sniperStats.instance;
        akStats = AKStats.instance;
        GrenadeStats = GrenadeStats.instance;
        GLstats = GrenadeLauncherStats.instance;
        UpdateValues();

    }

    void OnEnable()
    {
        UpdateValues();
    }

    void UpdateValues()
    {
        healthText.text = "Health: " + stats.maxHealth.ToString();
        speedText.text = "Speed:  " + stats.movementSpeed.ToString();
        weaponOneDamageText.text = "Damage: " + weaponOneStats.damage.ToString();
        weaponOneFirerateText.text = "Firerate: " + weaponOneStats.fireRate.ToString();
        weaponTwoDamageText.text = "Damage: " + sniperStats.damage.ToString();
        weaponTwoFirerateText.text = "Firerate: " + sniperStats.fireRate.ToString();
        weaponThreeDamageText.text = "Damage: " + akStats.damage.ToString();
        weaponThreeFirerateText.text = "Firerate: " + akStats.fireRate.ToString();
        weaponFourFirerateText.text = "Firerate: " + GLstats.GLFireRate.ToString();
        weaponFourDamageText.text = "Damage: " + GrenadeStats.damage.ToString();
    }

    public void UpgradeHealth()
    {
        if (GameMaster.Money < 75)
        {
            return;
            //play a sound
        }
        else
        {
            stats.maxHealth = (int)(stats.maxHealth * healthMultiplier);
            //Debug.LogError(stats.maxHealth);
            stats.curHealth += 25;
            UpdateValues();
            GameMaster.Money -= 75;
        }
    }

    /*DAMAGE UPGRADES************************************/
    //**************************************************/
    public void UpgradeDamageOne()
    {
        if(GameMaster.Money < 50)
        {
            return;
            //play sound
        }
        GameMaster.Money -= 50;
        weaponOneStats.damage += 5;
        UpdateValues();
        
       
    }
    public void UpgradeDamageTwo()
    {
        if(GameMaster.Money < 50)
        {
            return;
            //play sound
        }
        GameMaster.Money -= 50;
        sniperStats.damage += 25;
        UpdateValues();
    }
    public void UpgradeDamageThree()
    {
        if(GameMaster.Money < 50)
        {
            return;
            //playsound
        }
        GameMaster.Money -= 50;
        akStats.damage += 8;
        UpdateValues();
    }

    public void UpgradeDamageFour()
    {
        if (GameMaster.Money < 50)
        {
            return;
            //playsound
        }
        GameMaster.Money -= 50;
        GrenadeStats.damage += 20;
        UpdateValues();
    }
    /*FireRate UPGRADES************************************/
    //**************************************************/
    public void UpgradeFireRateOne()
    {
        if(GameMaster.Money < 75)
        {
            return;
            //playsound
        }
        GameMaster.Money -= 75;
        weaponOneStats.fireRate += 1;
        UpdateValues();
    }
    public void UpgradeFireRateTwo()
    {
        if(GameMaster.Money < 100)
        {
            return;
            //playsound
        }
        GameMaster.Money -= 100;
        sniperStats.fireRate += .5f;
        UpdateValues();
    }
    public void UpgradeFireRateThree()
    {
        if(GameMaster.Money < 75)
        {
            return;
            //play sound
        }
        GameMaster.Money -= 75;
        akStats.fireRate += 1;
        UpdateValues();
    }
    public void UpgradeFireRateFour()
    {
        if (GameMaster.Money < 75)
        {
            return;
            //play sound
        }
        GameMaster.Money -= 75;
        GLstats.GLFireRate += .25f;
        UpdateValues();
    }

    public void UpgradeSpeed()
    {
        if (GameMaster.Money < 25)
        {
            return;
            //playsound
        }
        GameMaster.Money -= 25;
        stats.movementSpeed += movespeedIncreaseAmt;
        UpdateValues();
    }
    public void displayWeaponOne()
    {
        weaponDisplayOne.gameObject.SetActive(true);
        weaponDisplayTwo.gameObject.SetActive(false);
        weaponDisplayThree.gameObject.SetActive(false);
        weaponDisplayFour.gameObject.SetActive(false);
        playerUpgrades.gameObject.SetActive(false);
    }
    public void displayWeaponTwo()
    {
        weaponDisplayTwo.gameObject.SetActive(true);
        weaponDisplayOne.gameObject.SetActive(false);
        weaponDisplayThree.gameObject.SetActive(false);
        weaponDisplayFour.gameObject.SetActive(false);
        playerUpgrades.gameObject.SetActive(false);
    }
    public void displayWeaponThree()
    {
        weaponDisplayThree.gameObject.SetActive(true);
        weaponDisplayOne.gameObject.SetActive(false);
        weaponDisplayTwo.gameObject.SetActive(false);
        weaponDisplayFour.gameObject.SetActive(false);
        playerUpgrades.gameObject.SetActive(false);
    }
    public void displayWeaponFour()
    {
        weaponDisplayFour.gameObject.SetActive(true);
        weaponDisplayTwo.gameObject.SetActive(false);
        weaponDisplayThree.gameObject.SetActive(false);
        weaponDisplayOne.gameObject.SetActive(false);
        playerUpgrades.gameObject.SetActive(false);
    }
    public void displayPlayerUpgrades()
    {
        playerUpgrades.gameObject.SetActive(true);
        weaponDisplayFour.gameObject.SetActive(false);
        weaponDisplayTwo.gameObject.SetActive(false);
        weaponDisplayThree.gameObject.SetActive(false);
        weaponDisplayOne.gameObject.SetActive(false);
    }
}
