using UnityEngine;

public class PlayerPowers : MonoBehaviour
{
    [Header("Shield")]
    public bool isShieldUp;
    [SerializeField] private GameObject shield;

    private PlayerRoot player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<PlayerRoot>();
        ResetPowers();
    }

    public void ResetPowers()
    {
        isShieldUp = false;
        shield.SetActive(false);
    }

    public void Shield()
    {
        isShieldUp = !isShieldUp;
        shield.SetActive(!shield.activeSelf);        
    }    
    

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
            player.UpdateStamina(10f);
            //Tocar som de escudo subindo
            Destroy(other.gameObject);
        }

        if (other.CompareTag("CoinMultiplier"))
        {
            //Ativar multiplicador
        }


    }

}
