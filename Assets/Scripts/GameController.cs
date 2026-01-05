using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController gameController;

    [Header("Run")]
    public bool isRunning;
    public int runNormalCoins;
    public int runRubies;

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

    #region Run

    public void UpdateRunCoins(int normalCoins = 0, int rubies = 0)
    {
        runNormalCoins += normalCoins;

        runRubies += rubies;
    }


    #endregion

}
