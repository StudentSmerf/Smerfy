using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractObj
{
    public float speed;
    public float visionRange;

    public virtual void GetSpeed(bool isRunning){}
    public virtual float GetVision(){return 0f;}

    public void MoveObject(GameObject thisObject){
        thisObject.GetComponent<Movement>().Move(speed);
    }
    
}
