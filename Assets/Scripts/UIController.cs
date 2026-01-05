using UnityEngine;

public class UIController : MonoBehaviour
{
    

    void Start()
    {
        GameController.gameController.uiController = this;
    }

    
   
}
