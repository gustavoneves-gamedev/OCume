using UnityEngine;

public class PlayerRoot : MonoBehaviour
{
    [Header("Run")]
    [SerializeField] private bool canRun;
    public float heightClimbed;
    private float initialHeight;
    public float runHeightClimbed;

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

        ammo = characterDatas[charCode].baseAmmo + ProgressManager.progressManager.ammoIncrement;

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
        runHeightClimbed = 0;
        initialHeight = transform.position.z;
        canRun = true;
    }


    
    void Update()
    {
        if (canRun == false) return;
        
        PlayerMovement();

        heightClimbed = transform.position.z - initialHeight;
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
            OnDeathEvent();
        }
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
        
        if(other.CompareTag("Ruby"))
        {
            GameController.gameController.UpdateRunCoins(0, rubyMultiplier);
            other.gameObject.SetActive(false);
        }
    }

}
