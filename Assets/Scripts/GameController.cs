using UnityEngine;
using UnityEngine.LowLevel;

public class GameController : MonoBehaviour
{
    public static GameController gameController;

    [Header("Run")]
    public bool isRunning;
    public int runNormalCoins;
    public int runRubies;

    //IMPORTANTE: DEPOIS TENHO QUE OTIMIZAR ISSO PORQUE VAI ACABAR VIRANDO UM MONSTRO CONFORME FOR ADICIONANDO FASES
    [Header("Levels")]
    [SerializeField] private LevelData[] levelArray;
    public levelID currentLevelID = levelID.CowboyLevel;
    //public levelID lastLevelID;
    //public LevelData currentLevelData;
    public int currentLevelCheckpoint = 0;
    public float currentLevelCheckpointDistance;
    public int cowboyLevelCheckpoint;
    public float cowboyLevelBestHeight;
    public int samuraiLevelCheckpoint;
    public float samuraiLevelBestHeight;
    public int alpinistaLevelCheckpoint;
    public float alpinistaLevelBestHeight;

    [Header("Infinity Level")]
    public bool isInfinityRun;
    public float bestHeight;
    //public float bestWeekHeight;


    public PlayerRoot playerRoot;
    public UIController uiController;
    public LevelManager levelManager;
    
    
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
        //currentLevelID = lastLevel;
        InitilizeLevelStatics();
    }

    public void BeginRun()
    {
       //Reseta a posição do jogador com base no checkpoint desbloqueado da fase
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

    public void UpdateBestHeight(float totalHeight)
    {
        if (currentLevelID == levelID.CowboyLevel && totalHeight > cowboyLevelBestHeight)
        {
            cowboyLevelBestHeight = totalHeight;
            //currentLevelCheckpoint++;
            return;
        }

        if (currentLevelID == levelID.SamuraiLevel && totalHeight > samuraiLevelBestHeight)
        {
            samuraiLevelBestHeight = totalHeight;
            //currentLevelCheckpoint++;
            return;
        }

        if (currentLevelID == levelID.AlpinistaLevel && totalHeight > alpinistaLevelBestHeight)
        {
            alpinistaLevelBestHeight = totalHeight;
            return;
        }
    }

    #endregion

    #region Store


    #endregion

}
