using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Smurf"){
            collision.gameObject.GetComponent<GetPickedUp>().Pick("Smurf");
        }
        else
        {
            collision.gameObject.GetComponent<GetPickedUp>().Pick("");
        }
    }
    
}
