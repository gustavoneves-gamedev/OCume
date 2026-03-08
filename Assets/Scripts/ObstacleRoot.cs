using UnityEngine;

public class ObstacleRoot : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Colidi com algo");
            Destroy(gameObject, 1f);
            obstacle.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
