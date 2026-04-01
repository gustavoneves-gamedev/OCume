using UnityEngine;

public class PlayerPowers : MonoBehaviour
{
    [Header("Shield")]
    public bool isShieldUp;
    [SerializeField] private GameObject shield;
    private int shieldCharges = 1;
    private int defaultShieldCharges;
    [SerializeField] private float shieldDuration;
    private float baseShieldDuration = 20f;
    private float defaultShieldDuration;

    [Header("Stamina Potion")]
    private float basePotionRestauration = 10f;
    private float potionRestauration;

    [Header("Coin Multiplier")]
    [SerializeField] private bool isCoinMultiplierOn;
    private float coinMultiplier = 2f;
    private float multiplierDuration = 10f;
    private float defaultMultiplierDuration;

    private PlayerRoot player;
    private Inventory inventory;


    void Start()
    {
        GameController.gameController.playerPowers = this;
        player = GetComponent<PlayerRoot>();

        //PERIGOSO PORQUE DEPENDE DE O INVENTÁRIO JÁ TER SE ALIMENTADO NO GAMECONTROLLER
        inventory = GameController.gameController.inventory;

        InitilizePowers();
        ResetPowers();
    }

    void Update()
    {
        CoinMultiplierCountdown();
        ShieldCountdown();
    }

    //IPC: Acho que vou passar esse cálculo para o invetory e puxar só os valores finais
    private void InitilizePowers()
    {
        //Shield
        shieldDuration = baseShieldDuration +
            inventory.shieldDurationUpgrade * inventory.shieldUpgradeFactor;

        shieldCharges = inventory.shieldChargeUpgrade;

        defaultShieldCharges = shieldCharges;
        defaultShieldDuration = shieldDuration;

        //Potion        
        potionRestauration = basePotionRestauration + 
            inventory.staminaPotionUpgrade * inventory.staminaPotionUpgradeFactor;        

        //Coin Multiplier
        //multiplierDuration += Inventory...
        //coinMultiplier += Inventory...
        defaultMultiplierDuration = multiplierDuration;
    }

    public void ResetPowers()
    {
        //Escudo
        isShieldUp = false;
        shield.SetActive(false);
        shieldCharges = defaultShieldCharges;
        shieldDuration = defaultShieldDuration;

        //Multiplicador de moedas        
        multiplierDuration = defaultMultiplierDuration;
        player.normalCoinMultiplier = 1;
    }

    #region Shield

    public void Shield(float x = 0)
    {
        if (shieldCharges > 1 && isShieldUp && x < 0)
        {
            shieldCharges--;
        }
        else if (isShieldUp && x >= 0)
        {
            shieldCharges = defaultShieldCharges;
            shieldDuration = defaultShieldDuration;
        }
        else
        {
            isShieldUp = !isShieldUp;
            shield.SetActive(!shield.activeSelf);
            shieldDuration = defaultShieldDuration;
        }
    }

    private void ShieldCountdown()
    {
        if (isShieldUp)
        {
            shieldDuration -= Time.deltaTime;

            if (shieldDuration <= 0)
            {
                isShieldUp = false;
                shieldDuration = defaultShieldDuration;
                shield.SetActive(false);
            }
        }
    }

    #endregion

    #region Coin Multiplier
    private void CoinMultiplier()
    {
        if (isCoinMultiplierOn)
        {
            multiplierDuration = defaultMultiplierDuration;
        }
        else
        {
            isCoinMultiplierOn = true;
            player.normalCoinMultiplier += coinMultiplier;
        }
    }

    private void CoinMultiplierCountdown()
    {
        if (isCoinMultiplierOn)
        {
            multiplierDuration -= Time.deltaTime;

            if (multiplierDuration <= 0)
            {
                isCoinMultiplierOn = false;
                multiplierDuration = defaultMultiplierDuration;
                player.normalCoinMultiplier = 1;
            }
        }
    }

    #endregion

    #region Special



    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shield"))
        {
            Shield();
            //Tocar som de escudo subindo
            Destroy(other.gameObject);
        }

        if (other.CompareTag("StaminaPotion"))
        {
            player.UpdateStamina(potionRestauration);
            //Tocar som de stamina recuperando
            Destroy(other.gameObject);
        }

        if (other.CompareTag("CoinMultiplier"))
        {
            CoinMultiplier();
            //Ativar multiplicador
        }


    }

}
