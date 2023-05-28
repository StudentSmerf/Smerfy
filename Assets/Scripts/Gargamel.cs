using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargamel : AbstractObj
{
    public override void GetSpeed(bool isRunning){
        speed = 10f;
        
    }

    public override float GetVision(){
        visionRange = 2.3f;
        return visionRange;
    }
}
