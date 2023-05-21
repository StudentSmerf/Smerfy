using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smurf : AbstractObj
{
    public override float GetSpeed(bool isRunning){
        if(isRunning){
            speed = 20f;
            return speed;
        }
        else
        {
            speed = 15f;
            return speed;
        }
        
    }

    public override float GetVision(){
        visionRange = 2f;
        return visionRange;
    }
}
