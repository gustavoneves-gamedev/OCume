using UnityEngine;

public class PlayerRoot : MonoBehaviour
{

    [Header("Status")]
    public float currentStamina;
    public float maxStamina;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float horizontalSpeed;     
    public float damage;
    public float cooldown;
    public int ammo;
    public float defense;
    public float resistance;

    [Header("PowerUps")]
    [SerializeField] public int normalCoinMultiplier = 1;
    [SerializeField] public int rubyMultiplier = 1;

    [Header("References")]
    [SerializeField] private CharacterController cc;
    private characterID selectedCharacter = characterID.Cowboy;
    [SerializeField] private CharacterData[] characterDatas;

    private Vector3 move;
    private int desiredLane = 0;
    public bool isChangingLane; //IPC: Não está funcionando ainda porque vou colocar um trigger no meio das lanes para
    //o script detectar quando o jogador finalizar a troca de lane

    
    void Start()
    {
        GameController.gameController.playerRoot = this;
        Initialize(selectedCharacter);
    }

    private void Initialize(characterID selectedChar)
    {
        normalCoinMultiplier = 1;
        rubyMultiplier = 1;

        if (selectedChar == characterID.Cowboy)
            InitializeCowboy();

    }

    private void InitializeCowboy()
    {
        // ProgressManager.progressManager.staminaUpgrades
        maxStamina = characterDatas[0].baseMaxStamina +
            ProgressManager.progressManager.staminaUpgrades * ProgressManager.progressManager.staminaUpgradeFactor;

        movementSpeed = characterDatas[0].baseMovementSpeed +
            ProgressManager.progressManager.movementSpeedUpgrades * ProgressManager.progressManager.movementSpeedUpgradeFactor;

        damage = characterDatas[0].baseDamage +
            ProgressManager.progressManager.damageUpgrades * ProgressManager.progressManager.damageUpgradeFactor;

        cooldown = characterDatas[0].baseCooldown +
            ProgressManager.progressManager.cooldownUpgrades * ProgressManager.progressManager.cooldownUpgradeFactor;

        ammo = characterDatas[0].baseAmmo +
            ProgressManager.progressManager.ammoUpgrades * ProgressManager.progressManager.ammoUpgradeFactor;

        defense = characterDatas[0].baseDefense +
            ProgressManager.progressManager.defenseUpgrades * ProgressManager.progressManager.defenseUpgradeFactor;

        resistance = characterDatas[0].baseResistance +
            ProgressManager.progressManager.resistanceUpgrades * ProgressManager.progressManager.resistanceUpgradeFactor;

    }




    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        move = transform.forward * movementSpeed;

        if (Input.GetKeyDown(KeyCode.D) && desiredLane < 1 && !isChangingLane)
        {
            desiredLane = desiredLane + 1;
            //isChangingLane = true;
        }

        if (Input.GetKeyDown(KeyCode.A) && desiredLane > -1 && !isChangingLane)
        {
            desiredLane = desiredLane - 1;
            //isChangingLane = true;
        }

        float targetX = Mathf.Lerp(transform.position.x, desiredLane * 4, horizontalSpeed * Time.deltaTime);

        move.x = (targetX - transform.position.x) / Time.deltaTime;

        
        cc.Move(move * Time.deltaTime);
    }

    public void UpdateStamina(float x)
    {
        currentStamina += x;

        if (currentStamina > maxStamina)
            currentStamina = maxStamina;

        if (currentStamina <= 0)
        {
            currentStamina = 0;
            //OnDeathEvent();
        }
    }

    //Talvez eu deva criar um script de moedas para colocar isso tudo lá e
    //tocar o som delas quando o jogador as coletar. VER COM PROFESSOR O QUE PESA MENOS
    //OU POSSO COLOCAR OS SONS AQUI E TOCAR QUANDO COLETAR AS MOEDAS!! - VOU FAZER ISTO
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            GameController.gameController.UpdateRunCoins(normalCoinMultiplier);
            other.gameObject.SetActive(false);
        }
        
        if(other.CompareTag("Ruby"))
        {
            GameController.gameController.UpdateRunCoins(0, rubyMultiplier);
            other.gameObject.SetActive(false);
        }
    }

}
