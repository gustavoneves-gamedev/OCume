using UnityEngine;

public class UIController : MonoBehaviour
{
    

    void Start()
    {
        GameController.gameController.uiController = this;
    }

    public void BeginRun()
    {
        GameController.gameController.playerRoot.BeginRunAnimation();
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

    
}
