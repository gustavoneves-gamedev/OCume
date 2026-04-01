using UnityEngine;

public class PlayerPowers : MonoBehaviour
{
    [Header("Shield")]
    public bool isShieldUp;
    [SerializeField] private GameObject shield;
    private int shieldCharges = 1;
    private int defaultShieldCharges;
    [SerializeField] private float shieldDuration = 20f;
    private float defaultShieldDuration;

    [Header("Stamina Potion")]
    private float potionRestauration = 10f;

    [Header("Coin Multiplier")]
    [SerializeField] private bool isCoinMultiplierOn;
    private float coinMultiplier = 2f;
    private float multiplierDuration = 10f;
    private float defaultMultiplierDuration;

    private PlayerRoot player;


    void Start()
    {
        GameController.gameController.playerPowers = this;
        player = GetComponent<PlayerRoot>();
        InitilizePowers();
        ResetPowers();
    }

    void Update()
    {
        CoinMultiplierCountdown();
        ShieldCountdown();
    }

    private void InitilizePowers()
    {
        //Shield
        //Shield Charges += Inventory...
        defaultShieldCharges = shieldCharges;
        defaultShieldDuration = shieldDuration;

        //Potion
        //potionRestauration += Inventory...

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
