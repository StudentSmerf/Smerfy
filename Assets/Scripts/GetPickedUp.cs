using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPickedUp : MonoBehaviour
{
    public void Pick(string name){
        
        switch (name)
            {
                //Smurf being picked up
                case "Smurf":
                    this.transform.position = new Vector3(this.transform.position.x - 200f, 0 , 0);
                    Debug.Log("Point for G");
                    PointCounter.pointcounter.AddingPGargamel();
                    break;
                //Berries being picked up
                case "Bush":
                    this.transform.position = new Vector3(0, this.transform.position.y + 200f, 0);
                    Debug.Log("Point for S");
                    PointCounter.pointcounter.AddingPSmurfs();
                    break;
                default:
                    Debug.Log(this.gameObject.name + "fell in water");
                    this.transform.position = new Vector3(0, this.transform.position.y - 200f, 0);
                    break;
            }
    }
}
