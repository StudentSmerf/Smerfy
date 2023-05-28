using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smurf : AbstractObj
{
    public override void GetSpeed(bool isRunning){
        if(isRunning){
            speed = 20f;
            
        }
        else
        {
            speed = 15f;
            
        }
        
    }

    public override float GetVision(){
        visionRange = 2f;
        return visionRange;
    }

    
}
