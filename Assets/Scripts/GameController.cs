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
        playerRoot.ResetPosition(new Vector3(0, 0, currentLevelCheckpointDistance *
            currentLevelCheckpoint));


       // playerRoot.transform.position = new Vector3 ( 0, 0, currentLevelCheckpointDistance * currentLevelCheckpoint);

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

    //Preciso melhorar isto, mas acho que será necessário fazer um script para o level primeiro
    public void InitilizeLevelStatics()
    {
        //coloquei var aqui porque é mais fácil do que escrever levelData, mas não sei se é mais pesado ou não
        //foreach (var level in levelArray) 
        //{
        //    if (level.levelId == levelID.AlpinistaLevel)
        //    {

        //    }
        //}

        for (int i = 0; i < levelArray.Length; i++)
        {
            if (currentLevelID == levelArray[i].levelId)
            {
                //currentLevelData = levelArray[i];
                currentLevelCheckpointDistance = levelArray[i].checkpointDistance;
                
            }
        }
    }

    public void UpdateCheckpoint()
    {
        
        if (currentLevelID == levelID.CowboyLevel)
        {
            cowboyLevelCheckpoint++;
            return;
        }

        if (currentLevelID == levelID.SamuraiLevel)
        {
            samuraiLevelCheckpoint++;
            return;
        }

        if (currentLevelID == levelID.AlpinistaLevel)
        {
            alpinistaLevelCheckpoint++;
            return;
        }


        //foreach (var levelMap in levelArray)
        //{
        //    if (levelMap.levelId == currentLevelID)
        //    {
        //        levelMap.currentCheckpoint++;
        //        return;
        //    }
        //}

        //currentLevelData.currentCheckpoint++;

    }

    #endregion

    #region Store


    #endregion

}
