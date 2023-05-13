using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    public void Look(string name, List<GameObject> Objects){
        switch (name)
            {
                case "SmurfB":
                    LookAsSmurf LS = new LookAsSmurf();
                    LS.GetRange();
                    foreach (GameObject bush in Objects)
                    {
                        if(LS.CanSee(bush.transform.position.x, bush.transform.position.y, this.transform.position.x, this.transform.position.y)){
                            Debug.Log(this.gameObject.name + " found " + bush.gameObject.name);
                            return;
                        }
                    }
                    break;
                case "SmurfG":
                    LookAsSmurf LS2 = new LookAsSmurf();
                    LS2.GetRange();
                    foreach (GameObject g in Objects)
                    {
                        if(LS2.CanSee(g.transform.position.x, g.transform.position.y, this.transform.position.x, this.transform.position.y)){
                            Debug.Log(this.gameObject.name + " found " + g.gameObject.name);
                            return;
                        }
                    }
                    break;
                case "Gargamel":
                    LookAsGargamel LG = new LookAsGargamel();
                    LG.GetRange();
                    foreach (GameObject s in Objects)
                    {
                        if(LG.CanSee(s.transform.position.x, s.transform.position.y, this.transform.position.x, this.transform.position.y)){
                            Debug.Log(this.gameObject.name + " found " + s.gameObject.name);
                        }
                    }
                    break;
                case "Klakier":
                    LookAsKlakier LK = new LookAsKlakier();
                    LK.GetRange();
                    foreach (GameObject s in Objects)
                    {
                        if(LK.CanSee(s.transform.position.x, s.transform.position.y, this.transform.position.x, this.transform.position.y)){
                            Debug.Log(this.gameObject.name + " found " + s.gameObject.name);
                            return;
                        }
                    }
                    break;
                default:
                    Debug.Log("Name not defined");
                    break;
            }
    }



    class LookAround{
        public float visionRange = 5f;
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
            visionRange = visionRange * 1.1f;
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
