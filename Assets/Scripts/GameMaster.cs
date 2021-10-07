using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;

    [SerializeField]
    private int startLives;

    [SerializeField]
    private GameObject UpgradeUI;

    private static int _remainingLives;
    public static int remainingLives
    {
        get { return _remainingLives;  }
    }

    void Awake()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }

    public Transform playerPrefab;
    public Transform spawnPoint;
    public float spawnDelay = 2;
    public Transform spawnPrefab;
    public string spawnSoundName;
    private bool upgradeMenuOn;

    [SerializeField]
    private GameObject upgradeMenu;

    [SerializeField]
    private WaveSpawner waveSpawner;
    [SerializeField]
    private StatusIndicator playerStatusIndicator;

    public CameraShake cameraShake;

    [SerializeField]
    private GameObject gameOverUI;

    private AudioManager audioManager;
    public string PlayerRespawnSound = "PlayerSpawn";

    [SerializeField]
    private PlayerStats stats;
    [SerializeField]
    private int startingMoney;
    public static int Money;

    public delegate void UpgradeMenuCallback(bool active);
    public UpgradeMenuCallback onToggleUpgradeMenu;

    void Update()
    {
        /*UpgradeUI.SetActive(upgradeMenuOn);
        if (Input.GetKeyDown(KeyCode.U) && upgradeMenuOn)
        {
            upgradeMenuOn = false;
            Time.timeScale = 1;
        } else if (Input.GetKeyDown(KeyCode.U))
        {
            upgradeMenuOn = true;
            Time.timeScale = 0;
        }*/

        if (Input.GetKeyDown(KeyCode.U))
        {
            ToggleUpgradeMenu();
        }
    }

    void Start()
    {

        _remainingLives = startLives;
        if(cameraShake == null)
        {
            Debug.LogError("No camera shake referenced in GameMaster");
        }

        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogError("No audio manager found! FREAK OUT!");
        }

        Money = startingMoney;
        
    }

    public IEnumerator _RespawnPlayer()
    {
        audioManager.PlaySound("RespawnCountdown");
        Debug.LogError("Sound Played Panic!");
        yield return new WaitForSeconds(spawnDelay);
        audioManager.PlaySound(PlayerRespawnSound);


        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        //GameObject clone = Instantiate(spawnPrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;
        //Destroy(clone, 3f);
        playerStatusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
        audioManager.PlaySound(PlayerRespawnSound);
    }

    public void endGame()
    {
        Debug.Log("Game Over!");
        gameOverUI.SetActive(true);
        
    }

    public static void KillPlayer(Player player)
    {
        Destroy(player.gameObject);
        _remainingLives -= 1;
        if(_remainingLives <= 0)
        {
            gm.endGame();
        }else
        {
            gm.StartCoroutine(gm._RespawnPlayer());
        }
        
    }

    private void ToggleUpgradeMenu()
    {
        upgradeMenu.SetActive(!upgradeMenu.activeSelf);
        waveSpawner.enabled = !upgradeMenu.activeSelf;
        onToggleUpgradeMenu.Invoke(upgradeMenu.activeSelf);
    }

    public static void KillEnemy(Enemy enemy)
    {
        gm._KillEnemy(enemy);
    }
    public void _KillEnemy(Enemy _enemy)
    {
        GameObject _clone = Instantiate(_enemy.deathParticles.gameObject, _enemy.transform.position, Quaternion.identity) as GameObject;
        Destroy(_clone, 5f);
        cameraShake.Shake(_enemy.shakeAmt, _enemy.shakeLength);
        Destroy(_enemy.gameObject);
        Money += 15;
    }

}
