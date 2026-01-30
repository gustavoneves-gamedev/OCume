using UnityEngine;

public class UIController : MonoBehaviour
{

    [Header("MainMenu")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject pauseMenu;

    [Header("Reference")]
    public PlayerRoot playerRoot;

    void Start()
    {
        GameController.gameController.uiController = this;

        Invoke("Initialize", .1f);
    }

    private void Initialize()
    {
        playerRoot = GameController.gameController.playerRoot;
    }

    public void BeginRun()
    {
        mainMenu.SetActive(false);
        GameController.gameController.BeginRun();
    }

    //MUDAR ISSO PARA ALTERAR O TIME SCALE PARA ZERO. DO CONTRÁRIO ESTAREI PARANDO APENAS O PLAYER!!
    public void PauseMenu()
    {
        //Temporariamente a pause vai direto para o Menu principal        
        pauseMenu.SetActive(!pauseMenu.activeSelf);

        playerRoot.canRun = !playerRoot.canRun;

        //playerRoot.EndRun();
    }

    public void BackToMainMenu()
    {
        pauseMenu.SetActive(false);


        playerRoot.EndRun();

        mainMenu.SetActive(true);
    }



    #region Character Selection

    public void SelectCowboy()
    {
        GameController.gameController.playerRoot.selectedCharacter = characterID.Cowboy;
        GameController.gameController.playerRoot.Initialize(characterID.Cowboy);
    }

    public void SelectSamurai()
    {
        GameController.gameController.playerRoot.selectedCharacter = characterID.Samurai;
        GameController.gameController.playerRoot.Initialize(characterID.Samurai);
    }

    public void SelectAlpinista()
    {
        GameController.gameController.playerRoot.selectedCharacter = characterID.Alpinista;
        GameController.gameController.playerRoot.Initialize(characterID.Alpinista);
    }


    #endregion


    #region Level Selection

    public void SelectCowboyLevel()
    {
        GameController.gameController.currentLevelID = levelID.CowboyLevel;
        GameController.gameController.currentLevelCheckpoint = GameController.gameController.cowboyLevelCheckpoint;
        GameController.gameController.InitilizeLevelStatics();
    }

    public void SelectSamuraiLevel()
    {
        GameController.gameController.currentLevelID = levelID.SamuraiLevel;
        GameController.gameController.currentLevelCheckpoint = GameController.gameController.samuraiLevelCheckpoint;
        GameController.gameController.InitilizeLevelStatics();
    }

    public void SelectAlpinistaLevel()
    {
        GameController.gameController.currentLevelID = levelID.AlpinistaLevel;
        GameController.gameController.currentLevelCheckpoint = GameController.gameController.alpinistaLevelCheckpoint;
        GameController.gameController.InitilizeLevelStatics();
    }

    #endregion

    #region Run HUD

    public void UpdateHUD()
    {

    }

    #endregion
}
