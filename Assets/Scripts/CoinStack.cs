using UnityEngine;

public class CoinStack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.gameController.isRunning) return;
        Destroy(gameObject, 1f);
    }
}
