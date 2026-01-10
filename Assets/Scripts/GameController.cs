using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController gameController;

    [Header("Run")]
    public bool isRunning;
    public int runNormalCoins;
    public int runRubies;

    [Header("Levels")]
    [SerializeField] private LevelData[] levels;


    public PlayerRoot playerRoot;
    public UIController uiController;
    
    
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

    private void Start()
    {
        InitilizeLevelStatics();
    }

    public void BeginRun()
    {

    }

    #region Main Menu



    #endregion

    #region Run

    public void UpdateRunCoins(int normalCoins = 0, int rubies = 0)
    {
        runNormalCoins += normalCoins;

        runRubies += rubies;
    }


    #endregion

    #region Level

    private void InitilizeLevelStatics()
    {

    }

    #endregion

    #region Store


    #endregion

}
