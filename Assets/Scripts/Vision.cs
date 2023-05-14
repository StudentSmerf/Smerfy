using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    public GameObject[] Smurfs2;
    public void Look(string name, List<GameObject> Objects){
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
                //Smurf looking for Gargamels/Klakiers
                case "SmurfG":
                    
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
    }

    public void LookForG(List<GameObject> Gargamels, List<GameObject> Smurfs){
        LookAsSmurf LS2 = new LookAsSmurf();
        LS2.GetRange();
        foreach (GameObject g in Gargamels)
        {
            if(LS2.CanSee(g.transform.position.x, g.transform.position.y, this.transform.position.x, this.transform.position.y)){
                Debug.Log(this.gameObject.name + " found " + g.gameObject.name);
                //this.gameObject.GetComponent<Movement>().Run(g.transform.position);
                foreach (GameObject s in Smurfs)
                {
                    if(LS2.CanSee(s.transform.position.x, s.transform.position.y, this.transform.position.x, this.transform.position.y)){
                        s.gameObject.GetComponent<Movement>().Run(g.transform.position);
                    }
                }
                return;
            }
        }
    }



    class LookAround{
        public float visionRange = 1f;
        public virtual void GetRange(){}
        public bool CanSee(float x1, float y1, float x2, float y2){
            float distance = Mathf.Sqrt((x1-x2)*(x1-x2) + (y1-y2) * (y1-y2));
            if(distance <= visionRange){
                return true;
            }
            return false;
        }
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
}
