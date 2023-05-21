using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractObj
{
    public float speed;
    public float visionRange;

    public virtual float GetSpeed(bool isRunning){return 0f;}
    public virtual float GetVision(){return 0f;}
    
    
}
