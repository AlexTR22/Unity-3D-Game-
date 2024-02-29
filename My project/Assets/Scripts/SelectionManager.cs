using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public GameObject interactionInfoUI;
    Text interactionText;
    // Start is called before the first frame update
    void Start()
    {
        interactionText=interactionInfoUI.GetComponent<Text>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray =Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;
            if (selectionTransform.GetComponent<InteractableObject>())
            {
                interactionText.text=selectionTransform.GetComponent<InteractableObject>().GetObjectName();
                interactionInfoUI.SetActive(true);
            }
            else
            {
                interactionInfoUI.SetActive(false);
            }
        }
    }
}
