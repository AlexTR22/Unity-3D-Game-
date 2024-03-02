using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public bool playerInRange;
  

    public string objectName;



    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) &&playerInRange && SelectionManager.instance.onTarget)
        {
            Destroy(gameObject);
            Debug.Log("Item picked");
        }
    }

    public string GetObjectName()
    {
        return objectName;
    }

    public void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.CompareTag("player"))
        {
            playerInRange = true;
            Debug.Log("true");
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "player")
            playerInRange = false;
    }
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
