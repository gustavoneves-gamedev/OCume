using UnityEngine;

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
    public LevelData currentLevelData;
    public int currentLevelCheckpoint = 0;


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
        playerRoot.transform.position = Vector3.forward * currentLevelData.checkpointDistance * 
            currentLevelData.currentCheckpoint;

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
                currentLevelData = levelArray[i];
            }
        }
    }

    public void UpdateCheckpoint()
    {
        //foreach (var levelMap in levelArray)
        //{
        //    if (levelMap.levelId == currentLevelID)
        //    {
        //        levelMap.currentCheckpoint++;
        //        return;
        //    }
        //}

        currentLevelData.currentCheckpoint++;
        
    }

    #endregion

    #region Store


    #endregion

}
