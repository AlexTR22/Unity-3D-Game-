using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectMaterial : MonoBehaviour
{
    public Transform player;
    private void OnMouseDown()
    {
        if(Vector3.Distance(player.position, this.gameObject.transform.position)<5.0f)
            Destroy(this.gameObject);
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
