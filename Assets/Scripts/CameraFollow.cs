using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private Transform targetToFollow;
    [SerializeField] private float cameraSpeed = 10f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Lerp(transform.position.x,targetToFollow.position.x + positionOffset.x, cameraSpeed * Time.deltaTime);
        //float x = Mathf.Lerp(transform.position.x, targetToFollow.position.x + positionOffset.x, 0.5f);
        transform.position = new Vector3(x, transform.position.y, targetToFollow.position.z + positionOffset.z);
    }
}
