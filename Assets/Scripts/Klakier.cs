using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AbstractObj.simulateResults;

public class Klakier : AbstractObj
{
    
    public override simulateResults MoveObject(){
        me.GetComponent<Movement>().Move(speed);
        AddOne();
        return noError;
    }
    public override simulateResults Look(){
        me.GetComponent<Vision>().Look(visionRange, "Smurf");
        AddOne();
        return noError;
    }
    public override simulateResults Ability(){
        AddOne();
        return noError;
    } 
    
    public Klakier(GameObject obj){
        me = obj;
        speed = 50f;
        visionRange = 1.7f;
    }
    private int counter = 0;
    private void AddOne(){
        counter++;
        if(counter >= 40){
            me.GetComponent<GetPickedUp>().Pick();
        }
    }
}
