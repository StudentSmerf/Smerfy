using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    
    public void Look(float visionRange, List<GameObject> Objects){


        foreach (GameObject obj in Objects)
        {
            float x1, y1, x2, y2, distance;
            x1 = obj.transform.position.x;
            y1 = obj.transform.position.y;
            x2 = this.transform.position.x;
            y2 = this.transform.position.y;
            distance = Mathf.Sqrt((x1-x2)*(x1-x2) + (y1-y2)*(y1-y2));
            if(distance <= visionRange){
                obj.GetComponent<GetPickedUp>().Pick();
            }
            
        }
    }
    
    public void LookForG(float visionRange, float speed, List<GameObject> Gargamels, List<GameObject> Smurfs){
        float x1, y1, x2, y2, distance;
        x2 = this.transform.position.x;
        y2 = this.transform.position.y;
        //Look if there is Gargamel nearby
        foreach (GameObject g in Gargamels)
        {
            
            x1 = g.transform.position.x;
            y1 = g.transform.position.y;
            
            distance = Mathf.Sqrt((x1-x2)*(x1-x2) + (y1-y2) * (y1-y2));
            //if there is Gargamel nearby, look for Smurfs nearby
            if(distance <= visionRange){
                foreach (GameObject s in Smurfs)
                {
                    Smurf smurfObj = new Smurf();
                    x1 = s.transform.position.x;
                    y1 = s.transform.position.y;
                    distance = Mathf.Sqrt((x1-x2)*(x1-x2) + (y1-y2) * (y1-y2));
                    //if there are Smurfs, tell them to run
                    if(distance <= visionRange){
                        smurfObj.GetSpeed(true);
                        smurfObj.MoveObject(s);
                    }
                }
            }
        }
    }
}
