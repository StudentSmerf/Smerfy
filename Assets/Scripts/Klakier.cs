using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AbstractObj.simulateResults;


public class Klakier : AbstractObj
{
    
    public override simulateResults MoveObject(){
        me.GetComponent<Movement>().Move(speed);
        //Debug.Log(me.name + " is Moving");
        return noError;
    }
    public override simulateResults Look(){
        me.GetComponent<Vision>().Look(visionRange, "Smurf");
        //Debug.Log(me.name + " is Looking");
        return noError;
    }
    public override simulateResults Ability(){
        return noError;
    } 
    
    public Klakier(GameObject obj){
        me = obj;
        speed = 12f;
        visionRange = 1.3f;
        //Debug.Log("KlakierStworzony");
    }
}
