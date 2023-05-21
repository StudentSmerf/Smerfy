using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Klakier : AbstractObj
{
    public override float GetSpeed(bool isRunning){
        speed = 12f;
        return speed;
    }

    public override float GetVision(){
        visionRange = 1.3f;
        return visionRange;
    }
}
