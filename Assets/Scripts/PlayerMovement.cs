using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 5f;
    [SerializeField] float rotspeed = 5f;
    Vector3 horizontal = new Vector3(0,0,0);
    Vector3 vertical = new Vector3(0,0,0);

    [SerializeField] LayerMask counterLayer;
    public bool isWalking = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerWalking();
        HandleInteactions();
    }
    void PlayerWalking()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        horizontal.x = horizontalInput;
        vertical.z = verticalInput; 

        // transform.position += horizontal.normalized*speed*Time.deltaTime;
        // transform.position += vertical.normalized*speed*Time.deltaTime;

        Vector3 movDir = new Vector3(horizontal.x, 0, vertical.z);
        transform.position += movDir.normalized*speed*Time.deltaTime;

        isWalking = movDir != new Vector3();

        transform.forward = Vector3.Slerp(transform.forward,movDir, Time.deltaTime*rotspeed);
    }
    
    void HandleInteactions()
    {
        RaycastHit hit;
        float interactDistance = 2f;
        if(Physics.Raycast(transform.position, transform.forward, out hit, interactDistance, counterLayer))
        {
            ClearCounter check = hit.transform.GetComponent<ClearCounter>();
            if(check == null)return;
            check.Interact();
        }
    }
}
