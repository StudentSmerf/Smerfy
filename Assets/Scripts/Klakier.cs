using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Klakier : AbstractObj
{
    public override void GetSpeed(bool isRunning){
        speed = 12f;
        
    }

    public override float GetVision(){
        visionRange = 1.3f;
        return visionRange;
    }

}
