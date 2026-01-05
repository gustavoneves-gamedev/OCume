using UnityEngine;

public class PlayerRoot : MonoBehaviour
{

    [Header("Status")]
    [SerializeField] private float verticalSpeed;
    [SerializeField] private float horizontalSpeed;

    [Header("PowerUps")]
    [SerializeField] public int normalCoinMultiplier = 1;
    [SerializeField] public int rubyMultiplier = 1;

    [Header("References")]
    [SerializeField] private CharacterController cc;

    private Vector3 move;
    private int desiredLane = 0;
    public bool isChangingLane; //IPC: Não está funcionando ainda porque vou colocar um trigger no meio das lanes para
    //o script detectar quando o jogador finalizar a troca de lane

    
    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        normalCoinMultiplier = 1;
        rubyMultiplier = 1;
    }


    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        move = transform.forward * verticalSpeed;

        if (Input.GetKeyDown(KeyCode.D) && desiredLane < 1 && !isChangingLane)
        {
            desiredLane = desiredLane + 1;
            //isChangingLane = true;
        }

        if (Input.GetKeyDown(KeyCode.A) && desiredLane > -1 && !isChangingLane)
        {
            desiredLane = desiredLane - 1;
            //isChangingLane = true;
        }

        float targetX = Mathf.Lerp(transform.position.x, desiredLane * 4, horizontalSpeed * Time.deltaTime);

        move.x = (targetX - transform.position.x) / Time.deltaTime;

        
        cc.Move(move * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            GameController.gameController.UpdateRunCoins(normalCoinMultiplier);
            other.gameObject.SetActive(false);
        }
        
        if(other.CompareTag("Ruby"))
        {
            GameController.gameController.UpdateRunCoins(0, rubyMultiplier);
            other.gameObject.SetActive(false);
        }
    }

}
