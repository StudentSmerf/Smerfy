using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(){
        Vector2 direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

        switch (this.gameObject.tag)
            {
                case "Smurf":
                    MoveSmurf MS = new MoveSmurf();
                    MS.SetSpeed();
                    rb.velocity = Vector2.zero;
                    rb.AddForce(direction * MS.GetSpeed());
                    //Debug.Log(this.gameObject.name + " moves with speed " + MS.GetSpeed());
                    break;
                case "Gargamel":
                    MoveGargamel MG = new MoveGargamel();
                    MG.SetSpeed();
                    rb.velocity = Vector2.zero;
                    rb.AddForce(direction * MG.GetSpeed());
                    //Debug.Log(this.gameObject.name + " moves with speed " + MG.GetSpeed());
                    break;
                case "Klakier":
                    MoveKlakier MK = new MoveKlakier();
                    MK.SetSpeed();
                    rb.velocity = Vector2.zero;
                    rb.AddForce(direction * MK.GetSpeed());
                    //Debug.Log(this.gameObject.name + " moves with speed " + MK.GetSpeed());
                    break;
                default:
                    Debug.Log("Tag not defined");
                    break;
            }
    }

    public void Run(Vector3 dangerPosition){
        RunSmurf MS = new RunSmurf();
        MS.SetSpeed();
        rb.velocity = Vector2.zero;
        rb.AddForce((transform.position - dangerPosition) * MS.GetSpeed());
        Debug.Log(this.gameObject.name + " runs with speed " + MS.GetSpeed());
    }
    
    


    class Mover{
        public float speed = 15f;
        
        public virtual void SetSpeed(){}
        public float GetSpeed(){
            return speed;
        }

      
    }
    class RunSmurf : Mover{
        public override void SetSpeed(){
            speed = speed * 2f;
        }
    }
    class MoveSmurf : Mover{
        public override void SetSpeed(){
            speed = speed * 1.4f;
        }
    }
    class MoveGargamel : Mover{
        public override void SetSpeed(){
            speed = speed * 0.5f;
        }
    }
    class MoveKlakier : Mover{
        public override void SetSpeed(){
            speed = speed * 0.8f;
        }
    }
}
