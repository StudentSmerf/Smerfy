using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    
    public void Look(float visionRange, string tag){
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag(tag))
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
    
    public void LookForG(float visionRange, float runSpeed, string EnemyTag){
        float x1, y1, x2, y2, distance;
        x2 = this.transform.position.x;
        y2 = this.transform.position.y;
        //Look if there is Gargamel nearby
        foreach (GameObject g in GameObject.FindGameObjectsWithTag(EnemyTag))
        {
            
            x1 = g.transform.position.x;
            y1 = g.transform.position.y;
            
            distance = Mathf.Sqrt((x1-x2)*(x1-x2) + (y1-y2) * (y1-y2));
            //if there is Gargamel nearby, look for Smurfs nearby
            if(distance <= visionRange){
                foreach (GameObject s in GameObject.FindGameObjectsWithTag("Smurf"))
                {
                    x1 = s.transform.position.x;
                    y1 = s.transform.position.y;
                    distance = Mathf.Sqrt((x1-x2)*(x1-x2) + (y1-y2) * (y1-y2));
                    //if there are Smurfs, tell them to run
                    if(distance <= visionRange){
                        s.GetComponent<Movement>().Move(runSpeed);
                        Debug.Log(s.name + "is Running");
                    }
                }
                return;
            }
        }
    }
}
