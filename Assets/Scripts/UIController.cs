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
    }

    public void SelectSamurai()
    {
        GameController.gameController.playerRoot.selectedCharacter = characterID.Samurai;
    }

    public void SelectAlpinista()
    {
        GameController.gameController.playerRoot.selectedCharacter = characterID.Alpinista;
    }


    #endregion

    
}
