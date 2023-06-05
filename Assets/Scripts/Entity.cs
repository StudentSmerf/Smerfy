using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float speed;
    public float visionRange;

    public virtual void GetSpeed(bool isRunning){}
    public virtual float GetVision(){return 0f;}

    public virtual void MoveObject(GameObject thisObject){
        thisObject.GetComponent<Movement>().Move(speed);
    }
    public virtual void LookAround(List<GameObject> Objects){
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
}
