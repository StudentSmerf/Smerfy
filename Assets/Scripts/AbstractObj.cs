using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AbstractObj.simulateResults;

 
public abstract class AbstractObj
{
    public enum simulateResults
    {
        error=-1,
        noError,
        spawnKlakier
    }
    public GameObject me;

    public float speed;
    public float visionRange;

    

    public virtual simulateResults MoveObject(){return error;}
    public virtual simulateResults Look(){return error;}
    public virtual simulateResults Ability(){return error;}
    public virtual Vector3 spawnKlakier(){
        Debug.Log("No Vector3 returned when spawning Klakier");
        return Vector3.zero;
    }

   

    public simulateResults Simulate(){
        simulateResults result = error;
        //Debug.Log(me.name + " is Simulating");
        switch (Random.Range(1,10))
        {
            case < 5:
                //Move Object
                result = MoveObject();
                
                break;
            case 5:
                //Special Ability
                result = Ability();
                break;
            case > 5:
                //Look Around
                result = Look();
                break;
            default:
                Debug.Log("Rand not Working?");
                break;
        }
        return result;
        
    }

    
    
}
