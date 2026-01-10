using UnityEngine;

public class PlayerRoot : MonoBehaviour
{
    [Header("Run")]
    [SerializeField] private bool canRun;
    public float heightClimbed;
    private float initialHeight;
    public float runHeightClimbed;
    private bool canAttack;
    //private bool canCountCheckpoint;

    [Header("Status")]
    public float currentStamina;
    public float maxStamina;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float horizontalSpeed;
    public float damage;
    public float cooldown;
    private float cooldownRemaining; //Esta variável pode ficar apenas aqui
    public int maxAmmo;
    public int currentAmmo; //Esta variável pode ficar apenas aqui
    public float reloadTime;
    private float reloadTimeRemaining; //Esta variável pode ficar apenas aqui
    public float defense;
    public float resistance;
    

    [Header("PowerUps")]
    [SerializeField] public int normalCoinMultiplier = 1;
    [SerializeField] public int rubyMultiplier = 1;

    [Header("References")]
    [SerializeField] private CharacterController cc;
    public characterID selectedCharacter = characterID.Cowboy;
    [SerializeField] private CharacterData[] characterDatas;
    [SerializeField] private GameObject[] characterModels;

    private Vector3 move;
    private int desiredLane = 0;
    public bool isChangingLane; //IPC: Não está funcionando ainda porque vou colocar um trigger no meio das lanes para
                                //o script detectar quando o jogador finalizar a troca de lane


    void Start()
    {
        GameController.gameController.playerRoot = this;
        Initialize(selectedCharacter);
        
    }

    public void Initialize(characterID selectedChar)
    {
        normalCoinMultiplier = 1;
        rubyMultiplier = 1;

        //Serve para atualizar o script do progress manager e pegar o incremento correto
        ProgressManager.progressManager.UpdateIncrement(selectedChar);

        //Esconde todos os modelos
        for (int i = 0; i < characterModels.Length; i++)
        {
            characterModels[i].SetActive(false);
        }

        if (selectedChar == characterID.Cowboy)
            InitializePlayer(0);

        if (selectedChar == characterID.Samurai)
            InitializePlayer(1);

        if (selectedChar == characterID.Alpinista)
            InitializePlayer(2);

    }

    private void InitializePlayer(int charCode)
    {
        maxStamina = characterDatas[charCode].baseMaxStamina + ProgressManager.progressManager.staminaIncrement;

        movementSpeed = characterDatas[charCode].baseMovementSpeed + ProgressManager.progressManager.movementSpeedIncrement;

        damage = characterDatas[charCode].baseDamage + ProgressManager.progressManager.damageIncrement;

        cooldown = characterDatas[charCode].baseCooldown + ProgressManager.progressManager.cooldownIncrement;

        maxAmmo = characterDatas[charCode].baseAmmo + ProgressManager.progressManager.ammoIncrement;

        reloadTime = characterDatas[charCode].reloadTime + ProgressManager.progressManager.reloadIncrement;

        defense = characterDatas[charCode].baseDefense + ProgressManager.progressManager.defenseIncrement;

        resistance = characterDatas[charCode].baseResistance + ProgressManager.progressManager.resistanceIncrement;

        characterModels[charCode].SetActive(true); //Ativa o modelo do personagem selecionado

        currentStamina = maxStamina;

        //O BeginRunAnimation vai primeiro atualizar as informações do jogador e depois
        //canRun = true;

    }


    public void BeginRunAnimation()
    {


        //PlayRunAnimation -> Terei que elaborar isso aqui, definir qual animação deverá tocar (jogador está no checkpoin
        //ou no início da Run?)

        //Depois disso a animação terá um event trigger que irá mudar a bool isRunning para true. Para testes, irei colocar 
        //aqui o gatilho para começar a corrida


        BeginRunEvent();


    }

    private void BeginRunEvent()
    {
        currentAmmo = maxAmmo;
        cooldownRemaining = 0;
        reloadTimeRemaining = reloadTime;
        runHeightClimbed = 0;
        initialHeight = transform.position.z;
        canRun = true;
    }



    void Update()
    {
        if (canRun == false) return;

        PlayerMovement();
        AttackTimeCounter();
        StaminaConsumption();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canAttack == true)
                Attack();
            else if (currentAmmo <= 0)
                Debug.Log("Sem munição suficiente");
            else if (cooldownRemaining >= 0)
                Debug.Log("Ataque em cooldown ainda");        
           
        }

        //Calcula a altura escalada pelo jogador
        heightClimbed = transform.position.z - initialHeight;
    }

    private void AttackTimeCounter()
    {
        if (currentAmmo < maxAmmo)
        {
            if (reloadTimeRemaining <= 0)
            {
                currentAmmo++;
                reloadTimeRemaining = reloadTime;
            }
            else
                reloadTimeRemaining -= Time.deltaTime;
        }

        if (cooldownRemaining <= 0 && currentAmmo >= 1)
        {
            canAttack = true;
        }
        else if (cooldownRemaining >= 0)
        {
            cooldownRemaining -= Time.deltaTime;
        }

    }

    private void StaminaConsumption()
    {
        currentStamina -= ((2 - resistance/10f) * Time.deltaTime);
    }

    public void UpdateStamina(float x)
    {
        currentStamina += x;

        if (currentStamina > maxStamina)
            currentStamina = maxStamina;

        if (currentStamina <= 0)
        {
            currentStamina = 0;
            OnDeathEvent();
        }
    }

    private void Attack()
    {
        Debug.Log("Ataquei!!");
        currentAmmo--;
        cooldownRemaining = cooldown;
        canAttack = false;
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

    
    
    private void OnDeathEvent()
    {
        canRun = false;
        runHeightClimbed = heightClimbed;
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

        if (other.CompareTag("Ruby"))
        {
            GameController.gameController.UpdateRunCoins(0, rubyMultiplier);
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("Checkpoint"))
        {
            GameController.gameController.UpdateCheckpoint();
        }
    }

}
