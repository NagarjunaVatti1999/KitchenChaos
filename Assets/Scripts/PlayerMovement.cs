using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IKitchenObjectParent
{
    // Start is called before the first frame update
    [SerializeField] float speed = 5f;
    [SerializeField] float rotspeed = 5f;
    Vector3 horizontal = new Vector3(0,0,0);
    Vector3 vertical = new Vector3(0,0,0);
    [SerializeField] BaseCounter selectedCounter;
    [SerializeField] GameInput gameInput;
    [SerializeField] Transform KitchenObjectHoldPoint;
    [SerializeField] LayerMask counterLayer;
    private KithenObjects spawnedObject;
    public bool isWalking = false;
    void Start()
    {
        gameInput.OnInteract += GameInput_OnInteractAction;
        gameInput.OnInteractAlternate += GameInput_OnInteractAlternateAction;
    }

    // Update is called once per frame
    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        if(selectedCounter !=null)
        {
            selectedCounter.Interact(this);
        }
    }
    private void GameInput_OnInteractAlternateAction(object sender, System.EventArgs e)
    {
        if(selectedCounter !=null)
        {
            selectedCounter.InteractAlternate(this);
        }
    }
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
            BaseCounter check = hit.transform.GetComponent<BaseCounter>();
            if(check == null)
            {
                selectedCounter = null;
                return;
            }
            if(check != selectedCounter)
            {
                selectedCounter = check;
            }
        }
        else selectedCounter = null; //if Raycast doesn't hit anything then selected couter should be made null to deselect past counter
     }

    public Transform GetCounterShiftingTransform() //will be called from KitchenObject which will send the new position
    {
        return KitchenObjectHoldPoint;
;
    }
     public void SetKitchenObject(KithenObjects ko)
    {
        spawnedObject = ko;
    }
    public KithenObjects GetKithenObjects()
    {
        return spawnedObject;
    }
    public void ClearKitchenObject()
    {
        spawnedObject = null;
    }
    public bool HasKitchenObject()
    {
        return spawnedObject !=null;
    }
}
