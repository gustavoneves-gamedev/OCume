using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController gameController;

    [Header("Mode")]
    [SerializeField] private bool isRunning;

    public PlayerRoot playerRoot;
    
    
    void Awake()
    {
        if (gameController == null)
        {
            gameController = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void BeginRun()
    {

    }
    
}
