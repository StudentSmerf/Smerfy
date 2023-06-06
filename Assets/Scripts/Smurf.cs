using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AbstractObj.simulateResults;

public class Smurf : AbstractObj
{
    public override simulateResults MoveObject(){
        me.GetComponent<Movement>().Move(speed);
        return noError;
    }
    public override simulateResults Look(){
        me.GetComponent<Vision>().Look(visionRange, "Bush");
        return noError;
    }
    public override simulateResults Ability(){
        me.GetComponent<Vision>().LookForG(visionRange, runSpeed, "Gargamel");
        me.GetComponent<Vision>().LookForG(visionRange, runSpeed, "Klakier");
        return noError;
    }   
    
    public Smurf(GameObject obj){
        me = obj;
        speed = 30f;
        visionRange = 2f;
        runSpeed = 50f;
    }
}
