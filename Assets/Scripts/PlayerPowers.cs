using UnityEngine;

public class PlayerPowers : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shield"))
        {
            //Ativar escudo
        }

        if (other.CompareTag("CoinMultiplier"))
        {
            //Ativar multiplicador
        }

    }

}
