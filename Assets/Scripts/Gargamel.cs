using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AbstractObj.simulateResults;

public class Gargamel : AbstractObj
{
    
    public override simulateResults MoveObject(){
        me.GetComponent<Movement>().Move(speed);
        return noError;
    }
    public override simulateResults Look(){
        me.GetComponent<Vision>().Look(visionRange, "Smurf");
        return noError;
    }
    public override simulateResults Ability(){
        return AbstractObj.simulateResults.spawnKlakier;
    }
    public override Vector3 spawnKlakier(){
        return me.transform.position;
    } 
    
    public Gargamel(GameObject obj){
        me = obj;
        speed = 30f;
        visionRange = 2.3f;
    }
}
