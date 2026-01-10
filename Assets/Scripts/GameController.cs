using UnityEngine;
using UnityEngine.LowLevel;

public class GameController : MonoBehaviour
{
    public static GameController gameController;

    [Header("Run")]
    public bool isRunning;
    public int runNormalCoins;
    public int runRubies;

    [Header("Levels")]
    [SerializeField] private LevelData[] levelArray;
    public levelID currentLevelID = levelID.CowboyLevel;
    //public LevelData currentLevelData;
    public int currentLevelCheckpoint = 0;
    public float currentLevelCheckpointDistance;
    public int cowboyLevelCheckpoint;
    public int samuraiLevelCheckpoint;
    public int alpinistaLevelCheckpoint;


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
       Vector3 worldPos = Vector3.forward * currentLevelCheckpointDistance * currentLevelCheckpoint;

        playerRoot.ResetPosition(worldPos);       

        playerRoot.BeginRunAnimation();
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

    
    public void InitilizeLevelStatics()
    {
        
        for (int i = 0; i < levelArray.Length; i++)
        {
            if (currentLevelID == levelArray[i].levelId)
            {
                
                currentLevelCheckpointDistance = levelArray[i].checkpointDistance;
                
            }
        }
    }

    public void UpdateCheckpoint()
    {
        currentLevelCheckpoint++;

        if (currentLevelID == levelID.CowboyLevel)
        {
            cowboyLevelCheckpoint++;
            //currentLevelCheckpoint++;
            return;
        }

        if (currentLevelID == levelID.SamuraiLevel)
        {
            samuraiLevelCheckpoint++;
            //currentLevelCheckpoint++;
            return;
        }

        if (currentLevelID == levelID.AlpinistaLevel)
        {
            alpinistaLevelCheckpoint++;
            return;
        }



    }

    #endregion

    #region Store


    #endregion

}
