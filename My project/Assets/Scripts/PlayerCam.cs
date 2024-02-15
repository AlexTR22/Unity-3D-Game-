using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;
using UnityEngine.WSA;

public class NewBehaviourScript : MonoBehaviour
{
    public float sensX;
    public float sensY;
    public Transform orentation;

    float rotationX;
    float rotationY;
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = UnityEngine.Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = UnityEngine.Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        rotationY += mouseX;

        rotationX -= mouseY;
        
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.rotation = Quaternion.Euler(rotationX, rotationY,0);
        orentation.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}
