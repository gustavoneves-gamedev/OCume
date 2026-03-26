using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinID = 0;
    private MeshRenderer meshRenderer;
    private GameObject parent;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject,30f);
        meshRenderer = GetComponent<MeshRenderer>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.gameController.isRunning) return;
        Destroy(parent, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (coinID == 0) GameController.gameController.UpdateRunCoins(1, 0);
            if (coinID == 1) GameController.gameController.UpdateRunCoins(0, 1);

            meshRenderer.enabled = false;
            Destroy(gameObject, 2f);
        }
    }

}
