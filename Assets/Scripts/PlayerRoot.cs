using UnityEngine;

public class PlayerRoot : MonoBehaviour
{

    [Header("Status")]
    [SerializeField] private float verticalSpeed;
    [SerializeField] private float horizontalSpeed;

    [Header("References")]
    [SerializeField] private CharacterController cc;

    private Vector3 move;
    private int desiredLane = 0;
    private bool isChangingLane;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        move = transform.forward * verticalSpeed;

        if (Input.GetKeyDown(KeyCode.D) && desiredLane < 1)
        {
            desiredLane = desiredLane + 1;
        }

        if (Input.GetKeyDown(KeyCode.A) && desiredLane > -1)
        {
            desiredLane = desiredLane - 1;
        }

        float targetX = Mathf.Lerp(transform.position.x, desiredLane * 4, horizontalSpeed * Time.deltaTime);

        move.x = (targetX - transform.position.x) / Time.deltaTime;


        cc.Move(move * Time.deltaTime);
    }
}
