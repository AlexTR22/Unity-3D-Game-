using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public bool onTarget;

    public static SelectionManager instance { get; set; }

    public GameObject interactionInfoUI;
    Text interactionText;
    // Start is called before the first frame update
    void Start()
    {
        interactionText=interactionInfoUI.GetComponent<Text>();
        onTarget = false;
    }

    //singleton, there can only be one instance of this class
    private void Awake()
    {
        if(instance!=null && instance!=this) 
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }


    // Update is called once per frame
    void Update()
    {
        Ray ray =Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;
            if (selectionTransform.GetComponent<InteractableObject>() &&selectionTransform.GetComponent<InteractableObject>().playerInRange)
            {
                interactionText.text=selectionTransform.GetComponent<InteractableObject>().GetObjectName();
                interactionInfoUI.SetActive(true);
                onTarget = true;
            }
            else
            {
                interactionInfoUI.SetActive(false);
                onTarget = false;
            }
        }
        else 
        {
            interactionInfoUI.SetActive(false);
            onTarget = false;
        }
    }
}
