using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AbstractObj.simulateResults;


public class Smurf : AbstractObj
{
    private float runSpeed = 20f;
    public override simulateResults MoveObject(){
        me.GetComponent<Movement>().Move(speed);
        //Debug.Log(me.name + " is Moving");
        return noError;
    }
    public override simulateResults Look(){
        me.GetComponent<Vision>().Look(visionRange, "Bush");
        //Debug.Log(me.name + " is Looking");
        return noError;
    }
    public override simulateResults Ability(){
        me.GetComponent<Vision>().LookForG(visionRange, runSpeed, "Gargamel");
        me.GetComponent<Vision>().LookForG(visionRange, runSpeed, "Klakier");
        return noError;
    }   
    
    public Smurf(GameObject obj){
        me = obj;
        speed = 15f;
        visionRange = 2f;
        //Debug.Log("SmurfStworzony");
    }
}
