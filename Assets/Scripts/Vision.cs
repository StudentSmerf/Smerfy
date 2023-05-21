using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    
    public void Look(float visionRange, List<GameObject> Objects){


        foreach (GameObject obj in Objects)
        {
            float x1, y1, x2, y2, distance;
            x1 = obj.transform.position.x;
            y1 = obj.transform.position.y;
            x2 = this.transform.position.x;
            y2 = this.transform.position.y;
            distance = Mathf.Sqrt((x1-x2)*(x1-x2) + (y1-y2) * (y1-y2));
            if(distance <= visionRange){
                obj.GetComponent<GetPickedUp>().Pick();
            }
            
        }


        /*


        switch (name)
            {
                //Smurf looking for berries
                case "SmurfB":
                    LookAsSmurf LS = new LookAsSmurf();
                    LS.GetRange();
                    foreach (GameObject bush in Objects)
                    {
                        if(LS.CanSee(bush.transform.position.x, bush.transform.position.y, this.transform.position.x, this.transform.position.y)){
                            //Debug.Log(this.gameObject.name + " found " + bush.gameObject.name);
                            bush.GetComponent<GetPickedUp>().Pick("Bush");
                            return;
                        }
                    }
                    break;
                //Gargamel looking for Smurfs
                case "Gargamel":
                    LookAsGargamel LG = new LookAsGargamel();
                    LG.GetRange();
                    foreach (GameObject s in Objects)
                    {
                        if(LG.CanSee(s.transform.position.x, s.transform.position.y, this.transform.position.x, this.transform.position.y)){
                            //Debug.Log(this.gameObject.name + " found " + s.gameObject.name);
                            s.GetComponent<GetPickedUp>().Pick("Smurf");
                        }
                    }
                    break;
                //Klakier looking for Smurfa
                case "Klakier":
                    LookAsKlakier LK = new LookAsKlakier();
                    LK.GetRange();
                    foreach (GameObject s in Objects)
                    {
                        if(LK.CanSee(s.transform.position.x, s.transform.position.y, this.transform.position.x, this.transform.position.y)){
                            //Debug.Log(this.gameObject.name + " found " + s.gameObject.name);
                            s.GetComponent<GetPickedUp>().Pick("Smurf");
                            return;
                        }
                    }
                    break;
                default:
                    Debug.Log("Name not defined");
                    break;
            }
            */
    }
    /*
    public bool CanSee(float x1, float y1, float x2, float y2){
        float distance = Mathf.Sqrt((x1-x2)*(x1-x2) + (y1-y2) * (y1-y2));
        if(distance <= visionRange){
            return true;
        }
        return false;
    }
    */
    public void LookForG(float visionRange, float speed, List<GameObject> Gargamels, List<GameObject> Smurfs){
        float x1, y1, x2, y2, distance;
        x2 = this.transform.position.x;
        y2 = this.transform.position.y;
        //Look if there is Gargamel nearby
        foreach (GameObject g in Gargamels)
        {
            
            x1 = g.transform.position.x;
            y1 = g.transform.position.y;
            
            distance = Mathf.Sqrt((x1-x2)*(x1-x2) + (y1-y2) * (y1-y2));
            //if there is Gargamel nearby, look for Smurfs nearby
            if(distance <= visionRange){
                foreach (GameObject s in Smurfs)
                {
                    
                    x1 = s.transform.position.x;
                    y1 = s.transform.position.y;
                    distance = Mathf.Sqrt((x1-x2)*(x1-x2) + (y1-y2) * (y1-y2));
                    //if there are Smurfs, tell them to run
                    if(distance <= visionRange){
                        s.gameObject.GetComponent<Movement>().Move(speed);
                    }
                }
            }
            
        }
    }


    /*
    class LookAround{
        public float visionRange = 1f;
        public virtual void GetRange(){}
        
    }

    
    class LookAsSmurf : LookAround{
        public override void GetRange(){
            visionRange = visionRange * 1.5f;
        }
    }
    class LookAsGargamel : LookAround{
        public override void GetRange(){
            visionRange = visionRange * 0.9f;
        }
    }
    class LookAsKlakier : LookAround{
        public override void GetRange(){
            visionRange = visionRange * 0.5f;
        }
    }
    */
}
