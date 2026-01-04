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
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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

        move.x = Mathf.Lerp(transform.position.x, desiredLane, horizontalSpeed);
        

        cc.Move(move * Time.deltaTime);
    }
}
