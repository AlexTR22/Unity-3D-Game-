using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed;
    public float groundDrag;

    [Header("Jump")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    public KeyCode jumpKey = KeyCode.Space;


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
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
    }

    private void FixedUpdate()
    {
        MovePlayer();

    }

    // Update is called once per frame
    private void Update()
    {
        //prinu element este pozitia jucatorului
        //al doilea este directia in care calculam, fiind in jos
        //a 3-a este distanta pana la obiectul cu care facem coliziune, astfel in cazul de fata este jumate +0.2 din inaltima playerului
        //a 4-a este un tag/LayerMask pentru ca LayerMask pentru ca asta cere care reprezinta efectiv pe obiectul cu care fac contact
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ground);

        MyPlayerInput();
        SpeedControl();
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void MyPlayerInput()
    {
        horizontalInput = UnityEngine.Input.GetAxisRaw("Horizontal");
        verticalInput = UnityEngine.Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            rb.velocity= new Vector3(rb.velocity.x,0f,rb.velocity.z);
            rb.AddForce(transform.up*jumpForce, ForceMode.Impulse);
            readyToJump = false;

            Invoke(nameof(ResetJump), jumpCooldown);
        }

    }

    private void MovePlayer()
    {
        movingDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (grounded)
        {
            rb.AddForce(movingDirection.normalized * movementSpeed * 10f, ForceMode.Force);
        }
        else if(!grounded)
        {
            rb.AddForce(movingDirection.normalized * movementSpeed * 10f*airMultiplier, ForceMode.Force);
        }
    }
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);
        if (flatVel.magnitude > movementSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * movementSpeed;
            rb.velocity = new Vector3(limitedVel.x, limitedVel.y, limitedVel.z);
        }
    }
    private void ResetJump()
    {
        readyToJump = true;
    }

}
