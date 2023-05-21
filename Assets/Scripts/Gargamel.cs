using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargamel : AbstractObj
{
    public override float GetSpeed(bool isRunning){
        speed = 10f;
        return speed;
    }

    public override float GetVision(){
        visionRange = 2.3f;
        return visionRange;
    }
}
