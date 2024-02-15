using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed;

    public float groundDrag;
    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask ground;
    bool grounded;
    
    public Transform orientation;

    Rigidbody rb;

    Vector3 movingDirection;
    float horizontalInput;
    float verticalInput;


    // Start is called before the first frame update
    private void Start()
    {
        rb=GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        //prinu element este pozitia jucatorului
        //al doilea este directia in care calculam, fiind in jos
        //a 3-a este distanta pana la obiectul cu care facem coliziune, astfel in cazul de fata este jumate +0.2 din inaltima playerului
        //a 4-a este un tag/LayerMask pentru ca LayerMask pentru ca asta cere care reprezinta efectiv pe obiectul cu care fac contact
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ground);

        MovePlayer();

        if (grounded) 
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }
    // Update is called once per frame
    private void Update()
    {

        MyPlayerInput();   
    }

    private void MyPlayerInput()
    {
        horizontalInput = UnityEngine.Input.GetAxisRaw("Horizontal");
        verticalInput= UnityEngine.Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        movingDirection = orientation.forward * verticalInput + orientation.right*horizontalInput;
        rb.AddForce(movingDirection.normalized*movementSpeed*10f,ForceMode.Force);
    }
}
